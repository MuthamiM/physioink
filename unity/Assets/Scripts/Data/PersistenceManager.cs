using UnityEngine;
using System.IO;

public class PersistenceManager : MonoBehaviour
{
    public void SaveProgress(string studentId, float score)
    {
        // Save to JSON
        string path = Application.persistentDataPath + "/progress.json";
        string json = JsonUtility.ToJson(new { id = studentId, score = score });
        File.WriteAllText(path, json);
    }

    public void LoadProgress()
    {
        // Load from JSON
    }
}
