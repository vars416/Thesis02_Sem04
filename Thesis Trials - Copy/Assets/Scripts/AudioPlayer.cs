using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AudioPlayer : MonoBehaviour
{
    AudioSource audiosource;

    public Button Play;

    public Button Pause;

    public Slider Scrubber;

    private bool slide = false;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
        Scrubber = GetComponent<Slider>();
    }

    // Update is called once per frame
    public void Update()
    {
        //Scrubber.value += Time.deltaTime;
        /*if (Scrubber.value >= audiosource.clip.length)
        {
            Scrubber.value = audiosource.clip.length;
        }*/
        //Scrubber.value = audiosource.clip.length;
    }

    public void PlaySound()
    {
        audiosource.Play();
        Scrubber.maxValue = audiosource.clip.length;
        Scrubber.value = 0;
        Scrubbing();
    }

    public void PauseSound ()
    {
        audiosource.Pause();
    }

    public void Scrubbing ()
    {
        Scrubber.value += Time.deltaTime;
    }
}
