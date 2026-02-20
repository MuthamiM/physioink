# PhysioInk: Learn Anatomy by Touching It

> *"Transform the MX Ink stylus into a virtual scalpel, probe, and annotation pen for immersive medical training."*

**PhysioInk** is a Mixed Reality medical training application for **Meta Quest** that leverages the **Logitech MX Ink** stylus to deliver hands-on anatomy education. Students and healthcare professionals can dissect, annotate, and explore 3D anatomical models with the same precision and tactile feedback as real surgical instruments.

---

## 🏆 DevStudio 2026 — Track 2: MX INK

This project is our submission for the [Logitech DevStudio 2026 Challenge](https://devstudio2026.devpost.com/) — Track 2 (MX INK / MR Stylus for Meta Quest).

---

## 📁 Project Structure

```
PhysioInk/
├── unity/                   # Unity Project (The Build)
│   ├── Assets/Scripts/      # C# Logic
│   │   ├── Core/            # MXInkManager, TissueLayer, HapticFeedback
│   │   └── Tools/           # ScalpelTool, ProbeTool
│   └── Assets/Prefabs/      # Tissue blocks, Scalpel model
├── docs/                    # Pitch Materials
│   ├── devpost_pitch.md     # Devpost text
│   ├── video_script.md      # 1-minute video script
│   └── concept_art/         # Visuals
└── README.md
```

## 🚀 The Solution

PhysioInk turns the MX Ink stylus into a **precision medical instrument** inside Mixed Reality:

| Feature | MX Ink Capability | Implementation |
|---------|-------------------|----------------|
| **Virtual Scalpel** | Pressure sensitivity → incision depth | `ScalpelTool.cs`, `TissueLayer.cs` |
| **3D Annotation** | 6DoF tracking + air drawing | `MXInkManager.cs` |
| **Surface Tracing** | 2D mode on real surfaces | (Planned for Phase 2) |
| **Haptic Tissue Feedback** | Haptic feedback API | `HapticFeedback.cs` |

## 🛠️ Tech Stack

- **Engine**: Unity 2022.3 LTS
- **MR SDK**: Meta Core SDK v68+
- **Stylus**: MX Ink OpenXR Interaction Profile
- **Platform**: Meta Quest 3

## 👥 Team

- **Muthami M** — Developer

## 📄 License

MIT
