using UnityEngine;
using UnityEngine.XR;

/// <summary>
/// Manages input from the Logitech MX Ink stylus.
/// Reads pressure, position, and button states from the OpenXR input system.
/// </summary>
public class MXInkManager : MonoBehaviour
{
    [Header("Input References")]
    public Transform stylusTransform; // Assign the Stylus GameObject (Tracked Pose Driver)

    [Header("Debug")]
    [Range(0f, 1f)] public float currentPressure = 0f;
    public bool isTouchingSurface = false;

    // Singleton instance
    public static MXInkManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Update()
    {
        // 1. Read Pressure (0.0 to 1.0)
        // In a real OpenXR build, this comes from the specific input feature.
        // For testing in editor, we can simulate with Shift key.
        if (Application.isEditor)
        {
            currentPressure = Input.GetKey(KeyCode.Space) ? Mathf.PingPong(Time.time, 1f) : 0f;
        }
        else
        {
            // TODO: Hook up actual OpenXR input reading here
            // currentPressure = inputDevice.GetFeatureValue(CommonUsages.pressure);
        }

        // 2. Read Buttons
        if (Input.GetButtonDown("Fire1")) // Primary tip press
        {
            // Trigger haptic pulse (simulated)
            TriggerHapticPulse(0.5f, 0.1f);
        }
    }

    /// <summary>
    /// Triggers a haptic vibration on the stylus.
    /// </summary>
    /// <param name="intensity">0.0 to 1.0</param>
    /// <param name="duration">Duration in seconds</param>
    public void TriggerHapticPulse(float intensity, float duration)
    {
        // Send haptic command to OpenXR controller
        Debug.Log($"[Haptics] Pulse: {intensity} for {duration}s");
    }
}
