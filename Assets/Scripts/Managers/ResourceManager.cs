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
	}

}
