using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory_Mouse : MonoBehaviour
{

    public Texture2D new_cursor;
    public CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        if (/*(gameObject.tag == "interact") || */(gameObject.layer == 9))
        {
            Cursor.SetCursor(new_cursor, hotSpot, cursorMode);
            print("cursor working");
        }
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
