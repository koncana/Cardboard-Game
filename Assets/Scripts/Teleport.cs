using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;

    private bool pointed = false;
    private float start = 0;

    public void TeleportPlayer()
    {
        if (!pointed)
        {
            start = Time.time;
            pointed = true;
        }
        else
        {
            pointed = false;
        }
    }

    private void Update()
    {
        if (pointed && (Time.time - start) >= 0.5)
        {
            player.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            pointed = false;
        }
    }
}
