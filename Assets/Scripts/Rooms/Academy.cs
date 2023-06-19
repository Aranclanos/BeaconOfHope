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
			if (ResourceManager.instance.RemoveFunds(learningCost))
			{
				StartCoroutine(character.DoWork(10, UpgradeEtiquette, this));
			}
			else
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

