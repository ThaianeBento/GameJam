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
             * Quando o dispositivo est� com a tela para cima, o valor de z � -1 quando est� parado,
             * positivo (> 0) quando est� em queda livre (descendo) e negativo (< -1) quando est� subindo.
             * Isso tem rela��o com a acelera��o sofrida pela gravidade, pois o dispositivo sofre uma
             * acelera��o constante de 1 G-Force (~9,8 m/s^2) e ao ficar parado h� uma resist�ncia que gera uma for�a
             * contr�rio "empurrando" o celular de volta pra cima. Os �ngulos dos eixos podem ser 
             * entendidos melhor ao pesquisar sobre �ngulos de Euler e Quaternions.
             *
            if (z <= -1.3f && Input.deviceOrientation == DeviceOrientation.FaceUp)
            {
                Debug.Log("Current Z: " + z);

                isDetecting = false;
                jumpScript.JumpForward();
            }*/

            /**
             * TLDR; Mesma coisa que acima, por�m com o celular de lado e com a tela pro player
             * 
             * O conceito de acelera��o nos eixos se mant�m como descrito acima, por�m devido a
             * rota��o de �ngulo nos eixos devemos utilizar o que est� servido como piv�, nesse 
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
