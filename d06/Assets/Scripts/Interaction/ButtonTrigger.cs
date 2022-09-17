using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public KeyCode interactionButton = KeyCode.E;
    public GameObject interactionObject;
    public string message;

    protected Player _player;
    protected bool _inZone = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            _inZone = true;
            _player.SetUIMessage(message);
        }
    }

    protected virtual void OnClick()
    {
        Debug.Log("Click");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            _inZone = false;
            _player.SetUIMessage("");
        }
    }
    private void FixedUpdate()
    {
        if (_inZone && Input.GetKey(interactionButton))
        {
            OnClick();
        }
    }

    private void OnDestroy()
    {
        _player.SetUIMessage("");
    }
}
