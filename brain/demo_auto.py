import asyncio
import websockets
import json

async def run_demo():
    uri = "ws://127.0.0.1:8001/ws"
    print(f"Connecting to Synapse Brain at {uri}...")
    
    try:
        async with websockets.connect(uri) as websocket:
            print("Successfully connected!")
            print("\n--- ACT 1: DIAL TUNING ---")
            print("Simulating turning dial to increase temperature...")
            
            for val in range(0, 100, 20):
                payload = {"action": "dial_turn", "value": float(val)}
                await websocket.send(json.dumps(payload))
                response = await websocket.recv()
                print(f"Brain: {response}")
                await asyncio.sleep(0.5)

            print("\n--- ACT 2: THE FIXER ---")
            print("Simulating 'Key 1' press to Fix Code...")
            payload = {"action": "key_press", "key_id": "fixER_agent"}
            await websocket.send(json.dumps(payload))
            print("Sent request. Waiting for Agent...")
            response = await websocket.recv()
            print(f"Brain: {response}")

            print("\n--- ACT 3: THE SCRIBE ---")
            print("Simulating 'Key 2' press to Write Docs...")
            payload = {"action": "key_press", "key_id": "scribe_agent"}
            await websocket.send(json.dumps(payload))
            print("Sent request. Waiting for Agent...")
            response = await websocket.recv()
            print(f"Brain: {response}")

            print("\n--- ACT 4: THE REFACTOR ---")
            print("Simulating 'Key 3' press to Refactor Code...")
            payload = {"action": "key_press", "key_id": "refactor_agent"}
            await websocket.send(json.dumps(payload))
            print("Sent request. Waiting for Agent...")
            response = await websocket.recv()
            print(f"Brain: {response}")
            
            print("\n--- DEMO COMPLETE ---")

    except Exception as e:
        print(f"Connection failed: {e}")
        import traceback
        traceback.print_exc()
        print("Make sure main.py is running on port 8001!")

if __name__ == "__main__":
    asyncio.run(run_demo())
