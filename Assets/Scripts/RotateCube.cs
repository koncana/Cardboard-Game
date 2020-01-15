using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    public float spinForce;
    public bool move;

    public float delta = 1.5f;  
    public float speed = 2.0f;
    private Vector3 startPos;

    void Update()
    {
        transform.Rotate(0, spinForce * Time.deltaTime, 0);

        if (move)
        {
            Vector3 v = startPos;
            v.x += delta * Mathf.Sin(Time.time * speed);
            transform.position = v;
        }
        
    }

    private void Start()
    {
        startPos = transform.position;
    }
}
