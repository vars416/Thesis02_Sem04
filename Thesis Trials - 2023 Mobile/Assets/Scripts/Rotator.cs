using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float degrees;
    //public bool slow = false;
    public float targetDegrees;
    // Start is called before the first frame update
    void Start()
    {
        targetDegrees = degrees;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(this.transform.position, Vector3.up, degrees * Time.deltaTime);

        UpdateDegrees();
        /*
        if (slow == true)
        {
            SlowDown();
        }
        */
    }

    public void UpdateDegrees()
    {
        degrees = Mathf.Lerp(degrees, targetDegrees, Time.deltaTime * 5);
    }

    public void SetTargetDegreesTo10()
    {
        this.targetDegrees = 10f;
    }

}
