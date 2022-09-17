using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("LVL_1");
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
