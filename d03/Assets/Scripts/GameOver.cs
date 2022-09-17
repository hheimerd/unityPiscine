using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text ScoreValue;
    public TMP_Text Title;
    [SerializeField] private gameManager _gameManager;
    private bool isWin = false;
    public bool gameIsOver = false;

    public void OnGameOver()
    {
        gameObject.SetActive(true);
        isWin = _gameManager.playerHp > 0;
        Title.color = isWin ? Color.green : Color.red;
        Title.text = isWin ? "You WIN!" : "You Lose :(";

        ScoreValue.text = _gameManager.score.ToString("0");
    }
    
    public void LoadLevel(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Start()
    {
        _gameManager.addGameOverListener(() =>
        {
            gameIsOver = true;
            OnGameOver();
        });
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (gameIsOver) return;
    }
}
