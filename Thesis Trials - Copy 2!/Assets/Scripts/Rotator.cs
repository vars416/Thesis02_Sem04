using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float degrees;
    public bool slow = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(this.transform.position, Vector3.up, degrees * Time.deltaTime);

        /*if (slow == true)
        {
            SlowDown();
        }*/
    }

    public void SlowDown()
    {
        print("doing");
        degrees = Mathf.Lerp(degrees, 0, Time.deltaTime *50);
        slow = false;
    }
}
