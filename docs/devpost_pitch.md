# PhysioInk — Devpost Submission Text

## Project Title
**PhysioInk: Learn Anatomy by Touching It**

## Tagline
*The MX Ink stylus becomes a virtual scalpel for immersive, hands-on anatomy training in Mixed Reality.*

---

## Inspiration

Medical students around the world struggle with anatomy education. Cadaver labs are expensive ($10,000+ per cadaver), limited to select institutions, and fraught with ethical concerns. Meanwhile, existing VR anatomy apps rely on imprecise hand controllers — nothing like the tools doctors actually use.

When we discovered the Logitech MX Ink's pressure-sensitive tip and haptic feedback, we asked: *What if a stylus could feel like a scalpel?*

## What it does

PhysioInk is a Mixed Reality application for Meta Quest that transforms the Logitech MX Ink stylus into a precision medical training instrument.

**Core Experiences:**

1. **Dissect** — Use the stylus as a virtual scalpel. Press lightly to cut through skin, press harder to cut through muscle. The pressure-sensitive tip maps directly to incision depth, while haptic feedback simulates tissue resistance.

2. **Annotate** — Draw labels, arrows, and notes directly in 3D space around anatomical structures. Identify muscle origins, nerve pathways, and vascular routes by writing in the air with the stylus.

3. **Trace** — Place a physical reference sheet on your desk. Using the MX Ink's surface mode, trace anatomical diagrams on paper while seeing the 3D structures come alive in your headset — bridging 2D learning with 3D understanding.

4. **Learn** — Follow guided dissection lessons with step-by-step instructions. The system grades your technique based on pressure accuracy, tool path, and completeness.

## How we built it

- **Unity 2022.3 LTS** as our game engine
- **Meta Core SDK v68+** for Quest integration
- **MX Ink OpenXR Interaction Profile** for stylus input (pressure, buttons, 6DoF tracking, haptics)
- **Anatomical 3D models** with layered tissue systems (skin → fat → muscle → bone)

## MX Ink Integration

PhysioInk uses *every* capability of the MX Ink stylus:

| Capability | How We Use It |
|-----------|---------------|
| Pressure-sensitive tip | Scalpel incision depth control |
| 6DoF spatial tracking | Precise annotation in 3D space |
| Haptic feedback | Tissue resistance simulation |
| Surface drawing mode | 2D anatomical tracing on desk |
| Customizable buttons | Multi-tool switching (scalpel/probe/pen) |
| Pressure-sensitive barrel button | Zoom & rotate model controls |

## Challenges we ran into

- Mapping realistic tissue resistance to the haptic feedback system
- Creating intuitive "cut depth" mechanics that feel natural with the stylus pressure curve
- Balancing medical accuracy with accessible, engaging interaction design

## Accomplishments we're proud of

- Demonstrating that the MX Ink can serve as a precision instrument beyond creative/artistic use
- Bridging 2D surface tracing with 3D spatial understanding — a novel learning modality
- Creating a viable alternative to cadaver labs that could democratize anatomy education globally

## What we learned

- The MX Ink's pressure-sensitive tip opens up interaction modalities far beyond drawing
- Haptic feedback is incredibly powerful for simulating real-world materials
- Medical education is ripe for MR disruption, especially with precision input devices

## What's next for PhysioInk

- **Expand the anatomy library** — full body systems (skeletal, muscular, nervous, cardiovascular)
- **Multiplayer mode** — instructor-led dissection sessions with remote students
- **Certification integration** — partner with medical schools for accredited anatomy modules
- **Meta App Store launch** — publishing for global access
- **Assessment analytics** — track student progress, technique improvement over time

## Built With

`unity` `c-sharp` `meta-quest` `logitech-mx-ink` `openxr` `mixed-reality`
