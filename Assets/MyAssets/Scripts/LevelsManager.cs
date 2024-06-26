using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    public static LevelsManager Instance;

    private GameObject mainCanvas;
    public GameObject loaderCanvas;
    public Image progressBar;

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
        mainCanvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(int sceneName)
    {
        progressBar.fillAmount = 0;
        AsyncOperation scene =  SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        //mainCanvas.SetActive(false);
        //loaderCanvas.SetActive(true);
        do
        {
            progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, scene.progress, 2 * Time.deltaTime);
        }
        while (scene.progress < 0.9f);

        scene.allowSceneActivation = true;
        //loaderCanvas.SetActive(false);
        //mainCanvas.SetActive(true);

    }
}
