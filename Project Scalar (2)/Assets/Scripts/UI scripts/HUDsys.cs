using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDsys : MonoBehaviour
{
    public AmmoSys AS;

    public Text ReserveText;
    public Text MagText;

    void Update()
    {
        ReserveCounter();
        MagCounter();
    }

    void ReserveCounter()
    {
        ReserveText.text = "Reserve Ammo : " + AS.AmmoCount;
    }

    void MagCounter()
    {
        MagText.text = "Magazine Ammo : " + AS.MagCount;
    }
}
