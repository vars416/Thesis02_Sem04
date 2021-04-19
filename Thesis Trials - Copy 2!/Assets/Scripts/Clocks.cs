using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clocks : MonoBehaviour
{

    /*public GameObject[] BigClock;
    public GameObject[] SmallClock;*/

    public GameObject Clock1;
    public GameObject Clock2;

    public Animator BigHourHand;
    public Animator BigMinuteHand;

    public Animator BigHourHand1;
    public Animator BigMinuteHand1;

    public Animator SmallHourHand;
    public Animator SmallMinuteHand;

    public Animator SmallHourHand1;
    public Animator SmallMinuteHand1;

    //public AudioSource ClockSound;
    public AudioSource TickingSound;
    public bool TimeSwap = false;
    public bool HerbSwitch = false;
    public bool PhotoSwitch = false;

    // Start is called before the first frame update
    void Start()
    {
        /*BigClock[1].SetActive(false);
        BigClock[2].SetActive(false);

        SmallClock[1].SetActive(false);
        SmallClock[2].SetActive(false);*/

        Clock1.GetComponent<Animation>();
        Clock2.GetComponent<Animation>();

        TimeSwap = false;
        HerbSwitch = false;
        PhotoSwitch = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TimeChange1()
    {
        TickingSound.Play();
        //ClockSound.Play();

        /*BigClock[0].SetActive(false);
        BigClock[1].SetActive(true);

        SmallClock[0].SetActive(false);
        SmallClock[1].SetActive(true);*/

        TimeSwap = true;

        BigHourHand.SetTrigger("HourTrigger");
        BigMinuteHand.SetTrigger("MinTrig");

        SmallHourHand.SetTrigger("AlarmHourTrigger");
        SmallMinuteHand.SetTrigger("AlarmMinuteTrigger");

        print(TimeSwap);
    }

    public void TimeChange2()
    {
        TickingSound.Play();
        //ClockSound.Play();

        /*BigClock[1].SetActive(false);
        BigClock[2].SetActive(true);

        SmallClock[1].SetActive(false);
        SmallClock[2].SetActive(true);*/

        /*HourHand.SetTrigger("HourTrigger");
        MinuteHand.SetTrigger("MinTrig");*/

        BigHourHand.SetTrigger("HourTrigger");
        BigMinuteHand.SetTrigger("MinTrig");

        SmallHourHand.SetTrigger("AlarmHourTrigger");
        SmallMinuteHand.SetTrigger("AlarmMinuteTrigger");
    }

    public void TimeChange3()
    {
        TickingSound.Play();

        BigHourHand.SetTrigger("HourTrigger");
        BigMinuteHand.SetTrigger("MinTrig");

        SmallHourHand.SetTrigger("AlarmHourTrigger");
        SmallMinuteHand.SetTrigger("AlarmMinuteTrigger");
    }

    public void TimeChange4()
    {
        TickingSound.Play();

        BigHourHand1.SetTrigger("HourTrigger");
        BigMinuteHand1.SetTrigger("MinTrig");

        SmallHourHand1.SetTrigger("AlarmHourTrigger");
        SmallMinuteHand1.SetTrigger("AlarmMinuteTrigger");
    }
}
