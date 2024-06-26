using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 3f;
    private float jumpHeight = 3f;
    private float gravity = -9.8f;

    public Transform verifyFloor;
    public LayerMask layerMask;

    private float sphereRadius = 0.4f;
    private bool isOnFloor;
    private Vector3 fallSpeed;
    

    public Acceleration acceleration;

    public AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        acceleration = GetComponent<Acceleration>();
        jumpSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        isOnFloor = Physics.CheckSphere(verifyFloor.position, sphereRadius, layerMask);
        
        if(isOnFloor && fallSpeed.y < 0)
        {
            fallSpeed.y = 0f; //Para garantir que o player não vai cair até o infinito e além
        }

        if (!isOnFloor)
        {
            Vector3 move = transform.right * 0f + transform.forward * 2.1f;
            controller.Move(speed * Time.deltaTime * move);

            fallSpeed.y += gravity * Time.deltaTime;

        }

        controller.Move(fallSpeed * Time.deltaTime);

        if (isOnFloor && fallSpeed.y == 0)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        }
    }

    public void JumpForward()
    {
        if (GlobalConfig.Instance.playSoundEffects)
        {
            jumpSound.Play();
        }
            

        fallSpeed.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        controller.Move(Time.deltaTime * fallSpeed);

        Vector3 move = transform.right * 0f + transform.forward * 2.1f;
        controller.Move(speed * Time.deltaTime * move);
        Debug.Log("Position: " + transform.position);
    }

    public bool GetIsOnFloor()
    {
        return isOnFloor;
    }
}