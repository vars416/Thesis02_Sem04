﻿using System.Collections;
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

    public CameraController camControl;
    //public Camera RTCam;
    //public GameObject CAM1; //Camera 1
    //public GameObject CAM2; //Camera 2

    //public GameObject[] CAMholderPos;

    //AudioListener CAM1aud1; //Audio listener for camera 1
    //AudioListener CAM2aud2; //Audio listener for camera 2

    //public RenderTexture rt1;
    //public RenderTexture rt2;

    //int clickcounter = 0;

    public GameObject flowerpot;

    [SerializeField]
    private GameObject Tiffin;

    public GameObject closed_book;
    public GameObject open_book;

    public UIManager ui;
    public UITrial2 ui2;
    public AudioPlayer audioplay;

    public GameObject MusicPlayer;

    public Clocks clocks;

    public GameObject[] InteractiveFurniture;

    public AudioSource Walking1;
    public AudioSource Walking2;

    //private int layermask = 5;
    //public bool counterbool = false;
    //public bool MemoryBool = false;

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
        //CAM1aud1 = CAM1.GetComponent<AudioListener>(); //get and set audio listeners to their respective cameras
        //CAM2aud2 = CAM2.GetComponent<AudioListener>();

        //cameraPositionChange(PlayerPrefs.GetInt("CameraPosition")); //Get position of main camera

        flowerpot.GetComponent<GameObject>();

        MusicPlayer.SetActive(false);

        //audioplay = audioplay.GetComponent<AudioPlayer>();

        //MemoryBool = false;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Current scene cam is " + camControl.currentSceneCam.name);
        Scene scene = SceneManager.GetActiveScene();

        var SD = SayDialog.GetSayDialog();
        var MD = MenuDialog.GetMenuDialog();
        if ((SD.isActiveAndEnabled == false) && (MD.isActiveAndEnabled == false) && (flowchart.GetExecutingBlocks().Count == 0)) //If there is no dialogue, no menu and no fungus blocks executing at this moment
        {
            if (Input.GetMouseButtonDown(0)) //if lmb is down
            {
                Ray ray = camControl.currentSceneCam.ScreenPointToRay(Input.mousePosition); //hit raycast from center of the screen to wherever player is clicking (mouse pointer)
                //Debug.Log(Camera.main.transform.gameObject.name);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Interact"))) //Check if raycast is hitting anything in the layer "Interact"
                {
                    Debug.Log(hit.transform.name);

                    DeskInteractions(hit, flowchart, scene);

                    ShelfInteractions(hit, flowchart, scene);

                    BedInteractions(hit, flowchart, scene);

                    CupboardInteractions(hit, flowchart, scene);

                    TempleInteractions(hit, flowchart, scene);

                    BedsideTableInteraction(hit, flowchart, scene);

                    ObjectInteractions(hit, flowchart, scene);

                    /*if (hit.transform.gameObject.layer != 10)
                    {

                    }*/

                    /*else if (hit.transform.gameObject.layer == 5)
                    {

                    }*/

                }
            }

            if (Input.GetKey(KeyCode.H))
            {
                flowchart.ExecuteBlock("Help1");
            }

            /*if (Input.GetMouseButtonDown(1))
            {
                //cameraPositionChange(0);
                //cameraChangeCounter();
                //cameraChangeCounter2(); //if rmb is pressed, go back to camera 2
                camControl.ReturnCamPositionOnBack();
                ColliderEnabler();
                
                //MusicPlayer.SetActive(false);
                //audioplay.PauseSound();

                if (scene.name == "Puzzle_Scene")
                {
                    ui.Feroz.enabled = (false);
                    ui.Frieda.enabled = (false);
                    ui.Meher.enabled = (false);
                    ui.TutorialText.text = "";
                }
                *//*if (scene.name == "First_Scene")
                {
                    DisableUI_Herbarium();
                }*//*
            }*/
            
        }
        BackButtonEnabler();

        /*if (Input.GetKeyDown(KeyCode.I))
        {
            if (scene.name == "First_Scene")
            {
                ui.RingOpaque1();
                if (clocks.HerbSwitch == true)
                {
                    ui.HerbariumPopUp();
                }
                flowchart.ExecuteBlock("Time Period Tutorial"); //show ring tutorial
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
                flowchart.StopBlock("Time Period Tutorial");
            }
        }*/

        /*if ((ui.Herbarium.enabled == true) && (CAM1.activeInHierarchy == true) && (TutorialBool == false))
        {
            TutorialBool = true;
            flowchart.ExecuteBlock("Ring Tutorial"); //Show Ring tutorial
        }*/

        /*if ((ui.Herbarium.enabled == true) && (ui.Memory_Herbarium.enabled == true))
        {
            ui.UI_Horse();
            //flowchart.ExecuteBlock("Horse1"); //show Horse dialogues
        }*/


    }

    /*void RayCast_Ignore_UI(RaycastHit hit, Ray ray)
    {
        if (Physics.Raycast(ray, out hit, layermask))
        {

        }
    }*/

    /*void DisableUI_Herbarium()
    {
        if ((ui.Herbarium.enabled == true) && (camControl.currentSceneCam == camControl.sceneCams[0]))
        {
            Color temp = ui.Herbarium.color;
            temp.a = 0.1f;
            ui.Herbarium.color = temp;

            Color temp3 = ui.Feroz_Wedding_Full.color;
            temp3.a = 0.1f;
            ui.Feroz_Wedding_Full.color = temp3;

            ui.Herbarium_Button_Down();
        }

    }*/

    //void CameraHolding(int j)
    //{
    //    for (int i = 0; i < CAMholderPos.Length; i++)
    //    {
    //        if (i == j)
    //        {
    //            CAM2.transform.position = CAMholderPos[i].transform.position;
    //            CAM2.transform.rotation = CAMholderPos[i].transform.rotation;
    //            cameraChangeCounter();
    //            print(CAMholderPos[i].name);
    //            //camerafade2.RedoFade();
    //            //break;
    //        }
    //    }
    //}

    void DeskInteractions(RaycastHit hit, Flowchart flowchart, Scene scene)
    {
        if (scene.name == "First_Scene")
        {
            if ((hit.transform.tag == "interact") && (hit.transform.name == "Desk")) //if ray hits a gameobject with transform having the tag "interact"
            {
                //Debug.Log("Registering Desk condition");
                //CameraHolding(0);
                camControl.SetCamPosition(0);
                Walking1.Play();
                ColliderDisabler(hit);

                //flowchart.ExecuteBlock("Desk1"); //do this
            }
        }

        if (scene.name == "Sec_Scene")
        {
            if ((hit.transform.tag == "interact") && (hit.transform.name == "Stool")) //if ray hits a gameobject with transform having the tag "interact"
            {
                //Debug.Log("Registering Desk condition");
                //CameraHolding(0);
                camControl.SetCamPosition(0);
                Walking1.Play();
                ColliderDisabler(hit);
                Tiffin.gameObject.layer = 9;

                //flowchart.ExecuteBlock("Desk1"); //do this
            }
            //flowchart.ExecuteBlock("Audio_Shelf"); //execute this block in Fungus flowchart only if the particular scene is playing
        }
    }

    void ShelfInteractions(RaycastHit hit, Flowchart flowchart, Scene scene)
    {
        if ((hit.transform.tag == "interact") && (hit.transform.name == "Shelf"))
        {
            //CameraHolding(1);
            camControl.SetCamPosition(1);
            Walking1.Play();
            ColliderDisabler(hit);

            if (scene.name == "First_Scene")
            {

            }

            /*if (scene.name == "Puzzle_Scene")
            {
                //ui.BellUpDown2(); //show bell 1 (up)
                flowchart.ExecuteBlock("Audio_Shelf3");
                ui.FriedaDialogue();
                MusicPlayer.SetActive(true);
                //ui.TutorialText.text = "Listen closely to what they are saying... And then play the audio snippet. The Bells are sounds that tell you that what is important to Frieda is near.";
                //ui.TutorialText.text = "Listen closely to what they are saying... And then play the audio snippet to get a clue to the object you are searching for";
                *//*if (*//*(audioplay.IsPlaying == false) && *//* (MemoryBool == false))
                {
                    MemoryBool = true;
                    print("wtf");
                }*/
                /*if (MemoryBool == false)
                {

                }*//*
            }*/
        }
    }

    void BedInteractions(RaycastHit hit, Flowchart flowchart, Scene scene)
    {
        if ((hit.transform.tag == "interact") && (hit.transform.name == "Bed"))
        {
            //CameraHolding(2);
            print("doing");
            camControl.SetCamPosition(2);
            Walking1.Play();
            ColliderDisabler(hit);

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

            //CameraHolding(3);
            camControl.SetCamPosition(3);
            Walking1.Play();
            ColliderDisabler(hit);

            if ((scene.name == "First_Scene"))
            {
                flowchart.ExecuteBlock("Cupboard1");
            }

            if (scene.name == "Puzzle_Scene")
            {
                flowchart.ExecuteBlock("Audio_Shelf");
                ui.FerozDialogue();
                /*if ((MemoryBool == false))
                {
                    MemoryBool = true;
                    //print("wtf");
                }*/
            }
        }

        /*if ((hit.transform.tag == "interact") && (hit.transform.name == "Left_Window"))
        {
            camControl.SetCamPosition(3);
            ColliderDisabler(hit);
        }*/
    }

    void TempleInteractions(RaycastHit hit, Flowchart flowchart, Scene scene)
    {
        if ((hit.transform.tag == "interact") && (hit.transform.name == "Temple"))
        {
            //CameraHolding(4);
            camControl.SetCamPosition(4);
            Walking1.Play();
            ColliderDisabler(hit);

            if ((scene.name == "First_Scene"))
            {
                flowchart.ExecuteBlock("Temple1");
            }
        }
    }

    void BedsideTableInteraction(RaycastHit hit, Flowchart flowchart, Scene scene)
    {
        if ((hit.transform.tag == "interact") && (hit.transform.name == "Bedside Table"))
        {
            //CameraHolding(5);
            camControl.SetCamPosition(5);
            Walking1.Play();
            ColliderDisabler(hit);

            if (clocks.HerbSwitch == true)  //Bring the Herbarium again when players
            {
                ui.HerbariumPopUp();
                //HerbImageDelay();
            }

            if (scene.name == "Sec_Scene")
            {
                clocks.HerbSwitch = true;
                if (clocks.HerbSwitch2 == false)
                {
                    //HerbImageDelay();
                    ui2.sprites[1].SetActive(true);
                    ui2.Number = 1;
                    clocks.HerbSwitch2 = true;
                }
                ui.HerbariumPopUp();

                flowchart.ExecuteBlock("Herbarium");
                //ui2.sprites[1].SetActive(true);
                //HerbImageDelay();
            }
        }

        

        /*if ((scene.name == "First_Scene") && (hit.transform.name == "Gramophone") && (CAM2.activeInHierarchy == true))
        {
            MusicPlayer.SetActive(true);
            //ui.Bell1.enabled = true; //BELLS
            *//*Color temp = ui.Bell1.color;
            Color temp2 = ui.Bell2.color;
            temp.a = 1.0f;
            ui.Bell1.color = temp;
            temp2.a = 1.0f;
            ui.Bell2.color = temp2;*//*
            //ui.BellUpDown1(); //show Bell 2 (down)

            audioplay.PlaySound();
            *//*audioplay.audiosource.Play(); //Play Music
            audioplay.IsPlaying = true; //Start playing music*//*

            if ((audioplay.IsPlaying == true) *//*&& (ui.Herbarium.enabled == true) && (Scene1Music == false)*//*)
            {
                flowchart.ExecuteBlock("Temple2");
                //Scene1Music = true;
            }
        }*/
    }

    void ObjectInteractions(RaycastHit hit, Flowchart flowchart, Scene scene)
    {
        if ((hit.transform.tag == "object") && (camControl.currentSceneCam == camControl.sceneCams[1])) //if ray hits a gameobject with transform having the tag "object"
        {
            //print("hit!!!!");
            if (scene.name == "First_Scene")
            {
                if (camControl.sceneCams[1].transform.position == camControl.cameraPositions[0].transform.position)
                {
                    if ((hit.transform.name == "Orchids") /*&& (ui.Herbarium.enabled == true)*/)
                    {
                        flowchart.ExecuteBlock("Flowers1");
                        flowerpot.SetActive(false);
                    }

                    if (hit.transform.name == "Photograph1")
                    {
                        if ((clocks.TimeSwap1 == false) && (clocks.PhotoSwitch == false))
                        {
                            //Invoke("HerbAnim1Delay", 3);
                            //clocks.TimeChange1();
                            flowchart.ExecuteBlock("Photo_Time_01");
                            clocks.PhotoSwitch = true;
                            hit.transform.gameObject.layer = 0;
                            //flowchart.ExecuteBlock("Clock Time Tutorial 1");
                            //print("working");
                        }

                        if ((clocks.TimeSwap1 == true) && (clocks.PhotoSwitch == false))
                        {
                            //Invoke("HerbAnim2Delay", 3);
                            //clocks.TimeChange2();
                            flowchart.ExecuteBlock("Photo_Time_02");
                            clocks.PhotoSwitch = true;
                            hit.transform.gameObject.layer = 0;
                            //flowchart.ExecuteBlock("Photo2");
                        }

                        //flowchart.ExecuteBlock("Photo1");

                        if (hit.transform.name == "Gramophone")
                        {
                            /*MusicPlayer.SetActive(true);
                            audioplay.PlaySound();
                            if ((audioplay.IsPlaying == true) *//*&& (ui.Herbarium.enabled == true) && (Scene1Music == false)*//*)
                            {
                                flowchart.ExecuteBlock("Temple2");
                            }*/
                        }
                    }
                }

                if (camControl.sceneCams[1].transform.position == camControl.cameraPositions[4].transform.position)
                {
                    if (hit.transform.name == "Bell1")
                    {
                        flowchart.ExecuteBlock("Bell1");
                    }

                    if (hit.transform.name == "Krishna_OBJ")
                    {
                        flowchart.ExecuteBlock("Krishna1");
                    }
                }

                if (camControl.sceneCams[1].transform.position == camControl.cameraPositions[5].transform.position)
                {
                    if (hit.transform.name == "Herbarium_Book")
                    {
                        //counterbool = true;
                        //flowchart.ExecuteBlock("Herbarium1");

                        //ui.Bell1.enabled = true;
                        //Invoke("EnableBaby", 2);
                        //ui.TutorialText.fontSize = 12;
                        //ui.TutorialText.text = "The Herbarium is the archive of what Frieda has kept. It holds names and traces of the most important pieces of her life. The Counter number showing up on the bookmark shows you the number of memories you have collected.";
                        //ui.Baby_Herbarium.enabled = true;

                        //ui.Herbarium_Button_Up();
                        if (scene.name == "First_Scene")
                        {
                            if ((clocks.TimeSwap1 == false) && (clocks.HerbSwitch == false))
                            {
                                //clocks.TimeChange1();
                                //ui.Herbarium.enabled = true;
                                //ui.Feroz_Wedding_Full.enabled = true;
                                /*Invoke("HerbAnim1Delay", 3);
                                Invoke("HerbDialogueDelay", 1);
                                Invoke("HerbImageDelay", 6);*/
                                flowchart.ExecuteBlock("Herbarium_Time_01");
                                clocks.HerbSwitch = true;
                                //flowchart.ExecuteBlock("Clock Time Tutorial 2");
                                //ui.Herbarium_Button_Up();
                                SwitchHerbariumBook();
                            }

                            if ((clocks.TimeSwap1 == true) && (clocks.HerbSwitch == false))
                            {
                                //ui.Herbarium.enabled = true;
                                //ui.Feroz_Wedding_Full.enabled = true;
                                //clocks.TimeChange2();
                                /*Invoke("HerbAnim2Delay", 4);
                                Invoke("HerbDialogueDelay", 1);
                                Invoke("HerbImageDelay", 2);*/
                                flowchart.ExecuteBlock("Herbarium_Time_02");
                                clocks.HerbSwitch = true;
                                //flowchart.ExecuteBlock("Herbarium2");
                                //ui.Herbarium_Button_Up();
                                SwitchHerbariumBook();
                            }
                        }

                        /*if ((clocks.TimeSwap == true) && (clocks.HerbSwitch == true))
                        {
                            SwitchHerbariumBook();
                        }*/
                    }
                }

            }

            if (scene.name == "Sec_Scene")
            {
                if (camControl.sceneCams[1].transform.position == camControl.cameraPositions[0].transform.position)
                {
                    if (hit.transform.name == "Tiffin_Dabba")
                    {
                        flowchart.ExecuteBlock("Tiffin Box");
                    }
                }

                if (camControl.sceneCams[1].transform.position == camControl.cameraPositions[4].transform.position)
                {
                    if (hit.transform.name == "Lighter")
                    {
                        if ((clocks.TimeSwap2 == false) && (clocks.LighterSwitch == false))
                        {
                            clocks.LighterSwitch = true;
                            flowchart.ExecuteBlock("Lighter1");
                            hit.transform.gameObject.layer = 0;
                        }

                        if ((clocks.TimeSwap2 == true) && (clocks.LighterSwitch == false))
                        {
                            clocks.LighterSwitch = true;
                            flowchart.ExecuteBlock("Lighter2");
                            hit.transform.gameObject.layer = 0;
                        }
                    }
                }

                if (camControl.sceneCams[1].transform.position == camControl.cameraPositions[1].transform.position)
                {
                    if (hit.transform.name == "Vinyl")
                    {
                        /*if ((clocks.TimeSwap2 == false) && (clocks.GramophoneSwitch == false) && (clocks.VinylSwitch == false))
                        {
                            clocks.VinylSwitch = true;
                            flowchart.ExecuteBlock("Vinyl Records1");
                        }

                        if ((clocks.TimeSwap2 == true) && (clocks.GramophoneSwitch == false) && (clocks.VinylSwitch == false))
                        {
                            clocks.VinylSwitch = true;
                            flowchart.ExecuteBlock("Vinyl Records2");
                        }*/
                        clocks.VinylSwitch = true;
                        flowchart.ExecuteBlock("Vinyl Records1");
                    }

                    if (hit.transform.name == "Gramophone")
                    {
                        if ((clocks.TimeSwap2 == false) && (clocks.GramophoneSwitch == false))
                        {
                            clocks.GramophoneSwitch = true;
                            flowchart.ExecuteBlock("Gramophone1");
                            hit.transform.gameObject.layer = 0;
                        }

                        if ((clocks.TimeSwap2 == true) && (clocks.GramophoneSwitch == false))
                        {
                            flowchart.ExecuteBlock("Gramophone2");
                            hit.transform.gameObject.layer = 0;
                        }
                        
                    }

                }
            }
        }
    }

    void ColliderDisabler(RaycastHit hit)
    {
        for (int i = 0; i < InteractiveFurniture.Length; i++)
        {
            /*if ((hit.transform.gameObject == InteractiveFurniture[i].transform.gameObject) && (camControl.currentSceneCam == camControl.sceneCams[0]))
            {
                InteractiveFurniture[i].GetComponent<Collider>().enabled = false;
            }*/

            if ((InteractiveFurniture[i].GetComponent<Collider>().enabled == true) && (camControl.currentSceneCam == camControl.sceneCams[0]))
            {
                InteractiveFurniture[i].GetComponent<Collider>().enabled = false;
            }
        }
        /*if ((hit.collider.transform.gameObject.layer == 9) && (hit.transform.tag == "interact"))
        {
            hit.collider.transform.gameObject.layer = 10;
            hit.collider.enabled = false;
        }*/
    }

    void ColliderEnabler ()
    {
        for (int i = 0; i < InteractiveFurniture.Length; i++)
        {
            if ((InteractiveFurniture[i].GetComponent<Collider>().enabled == false) && (camControl.currentSceneCam == camControl.sceneCams[1]))
            {
                InteractiveFurniture[i].GetComponent<Collider>().enabled = true;
            }
        }
    }

    //void cameraChangeCounter() //counter for jumping to zoomed view
    //{
    //    int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition"); //Get integer for camera position from Player Preferences and set it equal to camera position counter
    //    cameraPositionCounter++; //increase that int
    //    //cameraPositionChange(cameraPositionCounter); //set camera postion to that increased int
    //    print(cameraPositionCounter);
    //    //crossfade.Crossfade_fadeout();
    //    //camerafade2.RedoFade();
    //    //crossfade.ScreenFade();
    //}



    //void cameraPositionChange(int camPosition)
    //{
    //    if (camPosition > 1) 
    //    {
    //        camPosition = 0;
    //    }

    //    if (camPosition == 0)
    //    {
    //        CAM1.SetActive(true);
    //        CAM1aud1.enabled = true;
    //        //CAM1.GetComponent<Camera>().enabled = true;

    //        CAM2.SetActive(false);
    //        CAM2aud2.enabled = false;
    //        //CAM2.GetComponent<Camera>().enabled = false;
    //    }

    //    if (camPosition == 1)
    //    {

    //        CAM2.SetActive(true);
    //        CAM2aud2.enabled = true;
    //        //CAM2.GetComponent<Camera>().enabled = true;

    //        CAM1.SetActive(false);
    //        CAM1aud1.enabled = false;
    //        //CAM1.GetComponent<Camera>().enabled = false;
    //    }
    //}


    /*void cameraChangeCounter2() //counter for coming back to original view
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        print("ChangeCounter2: " + cameraPositionCounter);
        cameraPositionCounter++;
        cameraPositionChange2(cameraPositionCounter);
        //print(cameraPositionCounter);
        //camerafade1.RedoFade();
        //crossfade.ScreenFade();
    }*/

    /*void cameraPositionChange2(int camPosition)
    {
        if (camPosition > 1)
        {
            camPosition = 0;
        }

        if (camPosition == 0)
        {
            CAM2.SetActive(true);
            CAM2aud2.enabled = true;
            //CAM2.GetComponent<Camera>().enabled = true;

            CAM1.SetActive(false);
            CAM1aud1.enabled = false;
            //CAM1.GetComponent<Camera>().enabled = false;
            print("CAM1: " + CAM1.activeSelf + " CAM2: " + CAM2.activeSelf);
        }

        if (camPosition == 1)
        {
            CAM1.SetActive(true);
            CAM1aud1.enabled = true;
            //CAM1.GetComponent<Camera>().enabled = true;

            CAM2.SetActive(false);
            CAM2aud2.enabled = false;
            //CAM2.GetComponent<Camera>().enabled = false;
            print("CAM1: " + CAM1.activeSelf + " CAM2: " + CAM2.activeSelf);
        }
    }*/

    void MemoryComing()
    {
        ui.MemoryAppear();
        MusicPlayer.SetActive(false);
    }

    void BackButtonEnabler()
    {

        if (camControl.currentSceneCam == camControl.sceneCams[0])
        {
            ui.Back_Button.gameObject.SetActive(false);
        }

        else if (camControl.currentSceneCam == camControl.sceneCams[1])
        {
            ui.Back_Button.gameObject.SetActive(true);
        }
    }

    void SwitchHerbariumBook()
    {
        if (open_book.activeSelf == false)
        {
            open_book.gameObject.SetActive(true);
            closed_book.gameObject.SetActive(false);
        }
    }

    public void BackButton()
    {
        var MD = MenuDialog.GetMenuDialog();
        if ((flowchart.GetExecutingBlocks().Count == 0) && (MD.isActiveAndEnabled == false))
        {
            camControl.ReturnCamPositionOnBack();
            Walking2.Play();
            ColliderEnabler();
            //cameraPositionChange(0);
            //cameraChangeCounter2();
            if ((clocks.HerbSwitch == true) && (camControl.sceneCams[1].transform.position == camControl.cameraPositions[5].transform.position))
            {
                ui.HerbariumPopDown();
            }
            if (camControl.sceneCams[1].transform.position == camControl.cameraPositions[0].transform.position)
            {
                Tiffin.gameObject.layer = 0;
            }
            //DisableUI_Herbarium();
        }
    }

    /*void HerbAnim1Delay()
    {
        clocks.TimeChange1();
    }

    void HerbAnim2Delay()
    {
        clocks.TimeChange2();
    }*/

    /*void HerbDialogueDelay()
    {
        if (clocks.TimeSwap == false)
        {
            flowchart.ExecuteBlock("Clock Time Tutorial 2");
        }

        else if (clocks.TimeSwap == true)
        {
            flowchart.ExecuteBlock("Herbarium2");
        }
    }*/

    void HerbImageDelay()
    {
        //ui.Pull_Herb.gameObject.SetActive(true);
        ui.Slide_Herb();
        ui.Herbarium.enabled = true;
        ui2.sprites[0].SetActive(true);
        //ui.Feroz_Wedding_Full.enabled = true;
        ui.Herbarium_Button_Up();
    }

    void GoBack()
    {
        camControl.ReturnCamPositionOnBack();
    }

    void MoveCameraToBalcony ()
    {
        camControl.SetCamPosition(3);
    }
}
