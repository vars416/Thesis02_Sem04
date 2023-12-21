using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //public AudioPlayer audioplay;
    //public Image Bell1;
    //public Image Bell2;
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
    public Image Feroz_Wedding_Full;
    //public Image Feroz_Wedding_Flower;

    public Text TutorialText;
    //public Text CounterText;

    public Button Right_Herbarium;
    public Button Left_Herbarium;

    public Button Back_Button;

    //public Button Pull_Herb;
    public Animator Herb_Slide;

    [SerializeField]
    private Animator Balcony_Zoom;

    //public UITrial2 uitrial2;
    public Clocks clocks;

    public Scene testscene;

    public GameManager GM;

    public UITrial2 ui2;

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        GM = GM.GetComponent<GameManager>();

        //audioplay = audioplay.GetComponent<AudioPlayer>();
        TutorialText.GetComponent<Text>();
        Herbarium.GetComponent<Image>();

        Right_Herbarium.GetComponent<Button>();
        Left_Herbarium.GetComponent<Button>();

        //Pull_Herb.GetComponent<Button>();

        if (scene.name == "First_Scene")
        {
            Herbarium.enabled = false;
            Baby_Herbarium.enabled = false;

            //Feroz_Wedding_Full.enabled = false;
            //Feroz_Wedding_Flower.enabled = false;

            //Memory_Herbarium.enabled = false;
            Memory_Layout.enabled = false;
            Memory_Completed.enabled = false;
            //BellStarting();
            PortraitsStarting();
            //RingStarting(scene);
            //CounterText.enabled = false;

            Right_Herbarium.gameObject.SetActive(false);
            Left_Herbarium.gameObject.SetActive(false);

            //Pull_Herb.gameObject.SetActive(false);
        }

        if (scene.name == /*"Second_Scene"*/ "Sec_Scene")
        {

            //Herbarium.enabled = false;
            //Baby_Herbarium.enabled = false;
            //HerbariumPopDown();
            //HerbariumDown();
            //Feroz_Wedding_Full.enabled = false;
            Color tempC = Herbarium.color;
            tempC.a = 0.1f;
            Herbarium.color = tempC;
            Memory_Layout.enabled = false;
            Memory_Completed.enabled = false;
            //PortraitsStarting();
            //RingStarting(scene);
            //CounterText.enabled = false;

            Right_Herbarium.gameObject.SetActive(false);
            Left_Herbarium.gameObject.SetActive(false);

            /*Herbarium.enabled = true;
            Baby_Herbarium.enabled = false;
            Memory_Herbarium.enabled = true;
            Memory_Layout.enabled = false;
            Memory_Completed.enabled = false;
            Feroz.enabled = false;
            Frieda.enabled = false;
            Meher.enabled = false;
            CounterText.enabled = false;
            RingStarting(scene);*/
            //Bell2.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //BellUpDown(scene);
    }

    /*void BellStarting ()
    {
        Bell1.GetComponent<Image>();
        Bell2.GetComponent<Image>();
        Bell1.enabled = false;
        Bell2.enabled = false;
    }*/

    public void PortraitsStarting ()
    {
        Feroz.GetComponent<Image>();
        Frieda.GetComponent<Image>();
        Meher.GetComponent<Image>();

        Feroz.gameObject.SetActive(false);
        Frieda.gameObject.SetActive(false);
        Meher.gameObject.SetActive(false);
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
        
        if ((scene.name == "First_Scene") /*|| (scene.name == "Second_Scene")*/ || (scene.name == "Sec_Scene"))
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

    /*public void BellUpDown1 ()
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
        else if ((Herbarium.enabled == false) *//*&& (GM)*//*)
        {
            TutorialText.text = "You are missing something... Find that and then return here to know more";
        }
        *//*if (scene.name == "First_Scene")
        {

        }*//*
    }*/

    /*public void BellUpDown2 ()
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
    }*/

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

        /*Color temp1 = Memory_Herbarium.color;
        temp1.a = 1.0f;
        Memory_Herbarium.color = temp1;

        Color temp3 = Feroz_Wedding_Full.color;
        temp3.a = 1.0f;
        Feroz_Wedding_Full.color = temp3;*/

        for (int i = 0; i < ui2.sprites.Length; i++)
        {
            Color tempCol = ui2.sprites[i].GetComponent<Image>().color;
            tempCol.a = 1.0f;
            ui2.sprites[i].GetComponent<Image>().color = tempCol;
        }

        Slide_Herb();
        Herbarium_Button_Up();
    }

    public void HerbariumPopDown ()
    {
        Color temp2 = Herbarium.color;
        temp2.a = 0.1f;
        Herbarium.color = temp2;

        /*Color temp1 = Memory_Herbarium.color;
        temp1.a = 0.1f;
        Memory_Herbarium.color = temp1;

        Color temp3 = Feroz_Wedding_Full.color;
        temp3.a = 0.1f;
        Feroz_Wedding_Full.color = temp3;*/

        for (int i = 0; i < ui2.sprites.Length; i++)
        {
            Color tempCol = ui2.sprites[i].GetComponent<Image>().color;
            tempCol.a = 0.1f;
            ui2.sprites[i].GetComponent<Image>().color = tempCol;
        }

        Slide_Herb();
        Herbarium_Button_Down();
    }

    public void MemoryAppear ()
    {
        Memory_Herbarium.enabled = false;
        Memory_Layout.enabled = true;
        Memory_Completed.enabled = true;
    }

    public void Herbarium_Button_Up()
    {
        Right_Herbarium.gameObject.SetActive(true);
        Left_Herbarium.gameObject.SetActive(true);
    }

    public void Herbarium_Button_Down()
    {
        Right_Herbarium.gameObject.SetActive(false);
        Left_Herbarium.gameObject.SetActive(false);
    }

    /*public void RightOn()
    {
        Herb_Slide.SetTrigger("Slide");
        //Pull_Herb.gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(1070, 485, 0), Time.deltaTime);
    }*/

    public void Slide_Herb ()
    {
        Herb_Slide.SetTrigger("Slide");
    }

    public void BalconyZoom ()
    {
        Balcony_Zoom.SetTrigger("ZoomIn");
    }

    public void HerbariumDown()
    {
        Color temp2 = Herbarium.color;
        temp2.a = 0.1f;
        Herbarium.color = temp2;

        Color temp1 = Memory_Herbarium.color;
        temp1.a = 0.1f;
        Memory_Herbarium.color = temp1;

        Color temp3 = Feroz_Wedding_Full.color;
        temp3.a = 0.1f;
        Feroz_Wedding_Full.color = temp3;
        Herbarium_Button_Down();
    }
}
