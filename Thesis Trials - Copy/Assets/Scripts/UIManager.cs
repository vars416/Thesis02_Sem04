﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public AudioPlayer audioplay;
    public Image Bell1;
    public Image Bell2;
    public Image Feroz;
    public Image Frieda;
    public Image Meher;
    public Image Ring1;
    public Image Ring2;
    public Image Ring3;
    public Image Herbarium;
    public Image Baby_Herbarium;
    public Image TutorialLayout;
    public Image Memory_Herbarium;
    public Image Memory_Layout;
    public Image Memory_Completed;
    public Image Year1;
    public Image Year2;
    public Text TutorialText;
    public Text CounterText;

    public Scene testscene;

    public GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        GM = GM.GetComponent<GameManager>();

        audioplay = audioplay.GetComponent<AudioPlayer>();
        TutorialText.GetComponent<Text>();
        Herbarium.GetComponent<Image>();

        if (scene.name == "First_Scene")
        {
            Herbarium.enabled = false;
            Baby_Herbarium.enabled = false;
            Memory_Herbarium.enabled = false;
            Memory_Layout.enabled = false;
            Memory_Completed.enabled = false;
            BellStarting();
            PortraitsStarting();
            RingStarting(scene);
            Feroz.enabled = false;
            Frieda.enabled = false;
            Meher.enabled = false;
            CounterText.enabled = false;
        }

        if (scene.name == "Puzzle_Scene")
        {
            Herbarium.enabled = true;
            Baby_Herbarium.enabled = false;
            Memory_Herbarium.enabled = true;
            Memory_Layout.enabled = false;
            Memory_Completed.enabled = false;
            Feroz.enabled = false;
            Frieda.enabled = false;
            Meher.enabled = false;
            CounterText.enabled = false;
            RingStarting(scene);
            Bell2.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //BellUpDown(scene);
    }

    void BellStarting ()
    {
        Bell1.GetComponent<Image>();
        Bell2.GetComponent<Image>();
        Bell1.enabled = false;
        Bell2.enabled = false;
    }

    public void PortraitsStarting ()
    {
        Feroz.GetComponent<Image>();
        Frieda.GetComponent<Image>();
        Meher.GetComponent<Image>();

        Feroz.enabled = false;
        Frieda.enabled = false;
        Meher.enabled = false;
    }

    public void HerbariumStarting()
    {
        Herbarium.GetComponent<Image>();

        Color temp = Herbarium.color;
        temp.a = 0.1f;
        Herbarium.color = temp;
    }

    public void RingStarting(Scene scene)
    {
        
        if ((scene.name == "First_Scene") || (scene.name == "Puzzle_Scene"))
        {
            Ring1.GetComponent<Image>();
            Ring2.GetComponent<Image>();
            Ring3.GetComponent<Image>();

            Year1.GetComponent<Image>();
            Year2.GetComponent<Image>();

            Color temp1 = Ring1.color;
            temp1.a = 0.1f;
            Ring1.color = temp1;

            Color temp2 = Ring2.color;
            temp2.a = 0.1f;
            Ring2.color = temp2;

            Color temp3 = Ring3.color;
            temp3.a = 0.1f;
            Ring3.color = temp3;

            Color temp4 = Year1.color;
            temp4.a = 0.1f;
            Year1.color = temp4;

            Color temp5 = Year2.color;
            temp5.a = 0.1f;
            Year2.color = temp5;
        }
        print("alpha working");
    }

    public void BellUpDown1 ()
    {
        if (Herbarium.enabled == true)
        {
            if ((audioplay.IsPlaying == true))
            {
                Bell1.enabled = (false);
                Bell2.enabled = (true);
            }
            else if ((audioplay.IsPlaying == false) && (GM.CAM2.activeInHierarchy == true))
            {
                Bell1.enabled = (true);
                Bell2.enabled = false;
            }
            TutorialText.text = "You can play, pause and scrub through sound here. When the Bell is down, give special attention to the soundtrack and dialogue.";
            //TutorialText.text = "Hit play, click on the screen and see the Bell go down. When the Bell is down, give special attention to the soundtrack. It will guide you to the next item or place of importance. The Bells are sounds that tell you that what is important to Frieda is near.";
        }
        else if ((Herbarium.enabled == false) /*&& (GM)*/)
        {
            TutorialText.text = "You are missing something... Find that and then return here to know more";
        }
        /*if (scene.name == "First_Scene")
        {

        }*/
    }

    public void BellUpDown2 ()
    {
        if ((audioplay.IsPlaying == true))
        {
            Bell1.enabled = (false);
            Bell2.enabled = (true);
        }
        else if ((audioplay.IsPlaying == false))
        {
            Bell1.enabled = (true);
            Bell2.enabled = (false);
        }
    }

    public void MeherDialogue()
    {
        Feroz.enabled = (false);
        Frieda.enabled = (false);
        Meher.enabled = (true);
    }

    public void FriedaDialogue()
    {
        Feroz.enabled = (false);
        Frieda.enabled = (true);
        Meher.enabled = (false);
    }

    public void FerozDialogue ()
    {
        Feroz.enabled = (true);
        Frieda.enabled = (false);
        Meher.enabled = (false);
    }

    public void RingOpaque1 ()
    {
        Color temp1 = Ring1.color;
        temp1.a = 1.0f;
        Ring1.color = temp1;

        Color temp4 = Year1.color;
        temp4.a = 1.0f;
        Year1.color = temp4;
    }

    public void RingOpaque2 ()
    {
        Color temp1 = Ring2.color;
        temp1.a = 1.0f;
        Ring2.color = temp1;

        Color temp4 = Year2.color;
        temp4.a = 1.0f;
        Year2.color = temp4;
    }
    public void HerbariumPopUp ()
    {
        Color temp2 = Herbarium.color;
        temp2.a = 1.0f;
        Herbarium.color = temp2;

        Color temp3 = Baby_Herbarium.color;
        temp3.a = 1.0f;
        Baby_Herbarium.color = temp3;
    }

    public void HerbariumPopDown ()
    {
        Color temp2 = Herbarium.color;
        temp2.a = 0.1f;
        Herbarium.color = temp2;

        Color temp3 = Baby_Herbarium.color;
        temp3.a = 0.1f;
        Baby_Herbarium.color = temp3;
    }

    public void MemoryAppear ()
    {
        Memory_Herbarium.enabled = false;
        Memory_Layout.enabled = true;
        Memory_Completed.enabled = true;
    }


}
