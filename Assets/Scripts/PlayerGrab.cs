using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGrab : MonoBehaviour
{
    public GameObject myHand;

    private bool pointed = false;
    private bool grabbed = false;
    private float start = 0;
    public int numberTargets;

    private Collider ballCol;
    private Rigidbody ballRb;

    public Button button;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Destroy(collision.gameObject);
            numberTargets--;

            if (numberTargets == 0)
            {
                button.gameObject.SetActive(true);
            }
        }
    }

    private void Start()
    {
        button.gameObject.SetActive(false);
        ballCol = GetComponent<SphereCollider>();
        ballRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (pointed && (Time.time - start) >= 0.5)
        {
            Grab();
        }
    }

    public void Point()
    {
        if (!pointed)
        {
            pointed = true;
            start = Time.time;
        }
        else
        {
            pointed = false;
        }
    }

    void Grab()
    {
        ballCol.isTrigger = true;
        transform.SetParent(myHand.transform);
        transform.localPosition = new Vector3(0, -.75f, 0f);
        ballRb.useGravity = false;
        ballRb.velocity = Vector3.zero;
        grabbed = true;
    }

    public Rigidbody getRigid()
    {
        return ballRb;
    }

    public Collider getColl()
    {
        return ballCol;
    }

    public bool isGrabbed()
    {
        return grabbed;
    }

    public void setFalseGrabed()
    {
        grabbed = false;
    }
}
