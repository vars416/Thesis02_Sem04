using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Cursor : MonoBehaviour
{
    public Texture2D new_cursor;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseEnter()
    {
        Cursor.SetCursor(new_cursor, Vector2.zero, CursorMode.ForceSoftware);
        print("cursor working");
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }
}
