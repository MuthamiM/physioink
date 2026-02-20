using UnityEngine;

/// <summary>
/// Procedurally generates the anatomical scene at runtime.
/// This avoids the need for heavy FBX assets in the repo.
/// </summary>
public class SceneSetup : MonoBehaviour
{
    [Header("Generation Settings")]
    public float armLength = 0.5f;
    public float armRadius = 0.08f;

    void Start()
    {
        SetupEnvironment();
        GenerateArm();
        SetupStylus();
    }

    void SetupEnvironment()
    {
        // 1. Create Table
        GameObject table = GameObject.CreatePrimitive(PrimitiveType.Cube);
        table.name = "Surgical Table";
        table.transform.position = new Vector3(0, 0.8f, 0.5f);
        table.transform.localScale = new Vector3(1.5f, 0.05f, 0.8f);
        table.GetComponent<Renderer>().material.color = new Color(0.8f, 0.9f, 1.0f); // Sterile blue
    }

    void GenerateArm()
    {
        GameObject armRoot = new GameObject("Patient Arm");
        armRoot.transform.position = new Vector3(0, 0.85f, 0.5f);
        
        // 2. Bone Layer (Inner)
        CreateTissueLayer(armRoot.transform, "Humerus Bone", 0.02f, Color.white, TissueLayer.TissueType.Bone);

        // 3. Muscle Layer (Middle)
        CreateTissueLayer(armRoot.transform, "Biceps Muscle", 0.05f, new Color(0.8f, 0.2f, 0.2f), TissueLayer.TissueType.Muscle);

        // 4. Skin Layer (Outer)
        CreateTissueLayer(armRoot.transform, "Skin", 0.08f, new Color(1.0f, 0.8f, 0.6f), TissueLayer.TissueType.Skin);
    }
    
    void CreateTissueLayer(Transform parent, string name, float radius, Color color, TissueLayer.TissueType type)
    {
        GameObject layer = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        layer.name = name;
        layer.transform.parent = parent;
        layer.transform.localPosition = Vector3.zero;
        layer.transform.localRotation = Quaternion.Euler(0, 0, 90); // Horizontal arm
        layer.transform.localScale = new Vector3(radius * 2, armLength / 2, radius * 2);
        
        layer.GetComponent<Renderer>().material.color = color;
        
        // Add Tissue Logic
        TissueLayer tl = layer.AddComponent<TissueLayer>();
        tl.type = type;
        tl.hardness = (type == TissueLayer.TissueType.Bone) ? 1.0f : 0.4f;
    }

    void SetupStylus()
    {
        // 5. Stylus Placeholder
        GameObject stylus = new GameObject("MX Ink Stylus");
        stylus.AddComponent<MXInkManager>();
        
        // Visuals
        GameObject body = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        body.transform.parent = stylus.transform;
        body.transform.localScale = new Vector3(0.01f, 0.07f, 0.01f);
        body.transform.localRotation = Quaternion.Euler(90, 0, 0);
        
        // Add Scalpel Tool
        GameObject tip = new GameObject("Tip");
        tip.transform.parent = stylus.transform;
        tip.transform.localPosition = new Vector3(0, 0, 0.07f);
        tip.AddComponent<ScalpelTool>();
    }
}
