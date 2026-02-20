using UnityEngine;

/// <summary>
/// The virtual scalpel tool logic.
/// Attached to the Stylus tip GameObject.
/// </summary>
public class ScalpelTool : MonoBehaviour
{
    [Header("Settings")]
    public float bladeLength = 0.02f; // 2cm blade
    public LayerMask anatomyLayer;    // Layers considered "Cuttable"

    void Update()
    {
        // Only cut if we have pressure
        float pressure = MXInkManager.Instance.currentPressure;

        if (pressure > 0.05f)
        {
            PerformCut(pressure);
        }
    }

    void PerformCut(float pressure)
    {
        // Raycast forward from the tip to detect tissue
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, bladeLength, anatomyLayer))
        {
            TissueLayer tissue = hit.collider.GetComponent<TissueLayer>();
            if (tissue != null)
            {
                bool cutSuccess = tissue.TryCut(hit.point, pressure);
                
                if (cutSuccess)
                {
                    // Draw debug line for the cut
                    Debug.DrawLine(transform.position, hit.point, Color.red, 2.0f);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, transform.forward * bladeLength);
    }
}
