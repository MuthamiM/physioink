from .base_agent import BaseAgent
import pyperclip
from openai import OpenAI
import os

class RefactorAgent(BaseAgent):
    def __init__(self):
        api_key = os.getenv("OPENAI_API_KEY")
        self.mock_mode = not api_key
        if self.mock_mode:
            print("WARNING: No OPENAI_API_KEY found. Running in MOCK MODE.")
            self.client = None
        else:
            self.client = OpenAI(api_key=api_key)

    def run(self, temperature: float = 0.3, context: str = None) -> str:
        """
        1. Reads code from Clipboard.
        2. Sends it to an LLM to refactor/clean up.
        3. Copies the refactored code back to Clipboard.
        """
        code_snippet = pyperclip.paste()
        if not code_snippet or len(code_snippet.strip()) == 0:
            return "Clipboard is empty!"

        print(f"Refactoring code: {code_snippet[:50]}... (Temp: {temperature})")

        if self.mock_mode:
            import time
            time.sleep(1.5)  # Simulate thinking
            refactored = (
                "# [MOCK REFACTOR]\n"
                "# Renamed variables, extracted helpers, improved structure.\n"
                "def refactored_function(data: list) -> list:\n"
                "    return [item for item in data if item]"
            )
            pyperclip.copy(refactored)
            return "Refactored code copied to clipboard! (MOCK)"

        try:
            response = self.client.chat.completions.create(
                model="gpt-4o",
                messages=[
                    {"role": "system", "content": (
                        "You are an expert software engineer. Refactor the following code "
                        "to improve readability, performance, and adherence to best practices. "
                        "Return ONLY the refactored code, no explanation."
                    )},
                    {"role": "user", "content": code_snippet}
                ],
                temperature=temperature
            )

            refactored = response.choices[0].message.content
            pyperclip.copy(refactored)
            return "Refactored code copied to clipboard!"

        except Exception as e:
            return f"Error refactoring code: {str(e)}"
