using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvUI : MonoBehaviour
{
    public GameObject InvPanel;
    public bool IsOpened;

    void Start()
    {
        IsOpened = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (!IsOpened)
            {
                OpenPanel();
            }

            else
            {
                ClosePanel();
            }
        }
    }

    void OpenPanel()
    {
        InvPanel.SetActive(true);
        IsOpened = true;
    }

    void ClosePanel()
    {
        InvPanel.SetActive(false);
        IsOpened = false;
    }
}
