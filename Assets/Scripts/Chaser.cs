using UnityEngine;
using System.Collections;
using UnityEngine.AI;

//[RequireComponent(typeof(CharacterController))]

public class Chaser : MonoBehaviour {
	
	public float speed = 20.0f;
	public float minDist = 1f;
	public Transform target;
    public NavMeshAgent EnemyNavmesh;

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
		
	}

	// Set the target of the chaser
	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}

}
