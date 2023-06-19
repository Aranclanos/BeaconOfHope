using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Characters;
using UnityEngine;
using Managers;
using ResourceManager = Managers.ResourceManager;

namespace Rooms
{
	public class Chancery : Room
	{

		private int tradeRoutes;
		private float tradeRouteTimer = 0;
		
		private const float tradeRouteTimeLimit = 20;
		private const int tradeRouteReward = 10;
		private const int taxesReward = 1;
		private const int diplomaticGift = 100;
		private const int enemyAssets = 1000;

		private void Update()
		{
			if (tradeRoutes > 0)
			{
				tradeRouteTimer += Time.deltaTime;
				if (tradeRouteTimer >= tradeRouteTimeLimit)
				{
					tradeRouteTimer = 0;
					var value = tradeRouteReward * tradeRoutes;
					FloatingTextManager.instance.ShowFloatingText($"Chancery- gained {value.ToString()} funds: taxes collected", transform.position);
					ResourceManager.instance.AddFunds(value);
				}
			}
		}

		protected override void CharacterInteracts(Character character)
		{
			var randomAction = Random.Range(0, 4);
			if (randomAction == 0)
			{
				StartCoroutine(character.DoWork(2, AddTradeRoute, this));
			}
			else if (randomAction == 1)
			{
				StartCoroutine(character.DoWork(2, SeizeEnemyAssets, this));
			}
			else if (randomAction == 2)
			{
				StartCoroutine(character.DoWork(2, DiplomaticGift, this));
			}
			else
			{
				base.CharacterInteracts(character);
			}
		}

		public void AddTradeRoute(Character character)
		{
			tradeRoutes++;
			FloatingTextManager.instance.ShowFloatingText($"Chancery- added tradeRoute, total: {tradeRoutes.ToString()}", transform.position);
		}
		
		public void DiplomaticGift(Character character)
		{
			ResourceManager.instance.AddFunds(diplomaticGift);
			FloatingTextManager.instance.ShowFloatingText($"Chancery- gained {diplomaticGift.ToString()} funds: diplomat gift", transform.position);
		}

		public void SeizeEnemyAssets(Character character)
		{
			ResourceManager.instance.AddFunds(enemyAssets);
			FloatingTextManager.instance.ShowFloatingText($"Chancery- gained {enemyAssets.ToString()} funds: seized enemy assets", transform.position);
		}
		
		/*
		 using funds:
		infrastructure, classrooms, fleet & army, diplomatic missions, court expenses 
		*/
	}

}

