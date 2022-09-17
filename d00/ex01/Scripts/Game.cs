using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Game : MonoBehaviour
{
    
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject end;
    [SerializeField] private KeyCode key;
    private float _timeToDrop = 0;
    private float distance;
    private float speed;
    private GameObject falling;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void dropKey()
    {
        falling = Instantiate(start, start.transform.position, start.transform.rotation);
    }
    
    // Update is called once per frame
    void Update()
    {
        _timeToDrop -= Time.deltaTime;
        if (_timeToDrop < 0 || falling == null)
        {
            if (falling != null) Destroy(falling);
            dropKey();
            _timeToDrop = Random.Range(1f, 3f);
            distance = falling.transform.position.y - end.transform.position.y;
            speed = distance / _timeToDrop;
        }
        
        falling.transform.Translate(Vector3.down * Time.deltaTime * speed);

        bool tooLate = falling.transform.position.y < end.transform.position.y;
        if ((Input.GetKeyDown(key) || tooLate) && falling != null)
        {
            distance = falling.transform.position.y - end.transform.position.y;
            Debug.Log("Precision: " + distance);
            
            Destroy(falling);
            falling = null;
        }
       
    }
}
