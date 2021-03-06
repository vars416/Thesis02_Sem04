using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RendTexRaycaster : MonoBehaviour, IPointerClickHandler,  IPointerDownHandler {
    //Camera mainCam;

    public Camera extendedCamera;
    //public ZombieChain chain;
    private Vector2 viewportClick;

    RectTransform screenRectTransform;


    void Start()
    {
        //mainCam = Camera.main;
        screenRectTransform = GetComponent<RectTransform>();

    }
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        SetViewPortClick(eventData);

        Ray ray = extendedCamera.ViewportPointToRay(new Vector3(viewportClick.x, viewportClick.y));


        if (Physics.Raycast(ray, out RaycastHit hit))
        {

            if (Physics.Raycast(ray, out hit))
            {


            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SetViewPortClick(eventData, true);
    }


    public RaycastHit GetRaycastHit(LayerMask layerMask)
    {
        RaycastHit hit;
        Ray ray = extendedCamera.ViewportPointToRay(new Vector3(viewportClick.x, viewportClick.y));
        Physics.Raycast(ray.origin, ray.direction, out hit, 1000, layerMask);
        return hit;
    }

    void SetViewPortClick(PointerEventData eventData, bool clicked = false)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(screenRectTransform, eventData.position,
            eventData.pressEventCamera, out Vector2 localClick);

        viewportClick = new Vector2(localClick.x / screenRectTransform.rect.width,
            localClick.y / screenRectTransform.rect.height) + (0.5f * Vector2.one);
    }

}


