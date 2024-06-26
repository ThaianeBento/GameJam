using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSoundEffects : MonoBehaviour
{
    public GameObject[] images;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleSoundEffects()
    {
        GlobalConfig.Instance.ToggleSoundEffects();
        if (GlobalConfig.Instance.playSoundEffects)
        {
            images[0].SetActive(true);
            images[1].SetActive(false);
        }
        else
        {
            images[0].SetActive(false);
            images[1].SetActive(true);
        }
    }

    public void ToggleMusic()
    {
        GlobalConfig.Instance.ToggleMusic();
        if (GlobalConfig.Instance.playMusic)
        {
            images[2].SetActive(true);
            images[3].SetActive(false);
        }
        else
        {
            images[2].SetActive(false);
            images[3].SetActive(true);
        }
    }
}
