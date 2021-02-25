using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audiosource;

    //public Button Play;

    //public Button Pause;

    public Slider Scrubber;

    public bool IsPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
        Scrubber = Scrubber.GetComponent<Slider>();
        Scrubber.maxValue = audiosource.clip.length;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Scrubber.value > (int)audiosource.clip.length)
        {
            IsPlaying = false;
            //print("Playing = false");
            audiosource.time = 0;
            Scrubber.value = 0;
        }
        if (IsPlaying && Scrubber.value < (int)audiosource.clip.length)
        {
            Scrubber.value = audiosource.time;
            //print("end2");
        }
    }

    public void PlaySound() //Play Sound
    {
        audiosource.Play();
        IsPlaying = true;
    }

    public void PauseSound () //Pause Sound
    {
        IsPlaying = false;
        audiosource.Pause();
    }

    public void ScrubberDown()
    {
        audiosource.Pause();
        IsPlaying = false;
    }

    public void ScrubberUp()
    {
        if (Scrubber.value < audiosource.clip.length)
        {
            if (!IsPlaying)
            {
                audiosource.time = Mathf.Clamp(Scrubber.value, 0f, audiosource.clip.length);
                audiosource.UnPause();
                IsPlaying = true;
            }
            else
            {
                print("Stop1");
                audiosource.Stop();
                IsPlaying = false;
                audiosource.time = 0;
            }
        }
        else
        {
            print("Stop2");
            audiosource.Stop();
            audiosource.time = 0;
            IsPlaying = false;
        }
    }
}
