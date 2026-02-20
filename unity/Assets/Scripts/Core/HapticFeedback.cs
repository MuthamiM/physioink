using UnityEngine;

/// <summary>
/// Helper for generating haptic patterns on the MX Ink stylus.
/// </summary>
public static class HapticFeedback
{
    public static void PulseCut(float intensity)
    {
        // Sharp, short pulse for cutting
        MXInkManager.Instance.TriggerHapticPulse(intensity, 0.05f);
    }

    public static void PulseBoneHit()
    {
        // Hard, jarring pulse for hitting bone
        MXInkManager.Instance.TriggerHapticPulse(1.0f, 0.1f);
    }

    public static void PulseTissueDrag(float drag)
    {
        // Continuous, low-intensity rumble for dragging through tissue
        MXInkManager.Instance.TriggerHapticPulse(drag * 0.3f, 0.1f);
    }
    
    public static void PulseSuccess()
    {
        // Double tap for success
        MXInkManager.Instance.TriggerHapticPulse(0.8f, 0.1f);
        // In a real coroutine, we'd wait and pulse again
    }
}
