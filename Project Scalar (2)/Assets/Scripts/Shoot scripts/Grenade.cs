using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    bool Throwing;
    public Transform GrenadePoint;
    public GameObject GrenadePrefab;
    float ThrowForce = 25f;

    void Start()
    {
        Throwing = false;
    }

    void Update()
    {
        GrenadeInput();
        ThrowGrenade();
    }

    void GrenadeInput()
    {
        if (Input.GetButtonDown("grenade throw"))
        {
            Throwing = true;
        }
        else
        {
            Throwing = false;
        }
    }
    void ThrowGrenade()
    {
        if (Throwing)
        {
            GameObject Grenade = Instantiate(GrenadePrefab, GrenadePoint.position, GrenadePoint.rotation);
            Rigidbody2D rb = Grenade.GetComponent<Rigidbody2D>();
            rb.AddForce(GrenadePoint.up * ThrowForce, ForceMode2D.Impulse);
        }
    }

}
