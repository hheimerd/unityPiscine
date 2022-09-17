using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameExit : MonoBehaviour
{
    private bool isActive = false;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        TryGetComponent(out canvasGroup);
        CloseDialog();
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CloseDialog()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        isActive = false;
        Time.timeScale = 1;
    }
    
    public void OpenDialog()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        isActive = true;
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isActive)
                CloseDialog();
            else
                OpenDialog();
        }
    }
}
