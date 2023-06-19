using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rooms
{
	public class RoomVisualReferences : MonoBehaviour
	{
		public List<MeshRenderer> wallsList = new List<MeshRenderer>();
		public List<Material> materialList = new List<Material>();

		public void UpdateInfrastructureVisual(int infrastructureLevel)
		{
			var material = materialList[infrastructureLevel];
			foreach (var meshRenderer in wallsList)
			{
				meshRenderer.material = material;
			}
		}
	}

}
