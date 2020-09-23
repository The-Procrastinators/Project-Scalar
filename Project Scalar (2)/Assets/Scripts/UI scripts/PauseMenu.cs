using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public bool IsOpened;

    void Start()
    {
        IsOpened = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
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

        if (IsOpened)
        {
            Time.timeScale = 0f;
        }

        else if (!IsOpened)
        {
            Time.timeScale = 1f;
        }
    }

    void OpenPanel()
    {
        PausePanel.SetActive(true);
        IsOpened = true;
    }

    void ClosePanel()
    {
        PausePanel.SetActive(false);
        IsOpened = false;
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }
}
