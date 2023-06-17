using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Visual
{
	public class MaterialCopy : MonoBehaviour
	{

		void Start()
		{
			var meshRenderer = GetComponent<MeshRenderer>();
			var meshRenderers = GetComponentsInChildren<MeshRenderer>();
			foreach (var childrenMeshRenderer in meshRenderers)
			{
				childrenMeshRenderer.material = meshRenderer.material;
			}
		}
	    
	}
}


