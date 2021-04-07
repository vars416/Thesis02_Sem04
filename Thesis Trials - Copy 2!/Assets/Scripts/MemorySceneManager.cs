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

    public Image Slot1;
    public Image Slot2;
    public Image Slot3;

    public Light[] SpotLights;
    //float intensity = 1.0f;
    public bool lighter = false;

    private bool trigger1 = false;
    private bool trigger2 = false;
    private bool trigger3 = false;

    // Start is called before the first frame update
    void Start()
    {
        CAM.GetComponent<Camera>();

        Slot1.GetComponent<Transform>();
        Slot2.GetComponent<Transform>();
        Slot3.GetComponent<Transform>();
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
                    Degree_Memory(hit, flowchart, scene);
                }
            }
        }

        ContinueButton();
        //HitBlinkingLight();
    }

    void Bat_Memory(RaycastHit hit, Flowchart flowchart, Scene scene)
    {
        if (hit.transform.name == "Cricket_Bat")
        {
            //Play sound
            //Run dialogues and UI
            flowchart.ExecuteBlock("Bat");
            rotator.targetDegrees = 0f;
            HitBlinkingLight();
            trigger1 = true;
        }
    }

    void Sewing_Machine_Memory (RaycastHit hit, Flowchart flowchart, Scene scene)
    {
        if (hit.transform.name == "Sewing_Machine_Reduced")
        {
            //Play sound
            //Run dialogues and UI
            flowchart.ExecuteBlock("Sewing Machine");
            rotator.targetDegrees = 0f;
            HitBlinkingLight();
            trigger2 = true;
        }
    }

    void Degree_Memory(RaycastHit hit, Flowchart flowchart, Scene scene)
    {
        if (hit.transform.name == "Degree")
        {
            //Play sound
            //Run dialogues and UI
            flowchart.ExecuteBlock("Degree");
            rotator.targetDegrees = 0f;
            HitBlinkingLight();
            trigger3 = true;
        }
    }

    public void Resume_LightAnim()
    {
        for (int i = 0; i < SpotLights.Length; i++)
        {
            if (SpotLights[i].GetComponent<Animator>().enabled == false)
            {
                SpotLights[i].GetComponent<Animator>().enabled = true;
                print("Anim working");
            }
            //SpotLights[i].intensity = 0.5f;
        }
    }

    void ContinueButton ()
    {
        if ((trigger1 == true) && (trigger2 == true) && (trigger3 == true) /*&& (flowchart.isActiveAndEnabled == false)*/)
        {
            flowchart.ExecuteBlock("Continue");
        }
    }

    public void OnPressContinue ()
    {
        SceneManager.LoadScene(3);
        flowchart.ExecuteBlock("Fade_Out");
    }

    void HitBlinkingLight ()
    {
        for (int i = 0; i < SpotLights.Length; i++)
        {
            SpotLights[i].GetComponent<Animator>().enabled = false;
            SpotLights[i].intensity = 0.5f;
        }
    }


}