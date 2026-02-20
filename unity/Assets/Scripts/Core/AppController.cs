using UnityEngine;

/// <summary>
/// Main application controller. Handles state switching (Menu -> Dissection -> Review).
/// </summary>
public class AppController : MonoBehaviour
{
    public enum AppState { MainMenu, Dissection, FreeExplore, Review }
    public AppState currentState;

    [Header("UI Panels")]
    public GameObject menuPanel;
    public GameObject dissectionHUD;
    public GameObject reviewPanel;

    void Start()
    {
        SetState(AppState.MainMenu);
    }

    public void SetState(AppState newState)
    {
        currentState = newState;
        Debug.Log($"[PhysioInk] Switched to {newState}");

        // Update UI
        menuPanel.SetActive(newState == AppState.MainMenu);
        dissectionHUD.SetActive(newState == AppState.Dissection);
        reviewPanel.SetActive(newState == AppState.Review);

        // Update Tool
        if (newState == AppState.Dissection)
        {
            // Enable Scalpel
        }
        else
        {
            // Enable Pointer
        }
    }
}
