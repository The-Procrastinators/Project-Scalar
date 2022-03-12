using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// WIP to be finished in 0.0.2 or something

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    bool switchWeapon;
    public bool isShooting;
    public int weaponSlot;
    public Animator animator;

    float bulletForce = 50f;

    //reference scripts here
    public AmmoSys AS;
    public InvUI IU;

    void Start()
    {
        weaponSlot = 0;
        switchWeapon = false;
        animator.SetInteger("weaponSwitchInt", 0);
    }

    void Update()
    {
        clickSense();
        weaponEquip();
    }

    void weaponEquip()
    {
        if (weaponSlot >= 0 && weaponSlot < 3)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                switchWeapon = true;
                weaponSlot++;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                switchWeapon = true;
                weaponSlot--;
            }
            else switchWeapon = false;
        }
        else weaponSlot = 0;
        animator.SetInteger("weaponSwitchInt", weaponSlot);
        animator.SetBool("switchWeapon", switchWeapon);
    }

    void clickSense()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (weaponSlot == 1)
            {
                fire();
            }
        }
    }

    void fire()
    {
        if (AS.MagCount > 0f && !IU.IsOpened && !AS.IsReloading)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Vector3 dirdir = Quaternion.AngleAxis(0, Vector3.forward) * firePoint.up; // sets the angle at which the force is applied, parameter for angle is "0", counter clockwise up
            rb.AddForce(dirdir * bulletForce, ForceMode2D.Impulse); // applies force at specified angle
            AS.MagCount -= 1f;
        }
    }
}
