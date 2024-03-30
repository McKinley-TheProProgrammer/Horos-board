using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMove : MonoBehaviour
{
    private float time = 0;
    // Update is called once per frame
    private Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        time += Time.deltaTime;
        
        transform.position = Vector3.up * Mathf.Sin(time);
    }
}
