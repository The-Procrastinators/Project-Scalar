using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSys : MonoBehaviour
{
    //Add different ammo types in 0.0.2
    public float AmmoCount;
    public float MagCount;
    public float ReloadTime = 1f; // seconds
    public bool GunReloaded;
    public bool IsReloading;

    void Start()
    {
        AmmoCount = 120f;
        MagCount = 0f;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
       if (other.gameObject.tag == "AmmoBox")
        {
            Debug.Log("Ammo replenished");
            AmmoCount += 60f;
        }
    }

    void Update()
    {
        Reload();
    }

    void Reload()
    {
        if (Input.GetButton("Reload"))
        {
            ReloadTime -= Time.deltaTime;
            if (AmmoCount <= 0f)
            {
                IsReloading = false;
            }
            else if (AmmoCount > 0f)
            {
                IsReloading = true;
            }
        }

        else
        {
            IsReloading = false;
        }

        if (ReloadTime <= 0f)
        {
            GunReloaded = true;
        }

        if (GunReloaded)
        {
            AmmoCount -= (30f - MagCount);
            MagCount = 30f;

            if (AmmoCount < 0f)
            {
                MagCount += AmmoCount;
                AmmoCount = 0f;
            }
        }

        if (MagCount >= 30f)
        {
            ReloadTime = 1f;
            GunReloaded = false;
        }

        if (Input.GetButtonUp("Reload"))
        {
            ReloadTime = 1f;
        }
    }
}
