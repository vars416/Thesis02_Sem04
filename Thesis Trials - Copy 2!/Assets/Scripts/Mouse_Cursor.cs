using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mouse_Cursor : MonoBehaviour
{
    public Texture2D new_cursor;
    public CursorMode cursorMode = CursorMode.Auto;
    //public Camera CAM;
    private Vector2 hotSpot = Vector2.zero;

    [SerializeField]
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "First_Scene")
        {
            Ray ray = gm.camControl.currentSceneCam.ScreenPointToRay(Input.mousePosition);//CAM.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Interact")))
            {
                /*if (*//*(hit.transform.gameObject.tag == "object") && *//*(gm.camControl.currentSceneCam == gm.camControl.sceneCams[1]))
                {
                    Cursor.SetCursor(new_cursor, hotSpot, cursorMode);
                }*/
                //print(hit.transform.name);
                /*if ((hit.transform.gameObject.tag == "interact") *//*&& (gm.camControl.currentSceneCam == gm.camControl.sceneCams[0])*//*)
                {
                    Cursor.SetCursor(new_cursor, hotSpot, cursorMode);
                }*/

                Cursor.SetCursor(new_cursor, hotSpot, cursorMode);
            }

            /*if ((gameObject.tag == "object") && (gm.camControl.currentSceneCam == gm.camControl.sceneCams[1]) && (Physics.Raycast(ray, out hit)))
            {
                Cursor.SetCursor(new_cursor, hotSpot, cursorMode);
            }*/

            else
            {
                Cursor.SetCursor(null, Vector2.zero, cursorMode);
            }
        }
    }

    /*void OnMouseEnter()
    {
        if ((gameObject.tag == "interact") || (gameObject.layer == 9))
        {
            Cursor.SetCursor(new_cursor, hotSpot, cursorMode);
            print("cursor working");
        }

        //Cursor.SetCursor(new_cursor, hotSpot, cursorMode);
        //print("cursor working");
    }*/

    /*void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }*/
}
