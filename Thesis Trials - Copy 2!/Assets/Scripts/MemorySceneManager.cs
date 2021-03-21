using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Fungus;

public class MemorySceneManager : MonoBehaviour
{
    public Camera CAM;

    public Rotator rotator;

    public Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        CAM.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        var SD = SayDialog.GetSayDialog();
        var MD = MenuDialog.GetMenuDialog();
        if ((SD.isActiveAndEnabled == false) && (MD.isActiveAndEnabled == false))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = CAM.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    print(hit.transform.name);
                    Bat_Memory(hit, flowchart, scene);
                    Sewing_Machine_Memory(hit, flowchart, scene);
                }
            }
        }  
    }

    void Bat_Memory(RaycastHit hit, Flowchart flowchart, Scene scene)
    {
        if (hit.transform.name == "Cricket_Bat")
        {
            //Play sound
            //Run dialogues and UI
            flowchart.ExecuteBlock("Bat");
            //rotator.slow = true;
            //rotator.SlowDown(0);
            //rotator.degrees = 0f;
            //Invoke("Resume_Rotation", 4);
        }
    }

    void Sewing_Machine_Memory (RaycastHit hit, Flowchart flowchart, Scene scene)
    {
        if (hit.transform.name == "Sewing_Machine_Reduced")
        {
            //Play sound
            //Run dialogues and UI
            if (hit.transform.name == "Sewing_Machine_Reduced")
            {
                //Play sound
                //Run dialogues and UI
                flowchart.ExecuteBlock("Sewing Machine");
                //Invoke("Resume_Rotation", 4);
            }
        }
    }

    public void Resume_Rotation()
    {
        rotator.degrees = 10.0f;
    }
}