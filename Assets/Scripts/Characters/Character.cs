using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using Rooms;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


namespace Characters
{
	public class Character : MonoBehaviour
	{
		//references
		public Transform progressBar;
		private float progressBarPercentagePoint;
		private NavMeshAgent navMeshAgent;

		//variables
		[NonSerialized] public Room targetRoom;
		[NonSerialized] public bool isWorking;
		
		//stats
		[NonSerialized] public int dignity;
		[NonSerialized] public int etiquette;
		private void Awake()
		{
			progressBar.gameObject.transform.parent.gameObject.SetActive(false);
			navMeshAgent = GetComponent<NavMeshAgent>();
			progressBarPercentagePoint = progressBar.localScale.x / 100;
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

		public void UpgradeEtiquette()
		{
			etiquette++;
		}
		
		public IEnumerator DoWork(float totalTime, Action<Character> action, Room room)
		{
			progressBar.gameObject.transform.parent.gameObject.SetActive(true);
			isWorking = true;
			room.availableSlots--;
			float time = 0;
			while (time < totalTime)
			{
				time += Time.deltaTime;
				var timePercentage = time / (totalTime / 100);
				var progressBarSize = progressBarPercentagePoint * timePercentage;
				progressBar.localScale = new Vector3(progressBarSize, progressBar.localScale.y, 1);
				yield return null;
			}
			progressBar.gameObject.transform.parent.gameObject.SetActive(false);
			isWorking = false;
			room.availableSlots++;
			action.Invoke(this);
			PickNewRoom();
		}

	}
}

