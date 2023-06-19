using System;
using System.Collections;
using System.Collections.Generic;
using Characters;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Rooms
{
	public class Room : MonoBehaviour
	{
		protected int infrastructureLevel;

		private RoomVisualReferences roomVisualReferences;

		[NonSerialized] public int availableSlots = 1;
		private const int infraUpgradeCost = 1000;

		private bool beingUpgraded;
		
		private void Awake()
		{
			roomVisualReferences = GetComponent<RoomVisualReferences>();
		}

		private void Start()
		{
			RoomsManager.instance.AddRoom(this);
		}

		private void OnTriggerStay(Collider other)
		{
			if (other.TryGetComponent<Character>(out var character))
			{
				if (character.isWorking)
				{
					return;
				}

				if (character.targetRoom == this)
				{
					if (availableSlots > 0)
					{
						CharacterInteracts(character);
					}
					else
					{
						character.PickNewRoom();
					}
				}
			}
		}

		protected void UpgradeInfrastructure(Character character)
		{
			infrastructureLevel++;
			availableSlots++;
			FloatingTextManager.instance.ShowFloatingText($"{gameObject.name}- used {infraUpgradeCost.ToString()} to upgrade infrastructure to {infrastructureLevel.ToString()}", transform.position);
			roomVisualReferences.UpdateInfrastructureVisual(infrastructureLevel);
			beingUpgraded = false;
		}

		protected virtual void CharacterInteracts(Character character)
		{
			if (Random.Range(0, 100) >= 90 && ResourceManager.instance.RemoveFunds(infraUpgradeCost) && beingUpgraded == false)
			{
				beingUpgraded = true;
				StartCoroutine(character.DoWork(10, UpgradeInfrastructure, this));
			}
			else
			{
				character.PickNewRoom();
			}
		}
	}

}
