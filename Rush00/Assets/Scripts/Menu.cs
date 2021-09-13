using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    
    public List<GameObject> menuButtons;
    public GameObject chosenButton;
    [Range(0, 99)]
    public float audioStartTime = 0;
    
    private int _chosenButtonIndex = 0;
    private static readonly int IsChosenProperty = Animator.StringToHash("Is Chosen");

    private void Awake()
    {
        AudioSource music = GetComponent<AudioSource>();
        float musicStartDelay = music.clip.length / 100 * audioStartTime;
        music.time = musicStartDelay;
    }

    private void Start()
    {
        chosenButton.GetComponent<Animator>().SetBool(IsChosenProperty, true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            chosenButton.GetComponent<Animator>().SetBool(IsChosenProperty, false);
            ++_chosenButtonIndex;
            if (menuButtons.Count == _chosenButtonIndex)
                _chosenButtonIndex = 0;
            chosenButton = menuButtons[_chosenButtonIndex];
            chosenButton.GetComponent<Animator>().SetBool(IsChosenProperty, true);
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            chosenButton.GetComponent<Animator>().SetBool(IsChosenProperty, false);
            --_chosenButtonIndex;
            if (_chosenButtonIndex < 0)
                _chosenButtonIndex = menuButtons.Count - 1;
            chosenButton = menuButtons[_chosenButtonIndex];
            chosenButton.GetComponent<Animator>().SetBool(IsChosenProperty, true);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            chosenButton.GetComponent<Button>().onClick.Invoke();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("LVL_1");
    }
    
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Scenes/Main Menu");
        Resume();
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Resume();
    }

    public static void Pause()
    {
        GameIsPaused = true;
        Time.timeScale = 0f;
    }

    public static void Resume()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        
    }
}