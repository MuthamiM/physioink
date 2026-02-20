from fastapi import FastAPI, WebSocket
from typing import Dict, Any
from dotenv import load_dotenv
import uvicorn
import json

# Load .env file (if present) for OPENAI_API_KEY
load_dotenv()

app = FastAPI()

# State
current_temperature = 0.5
clients = []

@app.websocket("/ws")
async def websocket_endpoint(websocket: WebSocket):
    global current_temperature
    await websocket.accept()
    clients.append(websocket)
    try:
        while True:
            data = await websocket.receive_text()
            event = json.loads(data)
            print(f"Received event: {event}")
            
            # Handle Dial Turn
            if event.get("action") == "dial_turn":
                raw_value = float(event.get("value"))
                # Clamp between 0.0 and 2.0 (OpenAI limit)
                current_temperature = max(0.0, min(2.0, raw_value / 50.0)) 
                
                await websocket.send_text(json.dumps({
                    "status": "updated_temp", 
                    "value": current_temperature,
                    "display": f"Temp: {current_temperature:.2f}"
                }))
            
            # Handle Key Press
            elif event.get("action") == "key_press":
                key_id = event.get("key_id")
                
                # ROUTING LOGIC
                if key_id == "fixER_agent":
                    from agents.fixer_agent import FixerAgent
                    agent = FixerAgent()
                    result = agent.run(temperature=current_temperature)
                    response = {"status": "agent_response", "agent": "Fixer", "message": result}
                elif key_id == "scribe_agent":
                    from agents.scribe_agent import ScribeAgent
                    agent = ScribeAgent()
                    result = agent.run(temperature=current_temperature)
                    response = {"status": "agent_response", "agent": "Scribe", "message": result}
                elif key_id == "refactor_agent":
                    from agents.refactor_agent import RefactorAgent
                    agent = RefactorAgent()
                    result = agent.run(temperature=current_temperature)
                    response = {"status": "agent_response", "agent": "Refactor", "message": result}
                else:
                    response = {"status": "error", "message": "Unknown Agent ID"}
                
                await websocket.send_text(json.dumps(response))

    except Exception as e:
        print(f"Error: {e}")
    finally:
        clients.remove(websocket)

if __name__ == "__main__":
    uvicorn.run(app, host="127.0.0.1", port=8001)
