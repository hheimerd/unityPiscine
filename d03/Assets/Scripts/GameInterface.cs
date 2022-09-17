using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInterface : MonoBehaviour
{
    public Texture2D mouseCursor;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(mouseCursor, Vector2.zero, CursorMode.Auto);
    }

}
