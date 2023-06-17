using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
	private NavMeshAgent navMeshAgent;

	public int dignity;

	public Vector3 DEBUGtargetDestination;

	private void Awake()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	private void Update()
	{
		if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
		{
			navMeshAgent.destination = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
			DEBUGtargetDestination = navMeshAgent.destination;
		}
	}


}
