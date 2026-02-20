using UnityEngine;

/// <summary>
/// Represents a layer of tissue (Skin, Fat, Muscle, Bone) that can be cut.
/// </summary>
public class TissueLayer : MonoBehaviour
{
    public enum TissueType { Skin, Fat, Muscle, Bone, Nerve }
    
    [Header("Properties")]
    public TissueType type;
    [Range(0f, 1f)] public float hardness = 0.2f; // Resistance to cutting
    [Range(0f, 1f)] public float cutThreshold = 0.1f; // Minimum pressure required to cut

    private Material _material;
    
    void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    /// <summary>
    /// Attempt to cut this tissue with a given pressure.
    /// Returns true if cut was successful.
    /// </summary>
    public bool TryCut(Vector3 hitPoint, float pressure)
    {
        if (pressure >= cutThreshold)
        {
            // Send haptic feedback based on hardness
            MXInkManager.Instance.TriggerHapticPulse(hardness, 0.05f);
            
            Debug.Log($"[Scalpel] Cut into {type} at {hitPoint} with pressure {pressure:F2}");
            
            // Visual feedback: Change color slightly at hit point (basic simulation)
            // In a real app, this would use a shader / mesh deformation
            return true;
        }
        else
        {
            // Light haptic "scratch" feeling if pressure is too low
            MXInkManager.Instance.TriggerHapticPulse(0.1f, 0.02f);
            return false;
        }
    }
}
