using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnStartSimulation()
    {
        AppController.Instance.SetState(AppController.AppState.Dissection);
    }

    public void OnOpenSettings()
    {
        // Open Settings Panel
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
