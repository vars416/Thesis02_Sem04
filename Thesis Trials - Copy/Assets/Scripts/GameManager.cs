using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using UnityEngine;
using Fungus;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //Creating static instance of GameManager

    public Flowchart flowchart; //Add Fungus flowchart

    private Scene scene;

    public GameObject CAM1; //Camera 1
    public GameObject CAM2; //Camera 2

    public GameObject[] CAMholderPos;
    //List<GameObject> CAMPos = new List<GameObject>();

    AudioListener CAM1aud1; //Audio listener for camera 1
    AudioListener CAM2aud2; //Audio listener for camera 2

    int clickcounter = 0;

    public GameObject flowerpot;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; //set instance to this object
            //DontDestroyOnLoad(gameObject); //Don't Destroy this object
        }
        else
        {
            Destroy(gameObject); //if another instance is present then destroy this instance
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        CAM1aud1 = CAM1.GetComponent<AudioListener>(); //get and set audio listeners to their respective cameras
        CAM2aud2 = CAM2.GetComponent<AudioListener>();

        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition")); //Get position of main camera

        flowerpot.GetComponent<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {

        Scene scene = SceneManager.GetActiveScene();

        if (Input.GetMouseButtonDown(0)) //if lmb is down
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //hit raycast from screen/mouse pointer to wherever player is clicking
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                DeskInteractions(hit, flowchart, scene);

                ShelfInteractions(hit, flowchart, scene);

                BedInterations(hit, flowchart, scene);

                CupboardInteractions(hit, flowchart, scene);

                TempleInteractions(hit, flowchart, scene);

                ObjectInteractions(hit, flowchart, scene);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            cameraChangeCounter2(); //if rmb is pressed, go back to camera 2
        }

        if (Input.GetKey(KeyCode.C))
        {
            CallingMaid(clickcounter, flowchart, scene);
        }

        if (Input.GetKey(KeyCode.H))
        {
            flowchart.ExecuteBlock("Help1");
        }

        CounterMaintain();
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 20;
        GUI.Label(new Rect(40, 20, 200, 150), "MOMENTS COLLECTED: " + clickcounter, style);
    }

    void CameraHolding(int j)
    {
        for (int i = 0; i < CAMholderPos.Length; i++)
        {
            if (i == j)
            {
                CAM2.transform.position = CAMholderPos[i].transform.position;
                CAM2.transform.rotation = CAMholderPos[i].transform.rotation;
                cameraChangeCounter();
                print(CAMholderPos[i].name);
                //break;
            }
        }
    }

    void DeskInteractions (RaycastHit hit, Flowchart flowchart, Scene scene)
    {
        if ((hit.transform.tag == "interact") && (hit.transform.name == "Desk")) //if ray hits a gameobject with transform having the tag "interact"
        {
            CameraHolding(0);

            if ((scene.name == "First_Scene"))
            {
                flowchart.ExecuteBlock("Desk1"); //do this
            }

            if (scene.name == "Puzzle_Scene")
            {
                flowchart.ExecuteBlock("Audio_Shelf"); //execute this block in Fungus flowchart only if the particular scene is playing
            }
        }
    }

    void ShelfInteractions (RaycastHit hit, Flowchart flowchart, Scene scene)
    {
        if ((hit.transform.tag == "interact") && (hit.transform.name == "Shelf"))
        {
            CameraHolding(1);

            if (scene.name == "First_Scene")
            {

            }

            if (scene.name == "Puzzle_Scene")
            {
                flowchart.ExecuteBlock("Audio_Shelf3");
            }
        }
    }

    void BedInterations (RaycastHit hit, Flowchart flowchart, Scene scene)
    {
        if ((hit.transform.tag == "interact") && (hit.transform.name == "Bed"))
        {
            CameraHolding(2);

            if ((scene.name == "First_Scene"))
            {
                flowchart.ExecuteBlock("Bed1");
            }

            if (scene.name == "Puzzle_Scene")
            {
                flowchart.ExecuteBlock("Audio_Shelf2");
            }
        }
    }

    void CupboardInteractions(RaycastHit hit, Flowchart flowchart, Scene scene)
    {
        if ((hit.transform.tag == "interact") && (hit.transform.name == "Cupboard"))
        {
            /*CAM2.transform.position = CAMholder4.transform.position;
            CAM2.transform.rotation = CAMholder4.transform.rotation;
            cameraChangeCounter();*/

            CameraHolding(3);

            if ((scene.name == "First_Scene"))
            {
                flowchart.ExecuteBlock("Cupboard1");
            }
        }
    }

    void TempleInteractions (RaycastHit hit, Flowchart flowchart, Scene scene)
    {
        if ((hit.transform.tag == "interact") && (hit.transform.name == "Temple"))
        {
            CameraHolding(4);

            if ((scene.name == "First_Scene"))
            {
                flowchart.ExecuteBlock("Temple1");
            }
        }
    }

    void ObjectInteractions(RaycastHit hit, Flowchart flowchart, Scene scene)
    {
        if ((hit.transform.tag == "object") && (CAM2.activeInHierarchy == true)) //if ray hits a gameobject with transform having the tag "object"
        {

            if (scene.name == "First_Scene")
            {
                if (hit.transform.name == "Rubber Stamp1")
                {
                    clickcounter++;
                    flowchart.ExecuteBlock("Stamp1");
                }

                if (hit.transform.name == "Photograph1")
                {
                    clickcounter++;
                    flowchart.ExecuteBlock("Photo1");
                }

                if (hit.transform.name == "Bell1")
                {
                    clickcounter++;
                    flowchart.ExecuteBlock("Bell1");
                }

                if (hit.transform.name == "Orchids")
                {
                    clickcounter++;
                    flowchart.ExecuteBlock("Flowers1");
                    flowerpot.SetActive(false);
                }

                if (hit.transform.name == "Herbarium_Book")
                {
                    clickcounter++;
                    flowchart.ExecuteBlock("Herbarium1");
                }
            }

            if (scene.name == "Puzzle_Scene")
            {
                flowchart.ExecuteBlock("Frieda_Test"); //execute this block in Fungus flowchart
            }
        }
    }

    void CallingMaid (int clickcounter, Flowchart flowchart, Scene scene)
    {
        if (clickcounter >= 5 && (scene.name == "First_Scene") && (CAM2.activeInHierarchy == false))
        {
            flowchart.ExecuteBlock("CallNajma1");
        }

        if (clickcounter >= 5 && (scene.name == "First_Scene") && (CAM2.activeInHierarchy == true))
        {
            flowchart.ExecuteBlock("CallNajma2");
        }
    }

    void cameraChangeCounter() //counter for jumping to zoomed view
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition"); //Get integer for camera position from Player Preferences and set it equal to camera position counter
        cameraPositionCounter++; //increase that int
        cameraPositionChange(cameraPositionCounter); //set camera postion to that increased int
    }

    void cameraChangeCounter2() //counter for coming back to original view
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange2(cameraPositionCounter);
    }

    void cameraPositionChange(int camPosition)
    {
        if (camPosition > 1) 
        {
            camPosition = 0;
        }

        if (camPosition == 0)
        {
            CAM1.SetActive(true);
            CAM1aud1.enabled = true;

            CAM2.SetActive(false);
            CAM2aud2.enabled = false;
        }

        if (camPosition == 1)
        {
            CAM2.SetActive(true);
            CAM2aud2.enabled = true;

            CAM1.SetActive(false);
            CAM1aud1.enabled = false;
        }
    }

    void cameraPositionChange2(int camPosition)
    {
        if (camPosition > 1)
        {
            camPosition = 0;
        }

        if (camPosition == 0)
        {
            CAM2.SetActive(true);
            CAM2aud2.enabled = true;

            CAM1.SetActive(false);
            CAM1aud1.enabled = false;
        }

        if (camPosition == 1)
        {
            CAM1.SetActive(true);
            CAM1aud1.enabled = true;

            CAM2.SetActive(false);
            CAM2aud2.enabled = false;
        }
    }

    void CounterMaintain ()
    {
        if (clickcounter >= 5)
        {
            clickcounter = 5;
        }
    }
}
