using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightDangerUI : MonoBehaviour
{
    public float visibilityScale = 0;
    public float downSpeed = 1;
    public Image progressBarLine;
    public bool isVisible = false;

    private float lineMaxSize;

    private void Start()
    {
        lineMaxSize = progressBarLine.transform.localScale.x;
    }

    private void FixedUpdate()
    {
        if (visibilityScale > 0)
        {
            visibilityScale -= Time.fixedDeltaTime * downSpeed;
        }

        var localScale = progressBarLine.transform.localScale;
        localScale.Set(
            lineMaxSize / 100 * visibilityScale,
            localScale.y,
            localScale.z
        );
        progressBarLine.transform.localScale = localScale;

        progressBarLine.color = visibilityScale > 75 ? Color.red : Color.white;
    }
}