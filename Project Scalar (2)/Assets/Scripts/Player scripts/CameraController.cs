using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour

    //Please leave damp time as 0 as it causes problems regarding the player's rotation script

{
    private GameObject Player;

    public float dampTime = 0.1f;
    private Vector3 velocity = Vector3.zero;
    private float cameraZ = 0;

    private new Camera camera;

    void Start()
    {
        cameraZ = transform.position.z;
        camera = GetComponent<Camera>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (Player)
        {
            Vector3 delta = Player.transform.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, cameraZ));
            Vector3 destination = transform.position + delta;
            destination.z = cameraZ;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}
