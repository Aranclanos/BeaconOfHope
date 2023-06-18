using System.Collections;
using System.Collections.Generic;
using Managers;
using Rooms;
using UnityEngine;
using UnityEngine.AI;


namespace Characters
{
	public class Character : MonoBehaviour
	{
		private NavMeshAgent navMeshAgent;

		public Room targetRoom;

		public int dignity;
		
		private void Awake()
		{
			navMeshAgent = GetComponent<NavMeshAgent>();
		}

		private void Start()
		{
			PickNewRoom();
		}

		public void PickNewRoom()
		{
			targetRoom = RoomsManager.instance.PickRandomRoom();
			navMeshAgent.destination = targetRoom.transform.position;
		}

	}
}

