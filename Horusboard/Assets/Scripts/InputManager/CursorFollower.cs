using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class CursorFollower : MonoBehaviour
{
    [SerializeField] 
    private Vector2Reference cursorPosition;
   
    
    // Update is called once per frame
    void Update()
    {
        transform.position = cursorPosition.Value;
    }
}
