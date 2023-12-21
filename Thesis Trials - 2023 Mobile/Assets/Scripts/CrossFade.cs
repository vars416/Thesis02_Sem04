using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CrossFade : MonoBehaviour
{
    // Link https://wiki.unity3d.com/index.php/CrossFade
    //public GameObject RenderScreen;
    public GameObject Cam1Img1;
    public Animator Cam1Img1Anim;

    public bool fader = false;
    //public GameObject Cam2Img2;

    void Start()
    {
        Cam1Img1.GetComponent<Animation>();
    }

    /*public Camera camera1;
    public Camera camera2;
    public float fadeTime;
    private bool inProgress = false;
    private bool swap = false;*/

    public void Crossfade_fadeout ()
    {
        //Cam1Img1.GetComponent<Animation>().Play("ShaderOut");
        Cam1Img1Anim.SetTrigger("Fade");
        fader = true;
        //Cam1Img1Anim.SetBool("FadeOut", true);
        //Cam1Img1Anim.SetBool("FadeIn", false);
        //RenderScreen.GetComponent<Animation>().Play("CrossFade");
        //StartCoroutine(FadeTo(1.0f, 1.0f));
        print("fading out");
    }

    public void Crossfade_fadein ()
    {
        Cam1Img1Anim.SetTrigger("Fade");
        
        //Cam1Img1Anim.SetBool("FadeOut", false);
        //Cam1Img1Anim.SetBool("FadeIn", true);
        print("fading in");
    }

    void BoolOff ()
    {

    }

    /*IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = RenderScreen.transform.GetComponent<RawImage>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            RenderScreen.transform.GetComponent<RawImage>().material.color = newColor;
            yield return null;
        }
    }*/

    /*IEnumerator DoFade()
    {
        if (inProgress) return;
        inProgress = true;

        swap = !swap;
        yield return

    }*/
}
