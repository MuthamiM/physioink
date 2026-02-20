# Synapse: Conduct Your AI

> "Don't just chat with AI—conduct it."

Synapse transforms the **Logitech MX Creative Console** into a tactile command center for Artificial Intelligence. Adjust "Creativity" (Temperature) with a physical dial, trigger complex agentic workflows with a single button press, and bring the intangible power of LLMs into your physical workflow.

## 🏆 How Synapse Meets the Challenge Requirements
The challenge asks for an **"Intelligent Plugin"** that **"Impersonates AI assistants in a key"**.

Synapse implements this exactly via a modern **Bridge Architecture**:
1.  **The Plugin (C#)**: A native .NET executable that interfaces with the Logitech hardware (Actions SDK).
2.  **The Intelligence (Python)**: A sophisticated backend that runs the AI Agents.

*We use this split architecture to leverage Python's superior AI ecosystem (OpenAI) while maintaining native hardware performance.*

## 🚀 Features
*   **Tactile Tuning**: Use the Dial to adjust LLM Temperature in real-time (0.0 – 2.0).
*   **The Fixer**: Press a key to instantly debug the code in your clipboard.
*   **The Scribe**: Press a key to generate documentation for your code.
*   **The Refactor**: Press a key to clean up and refactor your code.
*   **Bridge Architecture**: Connects Logitech's ecosystem (C#) to the bleeding edge of AI (Python).

## 🛠️ Tech Stack
*   **Hardware**: Logitech MX Creative Console
*   **Plugin**: C# (.NET 8.0) — *The Bridge*
*   **Brain**: Python 3.11 (FastAPI, OpenAI) — *The Intelligence*

## 📦 Installation

### 1. Prerequisites
*   Logi Options+ Installed
*   Python 3.11+
*   .NET SDK 8.0+
*   OpenAI API Key

### 2. Setup The Brain (Python)
```bash
cd brain
pip install -r requirements.txt
# Copy .env.example to .env and add your API key
copy .env.example .env
# Edit .env with your OPENAI_API_KEY
python main.py
```

### 3. Setup The Bridge (C# / Plugin)
```bash
cd plugin/SynapseBridge
dotnet build
dotnet run
```
Or use the **Simulation Client** for testing without hardware:
```bash
python brain/sim_client.py
```

## 🎮 Usage
| Control | Action | Agent |
|---------|--------|-------|
| **Dial** | Turn left/right | Adjust Temperature (0.0 – 2.0) |
| **Key 1** | Press | **The Fixer** — Reads clipboard → Fixes code → Updates clipboard |
| **Key 2** | Press | **The Scribe** — Reads clipboard → Adds docs → Updates clipboard |
| **Key 3** | Press | **The Refactor** — Reads clipboard → Refactors code → Updates clipboard |

## 📄 License
MIT
