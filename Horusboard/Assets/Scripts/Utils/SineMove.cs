using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMove : MonoBehaviour
{
    private float time = 0;
    // Update is called once per frame
    private Vector2 startPos;

    public bool invert;
    
    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        time += Time.deltaTime;

        transform.position = new Vector3(
            transform.position.x, 
            (!invert ? Mathf.Sin(time) : Mathf.Cos(time)), 
            transform.position.z);
    }
}
