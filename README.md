# PhysioInk: Learn Anatomy by Touching It

> *"Transform the MX Ink stylus into a virtual scalpel, probe, and annotation pen for immersive medical training."*

**PhysioInk** is a Mixed Reality medical training application for **Meta Quest** that leverages the **Logitech MX Ink** stylus to deliver hands-on anatomy education. Students and healthcare professionals can dissect, annotate, and explore 3D anatomical models with the same precision and tactile feedback as real surgical instruments.

---

## 🏆 DevStudio 2026 — Track 2: MX INK

This project is our submission for the [Logitech DevStudio 2026 Challenge](https://devstudio2026.devpost.com/) — Track 2 (MX INK / MR Stylus for Meta Quest).

---

## 💡 The Problem

Medical students need hands-on anatomy practice, but:
- **Cadaver labs** cost institutions $10,000+ per cadaver and are limited in availability
- **2D textbooks** and flat screens can't convey 3D spatial relationships
- **Existing VR anatomy apps** use hand controllers — imprecise and unnatural for surgical training

## 🚀 The Solution

PhysioInk turns the MX Ink stylus into a **precision medical instrument** inside Mixed Reality:

| Feature | MX Ink Capability |
|---------|-------------------|
| **Virtual Scalpel** — Slice through tissue layers by pressing the stylus tip | Pressure sensitivity → incision depth |
| **3D Annotation** — Label muscles, bones, and nerves directly in 3D space | 6DoF tracking + air drawing |
| **Surface Tracing** — Trace anatomical pathways on your physical desk | 2D mode on real surfaces |
| **Haptic Tissue Feedback** — Feel resistance when cutting different tissue types | Haptic feedback API |
| **Guided Dissection** — Step-by-step tutorials with real-time grading | Pose tracking + pressure thresholds |
| **Multi-tool Switching** — Switch between scalpel, probe, and pen via button | Customizable button mapping |

## 🎯 Why PhysioInk Wins

- **Novelty**: First MR anatomy app that uses a precision stylus as a surgical instrument
- **Impact**: Democratizes anatomy education — accessible anywhere a Quest + MX Ink exists
- **Viability**: Medical schools spend millions on cadaver programs; SaaS model with institutional licensing
- **Implementation**: Leverages *every* MX Ink capability (pressure, haptics, 6DoF, dual-mode, buttons)

## 🛠️ Tech Stack

| Component | Technology |
|-----------|-----------|
| **Engine** | Unity 2022.3 LTS |
| **MR SDK** | Meta Core SDK v68+ |
| **Stylus** | MX Ink OpenXR Interaction Profile |
| **Platform** | Meta Quest 3 |
| **3D Models** | Anatomical assets (skeletal, muscular, nervous systems) |
| **Target** | Meta App Store publication |

## 📁 Project Structure

```
PhysioInk/
├── docs/                    # Pitch & submission materials
│   ├── devpost_pitch.md     # Devpost submission text
│   ├── video_script.md      # 1-minute video pitch script
│   └── concept_art/         # Mockup visuals
├── unity/                   # Unity project (Semi-finals)
│   └── (TBD — April build)
└── README.md
```

## 👥 Team

- **Muthami M** — Developer

## 📄 License

MIT
