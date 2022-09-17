using System;
using UnityEngine;

namespace Prefabs.Obstacles.Scripts
{
    public class MovablePlatform : MonoBehaviour
    {

        [SerializeField] private float distanceX = 0;
        [SerializeField] private float distanceY = 3;
        private int _directionX = 1;
        private int _directionY = 1;
        private Vector3 _startPosition;

        private void Start()
        {
            _startPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 currentPosition = transform.position - _startPosition;
            if (currentPosition.x > distanceX || currentPosition.x < -distanceX)
                _directionX *= -1;
            if (currentPosition.y > distanceY || currentPosition.y < -distanceY)
                _directionY *= -1;
            
            
            transform.Translate(new Vector3(
                distanceX * Time.deltaTime * _directionX,
                distanceY * Time.deltaTime * _directionY,
                0            
            ));
        }
    }
}
