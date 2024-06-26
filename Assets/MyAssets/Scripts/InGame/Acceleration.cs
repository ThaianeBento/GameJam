using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    private Jump jumpScript;
    private bool isDetecting = true;

    void Start()
    {
        jumpScript = GetComponent<Jump>();
    }

    void Update()
    {
        /*
        if(Time.frameCount % 60 == 0)
        {
            Vector3 acceleration = Input.acceleration;
            Debug.Log("Acceleration: " + acceleration);
            Debug.Log("Acceleration on Z: " + acceleration.z);
            //Verify on Z vector

            if (acceleration.z > 0.5)
            {
                throw new System.Exception("Acceleration on Z is positive");
            }
        }
        */

        if (isDetecting)
        {
            float z = Input.acceleration.z;
            float x = Input.acceleration.x;
            float y = Input.acceleration.y;

            /**
             * TLDR; Se pula diminui (z < -1), se desce aumenta (z > 0)
             * 
             * Quando o dispositivo está com a tela para cima, o valor de z é -1 quando está parado,
             * positivo (> 0) quando está em queda livre (descendo) e negativo (< -1) quando está subindo.
             * Isso tem relação com a aceleração sofrida pela gravidade, pois o dispositivo sofre uma
             * aceleração constante de 1 G-Force (~9,8 m/s^2) e ao ficar parado há uma resistência que gera uma força
             * contrário "empurrando" o celular de volta pra cima. Os ângulos dos eixos podem ser 
             * entendidos melhor ao pesquisar sobre ângulos de Euler e Quaternions.
             *
            if (z <= -1.3f && Input.deviceOrientation == DeviceOrientation.FaceUp)
            {
                Debug.Log("Current Z: " + z);

                isDetecting = false;
                jumpScript.JumpForward();
            }*/

            /**
             * TLDR; Mesma coisa que acima, porém com o celular de lado e com a tela pro player
             * 
             * O conceito de aceleração nos eixos se mantém como descrito acima, porém devido a
             * rotação de ângulo nos eixos devemos utilizar o que está servido como pivô, nesse 
             * caso o eixo X.
             */
            if (y < -1.5f &&
                (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight))
            {
                Debug.Log("X value: " + x);
                isDetecting = false;
                jumpScript.JumpForward();
            }
        } else
        {
            if(jumpScript.GetIsOnFloor())
            {
                isDetecting = true;
            }
        }

        

    }

    public void SetDetecting(bool detecting)
    {
        this.isDetecting = detecting;
    }
}
