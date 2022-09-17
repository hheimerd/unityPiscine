using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeButtons : MonoBehaviour
{
    [SerializeField]private gameManager _gameManager;

    public void Pause(bool paused)
    {
        _gameManager.pause(paused);
    }

    public void ChangeSpeed(float speed)
    {
        _gameManager.changeSpeed(speed);
    }


}
