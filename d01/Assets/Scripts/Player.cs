using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float playerJumpHeight = 50f;
    private bool _inAir = false;
    [SerializeField] private string colorWallTag;

    [NonSerialized] public bool IsActive;
    private Rigidbody2D _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
            _rigidbody.Sleep();
    }

    void Update()
    {
        if (!IsActive) return;
        
        float transH = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        transform.Translate(new Vector3(transH, 0, 0));

        if (!Input.GetKey(KeyCode.Space) || _inAir) return;

        _inAir = true;
        _rigidbody.AddForce(new Vector2(0, playerJumpHeight), ForceMode2D.Impulse);

    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.CompareTag("FloatPlatform")) // Убираем у персонажа скорость платформы
            transform.parent = null;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") ||  // Восстанавливаем     возможность прыгать на земле
            other.gameObject.CompareTag("Player") ||
            other.gameObject.CompareTag("FloatPlatform") ||
            other.gameObject.CompareTag("Obstacle")
        )
        {
            bool isWallTouch = other.contacts[0].normal.x != 0;
            if (isWallTouch) return;
            _inAir = false;
        }
        
        if (other.transform.CompareTag("FloatPlatform")) // Передаем персонажу скорость движущихся платформ
            transform.parent = other.transform;
    }
}