using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public float X_Min;
    public float X_Max;
    public float Y_Min;
    public float Y_Max;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        yaw = Mathf.Clamp(yaw, gameObject.transform.position.x + X_Min, gameObject.transform.position.x + X_Max); //the rotation range
        pitch = Mathf.Clamp(pitch, gameObject.transform.position.y + Y_Min, gameObject.transform.position.y + Y_Max);//the rotation range

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        //transform.localRotation = Quaternion.identity;
    }
}
