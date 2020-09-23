using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // variables
    //speed variables
    public float speed = 5f;   // walking speed
    public float sprintspeed;   // extra speed gained when sprinting
    public float totalspeed;   // total speed
    public float ArmSprint;  // sprint speed when armour is equipped
    //stamina variables
    [SerializeField] float maxStaminaDecreaseTimer = 1.0f;  // self explanatory
    [SerializeField] float maxStaminaIncreaseTime = 1.0f;  // self explanatory
    float maxStamina = 100f;  // max stamina
    float currentStamina;  // self explanatory
    float currentSpeed;
    public bool isSprinting = false;   // sprint boolean
    float staminaDecrease = 10.0f;  // adjust here for how fast stamina decrease per second
    float staminaIncrease = 7.0f;  // adjust here for how fast stamina increase per second

    //Timer System 
    float currentStaminaDecreaseTimer;
    float currentStaminaIncreaseTimer;

    public float angle;
    public HealthSystem hs;

    GameObject player;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 mousePos;
    Vector2 movement;

    void Start()
    {
        currentStaminaDecreaseTimer = maxStaminaDecreaseTimer;
        currentStaminaIncreaseTimer = maxStaminaIncreaseTime;
        currentSpeed = speed;
        currentStamina = maxStamina;
    }

    void Update()
    {
        MovePlayer();
        StaminaSystem();
        ArmourEffect();
        HealthEffect();
    }
    void FixedUpdate()
    {
        CurInp();
        PosChange();
        CurTurn();
    }

    void MovePlayer()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButton("Sprint"))
        {
            totalspeed = speed + sprintspeed;
        }
        else
        {
            totalspeed = speed;
        }
    }

    void PosChange()
    {
        rb.MovePosition(rb.position + movement * totalspeed * Time.fixedDeltaTime);
    }

    void StaminaSystem()
    {
        if (Input.GetButton("Sprint"))
        {
            if (currentStamina > 0)
            {
                sprintspeed = ArmSprint;
                isSprinting = true;
            }

            else if (currentStamina <= 0f)
            {
                sprintspeed = 0f;
                isSprinting = false;
            }

        }
        else
        {
            sprintspeed = 0f;
            isSprinting = false;
        }

        if (isSprinting)
        {

            if (currentStaminaDecreaseTimer <= 0)
            {
                currentStamina -= staminaDecrease;
                currentStaminaDecreaseTimer = maxStaminaDecreaseTimer;
            }

            currentStaminaDecreaseTimer -= Time.deltaTime;
        }
        else if (!isSprinting)
        {

            if (currentStaminaIncreaseTimer <= 0)
            {
                currentStamina += staminaIncrease;
                currentStaminaIncreaseTimer = maxStaminaIncreaseTime;
            }

            if (currentStamina > maxStamina)
            {
                currentStamina = maxStamina;
            }

            currentStaminaIncreaseTimer -= Time.deltaTime;
        }
    }

    void CurInp()
    {
        var rawmouse = Input.mousePosition;
        rawmouse.z = 10;
        mousePos = cam.ScreenToWorldPoint(rawmouse);
    }

    void CurTurn()
    {
        Vector2 lookDir = mousePos - rb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void ArmourEffect()
    {
        if (hs.Armoured)
        {
            speed = 4f;
            ArmSprint = 2f;
        }
        else if (!hs.Armoured)
        {
            speed = 5f;
            ArmSprint = 3f;
        }
    }

    void HealthEffect()
    {
        if (hs.Die)
        {
            speed = 0f;
            ArmSprint = 0f;
            sprintspeed = 0f;
        }
    }
}


