using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCam : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;
    private Quaternion initialRotation;

    private void Start()
    {
        gyroEnabled = EnableGyro();
        initialRotation = gyro.attitude;
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            return true;
        }
        return false;
    }
    private void Update()
    {
        /*if (gyroEnabled)
        {

            Quaternion gyroRotation = Input.gyro.attitude;

            // Converte a rotação do giroscópio do espaço do dispositivo para o espaço do mundo do Unity

            // Aplica a rotação à câmera
            transform.localRotation = ConvertRotation(gyro.attitude);

        }*/

        if (gyroEnabled)
        {
            /* transform.parent.rotation = Quaternion.Euler(0f, 90f, 90f);
             Quaternion rot = new Quaternion(0, 0, 1, 0);
             transform.localRotation = gyro.attitude * rot;
            */
            transform.localRotation = Quaternion.Slerp(transform.localRotation, ConvertRotation(gyro.attitude), 10f);

            //transform.localRotation = Quaternion.Euler(gyro.attitude.eulerAngles.y, gyro.attitude.eulerAngles.z, -gyro.attitude.eulerAngles.x);
        }
    }

    private static Quaternion ConvertRotation(Quaternion q)
    {
        return new Quaternion(0.5f, 0.5f, -0.5f, 0.5f) * new Quaternion(q.x, q.y, -q.z, -q.w) * Quaternion.Euler(0, 0, 90);
        //return new Quaternion(q.y, -q.z, q.x, q.w);// * new Quaternion(0.5f, 0f, 0f, 0f);
    }
}
