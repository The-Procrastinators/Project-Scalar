using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnVision : MonoBehaviour
{
    public bool InView;

    public float RotationSpeed = 5f;

    public Transform Player;
    public Transform SightStart;

    RaycastHit2D hit;

    void Start()
    {
        InView = false;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {

        Vector2 Direction = Player.position - transform.position;
        RaycastHit2D Hit = Physics2D.Raycast(SightStart.position, Direction); //shoots view lasers towards player
        Debug.DrawRay(SightStart.position, Direction); //shows lasers

        if (Hit.collider != null)
        {
            if (Hit.collider.gameObject.tag == "Player")
            {
                InView = true;
            }

            else if (Hit.collider.gameObject.tag == "wall")
            {
                InView = false;
            }
        }
    }
}
