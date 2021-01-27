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

    AudioListener CAM1aud1; //Audio listener for camera 1
    AudioListener CAM2aud2; //Audio listener for camera 2

    int clickcounter = 0;

    public GameObject flowerpot;

    public UIManager ui;
    public AudioPlayer audioplay;

    public GameObject MusicPlayer;

    public bool counterbool = false;
    public bool BellBool = false;
    public bool TutorialBool = false;
    public bool Scene1Music = false;
    public bool MemoryBool = false;
    public bool KrishBool = false;
    public bool PhotoBool = false;
    public bool StampBool = false;

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

        MusicPlayer.SetActive(false);

        audioplay = audioplay.GetComponent<AudioPlayer>();

        MemoryBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        var SD = SayDialog.GetSayDialog();
        if (SD.isActiveAndEnabled == false) 
        {
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

                    GramophoneInteractions(hit, flowchart, scene);

                    ObjectInteractions(hit, flowchart, scene);
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                cameraChangeCounter2(); //if rmb is pressed, go back to camera 2
                MusicPlayer.SetActive(false);
                Color temp = ui.Bell1.color;
                Color temp2 = ui.Bell2.color;
                temp.a = 0.1f;
                ui.Bell1.color = temp;
                temp2.a = 0.1f;
                ui.Bell2.color = temp2;

                if (scene.name == "Puzzle_Scene")
                {
                    ui.Feroz.enabled = (false);
                    ui.Frieda.enabled = (false);
                    ui.Meher.enabled = (false);
                    ui.TutorialText.text = "";
                }
                if (scene.name == "First_Scene")
                {
                    DisableBabyHerbarium();
                    ui.TutorialText.text = "";
                }
            }
        }

        if (Input.GetKey(KeyCode.C))
        {
            CallingMaid(clickcounter, flowchart, scene);
        }

        if (Input.GetKey(KeyCode.H))
        {
            flowchart.ExecuteBlock("Help1");
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (scene.name == "First_Scene")
            {
                ui.RingOpaque1();
                ui.HerbariumPopUp();
                ui.TutorialText.fontSize = 12;
                ui.TutorialText.text = "You are here in a stifling afternoon of 1966. But Frieda's time in this room extends several periods. These are arcs of time that will help keep track of the period of time attached to a moment, or memory.";
            }

            if (scene.name == "Puzzle_Scene")
            {
                ui.RingOpaque2();
            }
        }
        else if (Input.GetKeyUp(KeyCode.I))
        {
            if ((scene.name == "First_Scene") || (scene.name == "Puzzle_Scene"))
            {
                ui.RingStarting(scene);
            }
            if (scene.name == "First_Scene")
            {
                ui.HerbariumPopDown();
                ui.TutorialText.text = "";
            }
        }

        ui.CounterText.text = clickcounter.ToString();
        CounterMaintain();
        CounterBools();
        if ((ui.TutorialText.text == "") && (ui.Baby_Herbarium.enabled == true) && (CAM1.activeInHierarchy == true) && (TutorialBool == false))
        {
            //ui.TutorialText.fontSize = 12;
            ui.TutorialText.text = "Hold down 'I' to see which time period you are currently in";
            //ui.TutorialText.text = "You are here in a stifling afternoon of 1966. But Frieda's time in this room extends several periods. These are arcs of time that will help keep track of the period of time attached to a moment, or memory. Hold down 'I' to see which time period you are currently in";
            Invoke("ClearTutorialText", 4);
            TutorialBool = true;
        }
    }

    /*void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 20;
        GUI.Label(new Rect(40, 20, 200, 150), "MOMENTS COLLECTED: " + clickcounter, style);
    }*/

    void EnableBaby ()
    {
        ui.Baby_Herbarium.enabled = true;
    }

    void DisableBabyHerbarium ()
    {
        if ((ui.Herbarium.enabled == true) && (CAM1.activeInHierarchy == true))
        {
            Color temp = ui.Herbarium.color;
            temp.a = 0.1f;
            ui.Herbarium.color = temp;

            Color temp2 = ui.Baby_Herbarium.color;
            temp2.a = 0.1f;
            ui.Baby_Herbarium.color = temp;
        }
        
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
                ui.BellUpDown2();
                flowchart.ExecuteBlock("Audio_Shelf3");
                ui.FriedaDialogue();
                MusicPlayer.SetActive(true);
                ui.TutorialText.text = "Listen closely to what they are saying... And then play the audio snippet. The Bells are sounds that tell you that what is important to Frieda is near.";
                //ui.TutorialText.text = "Listen closely to what they are saying... And then play the audio snippet to get a clue to the object you are searching for";
                /*if (*//*(audioplay.IsPlaying == false) && *//* (MemoryBool == false))
                {
                    MemoryBool = true;
                    print("wtf");
                }*/
                /*if (MemoryBool == false)
                {

                }*/
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
                ui.MeherDialogue();
                ui.TutorialText.text = "Listen closely to what they are saying...";
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

            if (scene.name == "Puzzle_Scene")
            {
                flowchart.ExecuteBlock("Audio_Shelf");
                ui.FerozDialogue();
                if ((MemoryBool == false))
                {
                    MemoryBool = true;
                    //print("wtf");
                }
                ui.TutorialText.text = "Listen closely to what they are saying...";
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

    void GramophoneInteractions (RaycastHit hit, Flowchart flowchart, Scene scene)
    {
        if ((hit.transform.tag == "interact") && (hit.transform.name == "Gramophone"))
        {
            CameraHolding(5);
        }

        if ((scene.name == "First_Scene") && (hit.transform.name == "Gramophone") && (CAM2.activeInHierarchy == true))
        {
            MusicPlayer.SetActive(true);
            //ui.Bell1.enabled = true;
            Color temp = ui.Bell1.color;
            Color temp2 = ui.Bell2.color;
            temp.a = 1.0f;
            ui.Bell1.color = temp;
            temp2.a = 1.0f;
            ui.Bell2.color = temp2;
            ui.BellUpDown1();
            if ((audioplay.IsPlaying == true) && (ui.Herbarium.enabled == true) && (Scene1Music == false))
            {
                flowchart.ExecuteBlock("Temple2");
                Scene1Music = true;
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
                    //clickcounter++;
                    BoolTrigger4();
                    flowchart.ExecuteBlock("Stamp1");
                }

                if (hit.transform.name == "Photograph1")
                {
                    //clickcounter++;
                    BoolTrigger3();
                    flowchart.ExecuteBlock("Photo1");
                }

                if (hit.transform.name == "Bell1")
                {
                    //clickcounter++;
                    BoolTrigger();
                    flowchart.ExecuteBlock("Bell1");
                }

                if ((hit.transform.name == "Orchids") && (ui.Herbarium.enabled == true))
                {
                    clickcounter++;
                    flowchart.ExecuteBlock("Flowers1");
                    flowerpot.SetActive(false);
                }

                if (hit.transform.name == "Herbarium_Book")
                {
                    //clickcounter++;
                    counterbool = true;
                    flowchart.ExecuteBlock("Herbarium1");
                    ui.Herbarium.enabled = true;
                    ui.Bell1.enabled = true;
                    Invoke("EnableBaby", 2);
                    ui.TutorialText.fontSize = 12;
                    ui.TutorialText.text = "The Herbarium is the archive of what Frieda has kept. It holds names and traces of the most important pieces of her life. The Counter number showing up on the bookmark shows you the number of memories you have collected.";
                    
                }

                if (hit.transform.name == "Krishna_OBJ")
                {
                    //clickcounter++;
                    BoolTrigger2();
                    flowchart.ExecuteBlock("Krishna1");
                }
            }

            if (scene.name == "Puzzle_Scene")
            {
                if ((hit.transform.name == "Ticket") /*&& (MemoryBool == true) && (audioplay.IsPlaying == false)*/)
                {
                    if (MemoryBool == false)
                    {
                        ui.TutorialText.text = "You are still missing some clues, listen to the other audio tracks in the room and then come back";
                    }
                    if ((MemoryBool == true) && (audioplay.IsPlaying == false))
                    {
                        flowchart.ExecuteBlock("Frieda_Test"); //execute this block in Fungus flowchart
                        Invoke("MemoryComing", 5);
                    }
                }
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

    void CounterBools ()
    {
        if (counterbool == true)
        {
            ui.CounterText.enabled = true;
        }
    }

    void BoolTrigger ()
    {
        if ((BellBool == false))
        {
            clickcounter++;
            BellBool = true;
        }
    }

    void BoolTrigger2 ()
    {
        if (KrishBool == false)
        {
            clickcounter++;
            KrishBool = true;
        }
    }

    void BoolTrigger3 ()
    {
        if (PhotoBool == false)
        {
            clickcounter++;
            PhotoBool = true;
        }
    }

    void BoolTrigger4 ()
    {
        if (StampBool == false)
        {
            clickcounter++;
            StampBool = true;
        }
    }

    void MemoryComing ()
    {
        ui.MemoryAppear();
        MusicPlayer.SetActive(false);
    }

    void ClearTutorialText ()
    {
        ui.TutorialText.text = "";
    }
}
