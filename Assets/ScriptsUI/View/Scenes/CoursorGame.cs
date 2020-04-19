using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoursorGame : MonoBehaviour
{
    public Texture2D cursorTexture;

    void Start()
    {
        Vector2 vector = new Vector2(cursorTexture.width*0.5f, cursorTexture.height*0.5f);
        Cursor.SetCursor(cursorTexture, vector, CursorMode.ForceSoftware);

    }

    void OnMouseEnter() {
    }

    void OnMouseExit() {
    }
}
