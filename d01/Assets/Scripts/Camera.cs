using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera : MonoBehaviour
{
    [SerializeField] private Player player1;
    [SerializeField] private Player player2;
    [SerializeField] private Player player3;
    [SerializeField] private ExitZone player1ExitZone;
    [SerializeField] private ExitZone player2ExitZone;
    [SerializeField] private ExitZone player3ExitZone;
    [SerializeField] private string nextLevelName;

    private Player _currentPlayer;

    private void Start()
    {
        _currentPlayer = player1;
        _currentPlayer.IsActive = true;
    }

    private bool NeedChangePlayer()
    {
        return Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Alpha3);
    }
    // Update is called once per frame
    void Update()
    {
        if (player1ExitZone.isActive &&
            player2ExitZone.isActive &&
            player3ExitZone.isActive
        )
        {
            SceneManager.LoadScene(nextLevelName);
        }
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Backspace))  
            SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ) ;

        if (NeedChangePlayer())
        {
            _currentPlayer.IsActive = false;
            if (Input.GetKeyUp(KeyCode.Alpha1))
                _currentPlayer = player1;
            if (Input.GetKeyUp(KeyCode.Alpha2))
                _currentPlayer = player2;
            if (Input.GetKeyUp(KeyCode.Alpha3))
                _currentPlayer = player3;
            _currentPlayer.IsActive = true;
        }
       
        var playerPosition = _currentPlayer.transform.position;
        transform.position = new Vector3(
            playerPosition.x,
            playerPosition.y,
            transform.position.z
        );

    }
}