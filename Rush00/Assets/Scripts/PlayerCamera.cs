using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Player player;
    private Vector3 _playerPos;
    
    // Update is called once per frame
    void Update()
    {
        _playerPos = player.transform.position;
        transform.position = new Vector3(_playerPos.x, _playerPos.y, -10);
    }
}