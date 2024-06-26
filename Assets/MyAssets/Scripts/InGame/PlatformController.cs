using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private LoadPlatforms loadPlatforms;

    private float currentTime;
    private bool isTimerOn = false;
    private BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        loadPlatforms = transform.parent.GetComponent<LoadPlatforms>();
        currentTime = 10f;
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(1f, 1.45f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerOn)
            Timer();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        loadPlatforms.enableNext();
        isTimerOn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        loadPlatforms.updateIndex();
        gameObject.SetActive(false);
    }

    private void Timer()
    {
        Debug.Log("Time: " + currentTime);
        if(currentTime > 0 && Time.frameCount % 60 == 0)
        {
            currentTime -= Time.deltaTime;
        }

        if(currentTime <= 0)
        {
            gameObject.SetActive(false);
        }
    }


}
