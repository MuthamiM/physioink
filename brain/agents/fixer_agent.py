from .base_agent import BaseAgent
import pyperclip
from openai import OpenAI
import os

class FixerAgent(BaseAgent):
    def __init__(self):
        # Graceful fallback if no key is present
        api_key = os.getenv("OPENAI_API_KEY")
        self.mock_mode = not api_key
        if self.mock_mode:
            print("WARNING: No OPENAI_API_KEY found. Running in MOCK MODE.")
            self.client = None
        else:
            self.client = OpenAI(api_key=api_key)

    def run(self, temperature: float = 0.2, context: str = None) -> str:
        """
        1. Reads code from Clipboard.
        ...
        """
        code_snippet = pyperclip.paste()
        if not code_snippet or len(code_snippet.strip()) == 0:
            return "Clipboard is empty!"

        print(f"Fixing code: {code_snippet[:50]}... (Temp: {temperature})")
        
        if self.mock_mode:
            import time
            time.sleep(1.5) # Simulate thinking
            fixed_code = "# [MOCK FIX]\n# Your code had a syntax error.\ndef fixed_function():\n    return 'Success'"
            pyperclip.copy(fixed_code)
            return "Fixed code copied to clipboard! (MOCK)"

        try:
            response = self.client.chat.completions.create(
                model="gpt-4o",
                messages=[
                    {"role": "system", "content": "You are an expert debugger. Fix the following code. Return ONLY the fixed code explanation."},
                    {"role": "user", "content": code_snippet}
                ],
                temperature=temperature
            )
            
            fixed_code = response.choices[0].message.content
            pyperclip.copy(fixed_code)
            return "Fixed code copied to clipboard!"

        except Exception as e:
            return f"Error fixing code: {str(e)}"
