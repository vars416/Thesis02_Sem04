using System.Collections;
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
    public Image TutorialLayout;
    public Text TutorialText;

    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        audioplay = audioplay.GetComponent<AudioPlayer>();
        Herbarium.GetComponent<Image>();
        TutorialText.GetComponent<Text>();
        BellStarting();
        PortraitsStarting();
        HerbariumStarting();
        //RingStarting();
    }

    // Update is called once per frame
    void Update()
    {
        BellUpDown();
    }

    void BellStarting ()
    {
        Bell1.GetComponent<Image>();
        Bell2.GetComponent<Image>();
        Bell1.enabled = (true);
        Bell2.enabled = (false);
    }

    void PortraitsStarting ()
    {
        Feroz.GetComponent<Image>();
        Frieda.GetComponent<Image>();
        Meher.GetComponent<Image>();

        Feroz.enabled = (false);
        Frieda.enabled = (false);
        Meher.enabled = (false);
    }

    void HerbariumStarting()
    {
        if (scene.name == "First_Scene")
        {
            Herbarium.enabled = (false);
        }
        else if (scene.name == "Puzzle_Scene")
        {
            Herbarium.enabled = (true);
        }
    }

    public void RingStarting()
    {
        if (scene.name == "First_Scene")
        {
            Ring1.GetComponent<Image>();
            Ring2.GetComponent<Image>();
            Ring3.GetComponent<Image>();

            Color temp1 = Ring1.color;
            temp1.a = 0.2f;

            Color temp2 = Ring2.color;
            temp2.a = 0.2f;

            Color temp3 = Ring3.color;
            temp3.a = 0.2f;

            print("alpha working");
        }
    }

    void BellUpDown ()
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

    public void RingOpaque ()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (scene.name == "First_Scene")
            {

            }

            if (scene.name == "Puzzle_Scene")
            {

            }
        }
    }


}
