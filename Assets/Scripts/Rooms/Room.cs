using System.Collections;
using System.Collections.Generic;
using Characters;
using Managers;
using UnityEngine;

namespace Rooms
{
	public class Room : MonoBehaviour
	{
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
		
		public virtual void CharacterInteracts(Character character)
		{
			character.PickNewRoom();
		}
	}

}
