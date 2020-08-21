using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blaster : MonoBehaviour
{
    public ParticleSystem Blast;
    private Vector3 blastpos;
    public bool activated =false;
    public float timer = 3f;
    public int explosionradius =25;
    private GameObject ball;
    public Collider[] enemies;
    public Image bar;
    // Start is called before the first frame update
    void Start()
    { 
        Blast.Clear();
        blastpos= new Vector3(90f, 0f, 0f);
        ball = GameObject.FindGameObjectWithTag("Player");
    }

    void Blst()
    {
        if (Input.GetKey(KeyCode.Space) && !activated)
        {
            activated = true;
            ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            Blast.transform.rotation = Quaternion.Euler(blastpos);
            Blast.Play();
            enemies = Physics.OverlapSphere(ball.transform.position, explosionradius);
            foreach(Collider i in enemies  )
            {
                if(i.tag == "Enemies")
                {
                    Vector3 oppdir = (i.transform.position - ball.transform.position);
                    float dist = Vector3.Distance(ball.transform.position, i.transform.position);
                    dist = 10 - dist;
                    i.attachedRigidbody.AddForce(oppdir  * 30* dist);
                }
            }
            FunctionTimer.Create(() => ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None, 1f);
            FunctionTimer.Create(() => Blast.Stop(), timer);
            FunctionTimer.Create(() => Blast.Clear(), timer);
            FunctionTimer.Create(() => activated = false, timer);
            

        }
    }

    // Update is called once per frame
    void Update()
    {

        Blst();
            
    }
}
