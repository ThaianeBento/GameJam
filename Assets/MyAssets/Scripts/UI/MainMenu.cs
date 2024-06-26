using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject[] panels;
    private bool isMainMenu = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartToNextScene()
    {
        if (isMainMenu)
        {
            LevelsManager.Instance.LoadScene(1);
        }
        
    }

    public void ConfigButtonTest()
    {
         Debug.Log("Config Button Test");
    }

    public void StartInstructionsPanel()
    {
        if (isMainMenu) {
            panels[2].SetActive(true);
            panels[0].SetActive(false);
        }
        
        
    }

    public void BackToMenuFromInstructions()
    {
        panels[0].SetActive(true);
        panels[2].SetActive(false);

    }

    public void StartCreditsPanel()
    {
        panels[3].SetActive(true);
        panels[0].SetActive(false);
    }

    public void BackToMenuFromCredits()
    {
        panels[0].SetActive(true);
        panels[3].SetActive(false);
    }

    public void PopUpConfigPanel()
    {
        isMainMenu = false;
        panels[1].SetActive(true);
    }

    public void CloseConfigPanel()
    {
        isMainMenu = true;
        panels[1].SetActive(false);   
    }
}
