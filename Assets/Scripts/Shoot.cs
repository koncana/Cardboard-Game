using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject ball;
    public float handPower;
    public Camera cam;
    private Collider ballCol;
    private Rigidbody ballRb;

    private float start = 0;
    private bool pointed = false;

    private int count = 0;

    void Start()
    {        
        ballCol = ball.GetComponent<SphereCollider>();
        ballRb = ball.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (pointed && (Time.time - start) >= 0.5)
        {
            ballCol.isTrigger = false;
            ballRb.useGravity = true;
            ball.GetComponent<PlayerGrab>().enabled = false;
            ball.transform.SetParent(null);
            ballRb.velocity = cam.transform.rotation * Vector3.forward * handPower; 
            ball.GetComponent<PlayerGrab>().setFalseGrabed();
            pointed = false;
        } else
        {
            ball.GetComponent<PlayerGrab>().enabled = true;
        }
    }

    public void Fire()
    {
        if (ball.GetComponent<PlayerGrab>().isGrabbed())
        {
            start = Time.time;
            pointed = true; 
        }
    }
}
