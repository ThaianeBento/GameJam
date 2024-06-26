using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlatforms : MonoBehaviour
{
    private List<Transform> platforms = new();
    private int platformIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i < transform.childCount; i++)
        {
            Transform platform = transform.GetChild(i);
            platform.gameObject.SetActive(false);
            platforms.Add(platform);
            Debug.Log(platform.name);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public List<Transform> GetPlatforms()
    {
        return platforms;
    }

    public void updateIndex()
    {
        platformIndex++;
    }

    public void enableNext()
    {
        platforms[platformIndex].gameObject.SetActive(true);
    }

}
