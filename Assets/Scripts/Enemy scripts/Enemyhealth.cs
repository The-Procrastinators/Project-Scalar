using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Remember to create enemy stat script for 0.0.2

public class Enemyhealth : MonoBehaviour
{
    public float CurrentHealth;
    public float MinHealth = 0f;
    public float Damage;
    public  bool IsKilled;

    void Start()
    {
        CurrentHealth = 100f;
    }

    void Update()
    {
        HealthVal();
        DieCon();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            CurrentHealth -= Damage;
            Debug.Log("Bullet connects");
            Damage = other.gameObject.GetComponent<BulletDecay>().Damage;
        }
    }

    void HealthVal()
    {
        if (CurrentHealth > MinHealth)
        {
            IsKilled = false;
        }

        else if (CurrentHealth <= MinHealth)
        {
            IsKilled = true;
        }
    }

    void DieCon()
    {
        if (IsKilled)
        {
            Destroy(gameObject);
            Debug.Log("Enemy killed");
        }
    }
}
