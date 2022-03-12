using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// reworked ammo system

public class AmmoSys2 : MonoBehaviour
{
    public int Mags; // current value for magazines
    public int MinMags = 0; // minimum value for magazines
    public int MagSize; // bullets in each magazine
    void Start()
    {
        Mags = 3; // ammount of mags after spawned, to be edited when inventory works
    }

    void Update()
    {
        
    }
}
