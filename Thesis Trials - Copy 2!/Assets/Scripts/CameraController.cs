using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Camera rtCam; // The Camera focused on the RTs is going to be our main camera
    public Camera [] sceneCams; // We will use the scene cams to capture the image for the RT and to register clicks 

    private bool isCrossFading = false;

    [HideInInspector] public Camera currentSceneCam; // This is a reference to what scene cam is curently active

    public RawImage rtImage;
    private Material crossfadeMat;


    public Transform[] cameraPositions;

    const float fadeDuration = 1.0f;
    private float timer = 0;

    private GameManager gameManager;


    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        crossfadeMat = rtImage.material;
        crossfadeMat = Instantiate(rtImage.material);
        rtImage.material = crossfadeMat;  //These 3 lines of code are just for instancing the Material on the canvas image so that material changes to persist after runtime


        SetCurrentSceneCam(0);
        ActivateSceneCam(0,true);
        ActivateSceneCam(1, false);
    }

    private void SetCurrentSceneCam(int index)
    {
        Debug.Log("Setting New Current Scene Cam: " + sceneCams[index]);
        currentSceneCam = sceneCams[index];
        sceneCams[index].GetComponent<AudioListener>().enabled = true;
        int o = Mathf.Abs(index - 1);
        sceneCams[o].GetComponent<AudioListener>().enabled = false;

    }

    public void ActivateSceneCam(int index, bool status)
    {
        sceneCams[index].enabled = status;

    }

    public void SetCamPosition(int index)
    {
        sceneCams[1].transform.position = cameraPositions[index].position;
        sceneCams[1].transform.rotation = cameraPositions[index].rotation;
        ActivateSceneCam(1, true);
        // Put code to disable colliders in game mamager
        isCrossFading = true;

    }

    public void ReturnCamPositionOnBack()
    {
        // renable colliders
        ActivateSceneCam(0, true);
        isCrossFading = true;

    }

    private void Update()
    {
        if (isCrossFading)
        {
            FadeRT(GetFadeDirection());
        }     
    }


    void FadeRT(int dest)
    {
        int o = Mathf.Abs(dest - 1);
        float value;

        if (timer < fadeDuration)
        {
            timer += Time.deltaTime;

            value = Mathf.Lerp(o, dest, timer / fadeDuration);
            //Debug.Log("Crossfading");
            UpdateShader(value);

        }
        else
        {
            //Debug.Log("Done");
            ActivateSceneCam(dest, true);
            SetCurrentSceneCam(dest);
            ActivateSceneCam(o, false);
            timer = 0;
            isCrossFading = false;
        }
    }

    private void UpdateShader(float value)
    {
        crossfadeMat.SetFloat("_Fade", value);

    }

    private int GetFadeDirection()
    {
        int value = 0;
        for (int i = 0; i < sceneCams.Length; i++)
        {
            if (currentSceneCam = sceneCams[i])
            {
                value = Mathf.Abs(i-1);
                break;
            }
        }

        return value;
    }

}
