using System.Collections;
using System.Collections.Generic;
using Characters;
using Managers;
using UnityEngine;

namespace Rooms
{
	public class Room : MonoBehaviour
	{
		protected int infrastructureLevel;

		private RoomVisualReferences roomVisualReferences;
		
		private const int infraUpgradeCost = 100;

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
				if (character.targetRoom == this)
				{
					CharacterInteracts(character);
				}
			}
		}

		protected void UpgradeInfrastructure()
		{
			if (ResourceManager.instance.RemoveFunds(infraUpgradeCost))
			{
				infrastructureLevel++;
				FloatingTextManager.instance.ShowFloatingText($"{gameObject.name}- used {infraUpgradeCost.ToString()} to upgrade infrastructure to {infrastructureLevel.ToString()}", transform.position);
				roomVisualReferences.UpdateInfrastructureVisual(infrastructureLevel);
			}
		}

		protected virtual void CharacterInteracts(Character character)
		{
			if (Random.Range(0, 100) >= 90)
			{
				UpgradeInfrastructure();
			}
			character.PickNewRoom();
		}
	}

}
