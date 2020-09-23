using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inaccuracy : MonoBehaviour
{
    public Transform Gunbarrel;
    public Rigidbody2D Firepoint;

    float AimDir;
    public float InaccFloat;
    public float Recoil;
    public float RecoilIntensity = 0.1f; // default val for testing, will change after weapons + stats are added
    public float RecoilCoolDown;
    float AimValue;

    bool IsMoving;
    bool IsSprinting;
    bool IsAiming;

    public Shoot pew;
    public Playermovement PM;

    // After adding inventory,weapon and skill stat system, add modifier floats here.

    void Start()
    {
        Recoil = 0f;
        AimValue = 0f;
    }

    void FixedUpdate()
    {
        Firepoint.position = Gunbarrel.position;

        AimDir = PM.angle;

        Firepoint.rotation = AimDir + InaccFloat;
    }

    void Update()
    {
        InaccFunction();
        AimFunction();
        MovementLimit();
        RecoilFunc();
    }

    // Please adjust values
    void InaccFunction()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            IsMoving = true;
        }

        else
        {
            IsMoving = false;
        }

        if (Input.GetButtonDown("Sprint"))
        {
            if (IsMoving)
            {
                IsSprinting = true;
            }
            else if (!IsMoving)
            {
                IsSprinting = false;
            }
        }

        if (IsMoving) // if the player is moving
        {
            if (IsSprinting) // if the player is sprinting
            {
                InaccFloat = (Random.Range(-45f,45f) * Recoil);
                IsAiming = false; // Aiming completely disabled
            }

            else if (!IsSprinting) // if the player is not sprinting
            {
                InaccFloat = (Random.Range((-22.5f + AimValue),(22.5f - AimValue)) * Recoil);
                if (IsAiming)
                {
                    AimValue = 20f;
                }
                else if (!IsAiming)
                {
                    AimValue = 0f;
                }
            }
        }

        else if (!IsMoving) // if the player is not moving
        {
            InaccFloat = (Random.Range((-11.25f + AimValue),(11.25f - AimValue)) * Recoil);
            if (IsAiming)
            {
                AimValue = 10f;
            }
            else if (!IsAiming)
            {
                AimValue = 0f;
            }
        }
    }

    void AimFunction() // receives input for aiming
    {
        if (Input.GetButton("Fire2"))
        {
            IsAiming = true;
        }

        else
        {
            IsAiming = false;
        }

    }

    void MovementLimit() // limits movement while aiming
    {
        if (IsAiming)
        {
            PM.speed = 2.5f;
        }

        else if (!IsAiming)
        {
            PM.speed = 5f;
        }
    }

    void RecoilFunc()
    {
        if (pew.IsShooting)
        {
            Recoil += RecoilIntensity;
            RecoilCoolDown = 1f;
            if (Recoil >= 1f)
            {
                Recoil = 1f;
            }
        }

        else if (!pew.IsShooting)
        {
            RecoilCoolDown -= Time.deltaTime * 0.5f;
            if (RecoilCoolDown <= 0)
            {
                RecoilCoolDown = 0f;
                Recoil -= (Time.deltaTime);
                if (Recoil <= 0f)
                {
                    Recoil = 0f;
                }
            }
        }
    }
}
