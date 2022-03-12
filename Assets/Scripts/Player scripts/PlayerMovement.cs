using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // variables
    //speed variables
    public float speed;   // walking speed

    //stamina variables
    float maxStamina = 100f;  // max stamina
    public float currentStamina;  // self explanatory
    bool isSprinting;   // sprint boolean
    float staminaDecrease = 25.0f;  // adjust here for how fast stamina decrease per second
    float staminaIncrease = 10.0f;  // adjust here for how fast stamina increase per second

    public float angle;

    GameObject player;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 mousePos;
    Vector2 movement;

    void Start()
    {
        speed = 5f;
        isSprinting = false;
        currentStamina = maxStamina;
    }

    void Update()
    {
        movePlayer();
        staminaSystem();
    }
    void FixedUpdate()
    {
        curInp();
        posChange();
        curTurn();
    }

    // updates player position
    void posChange()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    // player movement below
    void movePlayer()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButton("Sprint") && (Input.GetButton("Horizontal") || Input.GetButton("Vertical")))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }

    // stamina system
    void staminaSystem()
    {
        if (!isSprinting)
        {
            speed = 5f;
            if (currentStamina < maxStamina)
            {
                currentStamina += staminaIncrease * Time.deltaTime;
            }
            else currentStamina = maxStamina; //to prevent overflow
        }

        else if (isSprinting)
        {
            if (currentStamina > 0)
            {
                currentStamina -= staminaDecrease * Time.deltaTime;
                speed = 7.5f;
            }
            else
            {
                currentStamina = 0; // to prevent overflow
                speed = 5f;
            }
        }
    }

    void curInp()
    {
        var rawmouse = Input.mousePosition;
        rawmouse.z = 10;
        mousePos = cam.ScreenToWorldPoint(rawmouse);
    }

    void curTurn()
    {
        Vector2 lookDir = mousePos - rb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

}


