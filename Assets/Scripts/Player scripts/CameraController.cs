using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour

//Please leave damp time as 0 as it causes problems regarding the player's rotation script

{
    private GameObject Player;

    public float dampTime = 1f;
    private Vector3 velocity = Vector3.zero;
    private float cameraZ = 0;
    private float curPosX = 0;
    private float curPosY = 0;
    private float camScrollIntensityX = 1920f;
    private float camScrollIntensityY = 1080f;
    private bool camScroll = false;
    private new Camera camera;

    void Start()
    {
        cameraZ = transform.position.z;
        camera = GetComponent<Camera>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        camScroller();
        camMover();
    }

    void Update()
    {
        camTog();
    }

    void camTog()
    {
        if (Input.GetButtonDown("camToggle"))
        {
            if (!camScroll)
            {
                camScroll = true;
            }
            else if (camScroll)
            {
                camScroll = false;
            }
        }
    }

    void camScroller()
    {
        Vector3 mousePos = Input.mousePosition;
        if (camScroll)
        {
            curPosX = ((mousePos.x - 960) / 400)*Mathf.Log(Mathf.Abs(mousePos.x-960), camScrollIntensityX);
            curPosY = ((mousePos.y - 540) / 400)*Mathf.Log(Mathf.Abs(mousePos.y-540), camScrollIntensityY);
        }
        else
        {
            curPosX = curPosY = 0;
        }
    }

    void camMover()
    {
        if (Player)
        {
            Vector3 delta = Player.transform.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, cameraZ));
            Vector3 destination = transform.position + delta;
            Vector3 moose = new Vector3(curPosX, curPosY, 0f);
            destination.z = cameraZ;
            transform.position = Vector3.SmoothDamp(transform.position, (destination), ref velocity, dampTime) + moose;
        }
    }
}