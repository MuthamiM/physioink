using UnityEngine;

public class MultiplayerSession : MonoBehaviour
{
    public bool isConnected;

    public void ConnectToRoom(string roomId)
    {
        // Connect via Photon / Normal / NGO
        Debug.Log($"Connecting to Room: {roomId}");
    }

    public void SyncScalpelPosition(Vector3 position, Quaternion rotation)
    {
        // Send network RPC
    }
}
