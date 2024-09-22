using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGyroMovement : MonoBehaviour
{

    Vector3 rotationFixCamera;
    private bool gyroEnabled;
    private Gyroscope gyroSensor;
    private Quaternion rot;
    private Transform CameraControlGyro;

    private void Start()
    {
        rot = new Quaternion(0, 0, 1, 0);
        CameraControlGyro = transform.parent;
        CameraControlGyro.position = transform.position;
        updateCameraRotForDevice();

        gyroEnabled = EnableGyro();
    }
    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyroSensor = Input.gyro;
            gyroSensor.enabled = true;
            return true;
        }
        return false;
    }
    private void Update()
    {
        if (gyroEnabled)
        {
            CameraControlGyro.rotation = Quaternion.Euler(rotationFixCamera);
            transform.localRotation = gyroSensor.attitude * rot;
        }

    }

    private Quaternion GyroToUnity(Quaternion gyroQutr)
    {
        return new Quaternion(gyroQutr.x, gyroQutr.y, 0, -gyroQutr.w);
    }

    private void updateCameraRotForDevice()
    {

        //Check if the device running this is a desktop,for using Unity Remote
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {

            rotationFixCamera = new Vector3(90f, 90f, 0f);
        }

        //Check if the device running this is a handheld aka Android device
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {

            rotationFixCamera = new Vector3(0f, 0f, 0f);
        }

    }
}