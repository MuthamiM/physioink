using UnityEditor;
using UnityEngine;

public class BuildTools : EditorWindow
{
    [MenuItem("PhysioInk/Build Production")]
    public static void BuildProduction()
    {
        Debug.Log("Building PhysioInk for Quest 3...");
    }
}
