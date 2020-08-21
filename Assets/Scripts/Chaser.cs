using UnityEngine;
using System.Collections;
using UnityEngine.AI;

//[RequireComponent(typeof(CharacterController))]

public class Chaser : MonoBehaviour {
	
	public float speed = 20.0f;
	public float minDist = 1f;
	public Transform target;
    public NavMeshAgent EnemyNavmesh;
    public float actdist = 50f;
    public float reset = 0;
	// Use this for initialization
	void Start () 
	{
		// if no target specified, assume the player
		if (target == null) {

			if (GameObject.FindWithTag ("Player")!=null)
			{
				target = GameObject.FindWithTag ("Player").GetComponent<Transform>();
			}
		}
        EnemyNavmesh = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (target == null)
			return;

		// face the target
		transform.LookAt(target);
        EnemyNavmesh.SetDestination(target.transform.position);
        //get the distance between the chaser and the target
        float dist = Vector3.Distance(this.gameObject.transform.position, target.transform.position);
        if (dist < actdist)
        {
            actdist = dist;
        }
        else
        {
            dist = Vector3.Distance(this.gameObject.transform.position, target.transform.position);
            if (dist > 20f)
            {
                Debug.Log("Constriants in action");
                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                actdist = Vector3.Distance(this.gameObject.transform.position, target.transform.position);
            }
        }
       

        



    }
    
	// Set the target of the chaser
	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}

}
