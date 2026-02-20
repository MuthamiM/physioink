import asyncio
import websockets
import json

async def simulate_plugin():
    uri = "ws://127.0.0.1:8001/ws"
    async with websockets.connect(uri) as websocket:
        print(f"Connected to Brain at {uri}")
        print("Commands: 'd <val>' (Dial), 'k 1' (Fixer), 'k 2' (Scribe), 'k 3' (Refactor), 'q' (Quit)")

        while True:
            cmd = input("Enter command: ").strip()
            if cmd == "q":
                break
            
            payload = {}
            if cmd.startswith("d "):
                try:
                    val = float(cmd.split()[1])
                    payload = {"action": "dial_turn", "value": val}
                except:
                    print("Invalid dial value")
                    continue
            elif cmd == "k 1":
                payload = {"action": "key_press", "key_id": "fixER_agent"}
            elif cmd == "k 2":
                payload = {"action": "key_press", "key_id": "scribe_agent"}
            elif cmd == "k 3":
                payload = {"action": "key_press", "key_id": "refactor_agent"}
            else:
                print("Unknown command")
                continue

            print(f"Sending: {payload}")
            await websocket.send(json.dumps(payload))
            
            # Wait for response
            response = await websocket.recv()
            print(f"Received: {response}")

if __name__ == "__main__":
    asyncio.run(simulate_plugin())
