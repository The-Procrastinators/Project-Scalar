using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Texture2D crosshair;

    void OnGUI()
    {
        // draw on current mouse position
        float xMin = Screen.width - (Screen.width - Input.mousePosition.x) - (crosshair.width / 2);
        float yMin = (Screen.height - Input.mousePosition.y) - (crosshair.height / 2);
        GUI.DrawTexture(new Rect(xMin, yMin, crosshair.width, crosshair.height), crosshair);
    }
}
