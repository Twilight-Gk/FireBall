using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firescript : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rb;
    public TrailRenderer tr;
    public float magnitude;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody>();
        tr = player.GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 speed = rb.velocity;
        magnitude = speed.magnitude;
        if(magnitude > 10)
        {
            tr.enabled = true;
        }
        else
        {
            tr.enabled = false;
        }
    }
}
