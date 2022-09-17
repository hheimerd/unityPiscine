using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SliderDoor : MonoBehaviour
{
    public bool isOpen = false;
    public Axis side = Axis.X;
    public float distance = 2;

    private Vector3 startPosition;
    private float distanceCovered = 0;
    private void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isOpen && distanceCovered < distance)
        {
            distanceCovered += (transform.forward * Time.deltaTime).magnitude;
            Debug.Log(distanceCovered);
            transform.Translate(-transform.forward * Time.deltaTime);
        }
        if (!isOpen && distanceCovered > 0)
        {
            distanceCovered -= (transform.forward * Time.deltaTime).magnitude;
            transform.Translate(transform.forward * Time.deltaTime);
        }
    }
}
