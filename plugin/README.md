# Synapse C# Plugin Setup

Since the Logi Options+ SDK requires specific tools, follow these steps to initialize the C# plugin.

## Prerequisites
1.  **Visual Studio 2022** (or newer) with .NET Desktop Development workload.
2.  **Logi Options+** installed.
3.  **Logi Options+ Plugin Template** (if available) or a standard Console App.

## Steps
1.  Open this folder in your terminal.
2.  Create a new Console App (if you don't have the specific template):
    ```powershell
    dotnet new console -n SynapseBridge
    cd SynapseBridge
    dotnet add package Websocket.Client
    ```
3.  Replace the contents of `Program.cs` with the code provided in this folder.
4.  Build the project:
    ```powershell
    dotnet build
    ```
5.  (Advanced) To integrate with Logi Options+, you will need to package this executable according to their SDK documentation (manifest.json).

## How it Works
This C# app acts as a client. It connects to the Python Brain at `ws://127.0.0.1:8000/ws`.
-   **Your Job**: Use the Logi Options+ SDK to detect Dial/Key events, and then call `await client.Send(...)` to forward them to Python.
