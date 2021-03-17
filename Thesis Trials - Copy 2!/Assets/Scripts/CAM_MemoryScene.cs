using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAM_MemoryScene : MonoBehaviour
{
    public Camera CAM;
    // Start is called before the first frame update
    void Start()
    {
        CAM.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = CAM.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                print(hit.transform.gameObject.name);
            }
        }
    }
}
