using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Basic Enemy AI script, will update to better script later in 0.0.2

public class EnemyAI : MonoBehaviour
{
    public float Speed;
    public float StoppingDistance;
    public float RetreatDistance;
    public float RotationSpeed;  // rotation speed
    public float SprintDistance;

    public bool IsLastSeen;
    public bool IsAware;

    public GameObject LastSeenPrefab;

    public Transform Player;
    public Transform LastSeen;
    public Transform SightStart;
    public Transform NavStop;

    public EnVision EV;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;


        Speed = 3f;
        StoppingDistance = 1f;
        RetreatDistance = 0f;
        SprintDistance = 4f;
        RotationSpeed = 5f;

        IsAware = false;
    }

    void Update()
    {
        Navigation();

        if (EV.InView)
        {
            IsLastSeen = false;
            IsAware = true;
        }

        else if (!EV.InView) 
        {
            if (!IsLastSeen)
            {
                if (IsAware)
                {
                    GameObject LastSeen = Instantiate(LastSeenPrefab, Player.position, Player.rotation);
                    IsLastSeen = true;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (IsAware)
        {
            if (EV.InView)
            {
                EnemyMovement();
            }

        }
    }

    void EnemyMovement()
    {
        if (!IsLastSeen)
        {
            if (Vector2.Distance(transform.position, Player.position) > StoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
            }

            else if (Vector2.Distance(transform.position, Player.position) < StoppingDistance && Vector2.Distance(transform.position, Player.position) > RetreatDistance)
            {
                transform.position = this.transform.position;
            }

            else if (Vector2.Distance(transform.position, Player.position) < RetreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.position, -Speed * Time.deltaTime);
            }

            if (Vector2.Distance(transform.position, Player.position) > SprintDistance)
            {
                Speed = 6f;
            }

            else
            {
                Speed = 3f;
            }

            Vector2 direction = Player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
        }
    }

    // Seperating the code here

    void Chase()
    {
        //buggy part, WIP
    }

    void Navigation()
    {
        Vector2 Direction = NavStop.position - SightStart.position;

        RaycastHit2D Nav = Physics2D.Raycast(SightStart.position, Direction);
        Debug.DrawRay(SightStart.position, Direction);

        if (Nav.collider != null)
        {
            if (Nav.collider.tag == "wall")
            {
                Debug.Log("I SEE WOL");
            }
        }

        else
        {
            if (IsAware)
            {
                transform.Translate(Vector2.up * Speed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        IsAware = true;
    }
}