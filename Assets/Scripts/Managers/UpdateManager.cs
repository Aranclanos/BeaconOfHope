using System;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Managers
{
	public class UpdateManager : MonoBehaviourSingleton<UpdateManager>
	{
		private List<Action> updateActions = new List<Action>();

		//TODO: currently unused, for tracking in case of infinite loops
		private bool MidInvokeCalls;
		public Action LastInvokedAction { get; private set; }


		public static void Add(Action action)
		{
			instance.updateActions.Add(action);
		}

		public static void Remove(Action action)
		{
			instance.updateActions.Remove(action);
		}

		private void Update()
		{
			MidInvokeCalls = true;
			for (int i = updateActions.Count; i >= 0; i--)
			{
				if (i < updateActions.Count)
				{
					LastInvokedAction = updateActions[i];
					try
					{
						updateActions[i].Invoke();
					}
					catch (Exception e)
					{
						Debug.LogError(e.ToString());
					}
				}
			}

			MidInvokeCalls = false;
		}
	}
}