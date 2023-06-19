using System.Collections;
using System.Collections.Generic;
using Characters;
using Managers;
using UnityEngine;

namespace Rooms
{
	public class Academy : Room
	{
		private int learningCost = 100;
		protected override void CharacterInteracts(Character character)
		{
			var pickedActivity = Random.Range(0, 2);
			if (pickedActivity == 0)
			{
				StartCoroutine(character.DoWork(10, UpgradeEtiquette, this));
			}
			else if (pickedActivity == 1)
			{
				base.CharacterInteracts(character);
			}
		}

		private void UpgradeEtiquette(Character character)
		{
			FloatingTextManager.instance.ShowFloatingText($"Academy- used {learningCost.ToString()} funds: {character.name} upgraded etiquette", transform.position);
			character.UpgradeEtiquette();
		}
	}
}

