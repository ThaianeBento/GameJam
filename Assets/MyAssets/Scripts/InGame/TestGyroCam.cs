using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGyroCam : MonoBehaviour
{
    private bool gyroEnabled = true;
    private const float lowPassFilterFactor = 0.2f;

    private readonly Quaternion baseIdentity = Quaternion.Euler(90, 0, 0);

    private Quaternion cameraBase = Quaternion.identity;
    private Quaternion calibration = Quaternion.identity;
    private Quaternion baseOrientation = Quaternion.Euler(90, 0, 0);
    private Quaternion baseOrientationRotationFix = Quaternion.identity;

    private Quaternion referanceRotation = Quaternion.identity;
    private readonly bool debug = false;

    public Transform transformPlayer;

    protected void Start()
    {
        AttachGyro();
    }

    protected void Update()
    {
        if (!gyroEnabled)
            return;
        Quaternion destinyRotation = cameraBase * (ConvertRotation(referanceRotation * Input.gyro.attitude) * GetRotFix());
        transform.rotation = Quaternion.Slerp(transform.rotation,
           destinyRotation, lowPassFilterFactor);
        transformPlayer.rotation = Quaternion.Euler(Vector3.up * destinyRotation.eulerAngles.y);
    }

    protected void OnGUI()
    {
        if (!debug)
            return;

        GUILayout.Label("Orientation: " + Screen.orientation);
        GUILayout.Label("Calibration: " + calibration);
        GUILayout.Label("Camera base: " + cameraBase);
        GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude);
        GUILayout.Label("transform.rotation: " + transform.rotation);

        if (GUILayout.Button("On/off gyro: " + Input.gyro.enabled, GUILayout.Height(100)))
        {
            Input.gyro.enabled = !Input.gyro.enabled;
        }

        if (GUILayout.Button("On/off gyro controller: " + gyroEnabled, GUILayout.Height(100)))
        {
            if (gyroEnabled)
            {
                DetachGyro();
            }
            else
            {
                AttachGyro();
            }
        }

        if (GUILayout.Button("Update gyro calibration (Horizontal only)", GUILayout.Height(80)))
        {
            UpdateCalibration(true);
        }

        if (GUILayout.Button("Update camera base rotation (Horizontal only)", GUILayout.Height(80)))
        {
            UpdateCameraBaseRotation(true);
        }

        if (GUILayout.Button("Reset base orientation", GUILayout.Height(80)))
        {
            ResetBaseOrientation();
        }

        if (GUILayout.Button("Reset camera rotation", GUILayout.Height(80)))
        {
            transform.rotation = Quaternion.identity;
        }
    }

    private void AttachGyro()
    {
        gyroEnabled = true;
        Input.gyro.enabled = true;
        ResetBaseOrientation();
        UpdateCalibration(true);
        UpdateCameraBaseRotation(true);
        RecalculateReferenceRotation();
    }

    private void DetachGyro()
    {
        gyroEnabled = false;
    }

    private void UpdateCalibration(bool onlyHorizontal)
    {
        if (onlyHorizontal)
        {
            var fw = (Input.gyro.attitude) * (-Vector3.forward);
            fw.z = 0;
            if (fw == Vector3.zero)
            {
                calibration = Quaternion.identity;
            }
            else
            {
                calibration = (Quaternion.FromToRotation(baseOrientationRotationFix * Vector3.up, fw));
            }
        }
        else
        {
            calibration = Input.gyro.attitude;
        }
    }

    private void UpdateCameraBaseRotation(bool onlyHorizontal)
    {
        if (onlyHorizontal)
        {
            var fw = transform.forward;
            fw.y = 0;
            if (fw == Vector3.zero)
            {
                cameraBase = Quaternion.identity;
            }
            else
            {
                cameraBase = Quaternion.FromToRotation(Vector3.forward, fw);
            }
        }
        else
        {
            cameraBase = transform.rotation;
        }
    }

    
    private static Quaternion ConvertRotation(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

    
    private Quaternion GetRotFix()
    {
        return Quaternion.identity;
    }

    private void ResetBaseOrientation()
    {
        baseOrientationRotationFix = GetRotFix();
        baseOrientation = baseOrientationRotationFix * baseIdentity;
    }

   
    private void RecalculateReferenceRotation()
    {
        referanceRotation = Quaternion.Inverse(baseOrientation) * Quaternion.Inverse(calibration);
    }
}
