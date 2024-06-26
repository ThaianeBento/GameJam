using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour
{
    public GameObject[] panels;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoBackToMainMenu()
    {
        LevelsManager.Instance.LoadScene(0);
    }

    public void StartCreditsPanel()
    {
        panels[1].SetActive(true);
        panels[0].SetActive(false);
    }

    public void BackToMenuFromCredits()
    {
        panels[0].SetActive(true);
        panels[1].SetActive(false);
    }
}
