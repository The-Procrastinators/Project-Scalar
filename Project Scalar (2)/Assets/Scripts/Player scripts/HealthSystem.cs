using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Official script for 0.0.1, update system to actually kill player in 0.0.1. Love, Fabian

public class HealthSystem : MonoBehaviour
{
    public float Armour;
    public float MaxHealth = 100f;
    public float MinHealth = 0f;
    public float CurHealth;
    public float CurArm;
    public float BulletDMG = 20f;
    public GameObject Player;
    public bool Die;
    public bool Armoured;

    void Start()
    {
        CurHealth = MaxHealth;

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void update()
    {
        healthval();
    }

    public void healthval()
    {
        print("working health");

        if (CurHealth <= MinHealth)
        {
            Die = true;
            print("kil");

        }
        else if (CurHealth > MinHealth)
        {
            Die = false;
        }

        if (CurHealth > MaxHealth)
        {
            CurHealth = MaxHealth;
        }

        if (Die)
        {
            Destroy(Player);
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collision confirmed");
        if (other.gameObject.tag == "enemy")
        {
            CurHealth -= 5f;
        }
    }
}

// sprites required : armour sprite, bullet sprite, medkit sprite for testing