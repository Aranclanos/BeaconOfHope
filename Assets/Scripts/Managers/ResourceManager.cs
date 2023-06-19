using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Managers
{
	public class ResourceManager : MonoBehaviourSingleton<ResourceManager>
	{
		public int funds;
		public int provisions;
		public int manpower;
		public int fleet;
		public int alliances;
		public int arms;
		public int information;
		public int infrastructure;
		public int reputation;
		public int horns;
		
		public int tradeRoutes;

		private const int taxesReward = 1;
		private const int diplomaticGift = 100;
		private const int enemyAssets = 1000;

		public void AddFunds(int value)
		{
			funds += value;
		}

		public bool RemoveFunds(int value)
		{
			if (funds >= value)
			{
				funds -= value;
				return true;
			}
			return false;
		}

		public void AddTradeRoute()
		{
			tradeRoutes++;
		}

		public void CollectTaxes()
		{
			funds += taxesReward;
		}

		public void DiplomaticGift()
		{
			funds += diplomaticGift;
		}

		public void SeizeEnemyAssets()
		{
			funds += enemyAssets;
		}
	}

}
