using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalConfig : MonoBehaviour
{

    public static GlobalConfig Instance;
    public bool playMusic = true;
    public bool playSoundEffects = true;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToggleMusic()
    {
        playMusic = !playMusic;

        if (playMusic)
        {
            Soundtrack.Instance.PlayMusic();
        }
        else
        {
            Soundtrack.Instance.StopMusic();
        }
    }

    public void ToggleSoundEffects()
    {
        playSoundEffects = !playSoundEffects;
    }
}
