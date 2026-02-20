using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Clips")]
    public AudioClip cutSound;
    public AudioClip errorSound;
    public AudioClip successSound;

    private AudioSource _source;

    void Awake()
    {
        Instance = this;
        _source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip) _source.PlayOneShot(clip);
    }
}
