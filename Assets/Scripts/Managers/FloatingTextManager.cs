using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utilities;

namespace Managers
{
	public class FloatingTextManager : MonoBehaviourSingleton<FloatingTextManager>
	{
		public GameObject textPrefab;
		private List<TextMeshPro> pooledTexts = new List<TextMeshPro>();
		private float speed = 2;
		private float duration = 3;
		
		public void ShowFloatingText(string text, Vector3 position)
		{
			Debug.Log(text);
			var UItext = GetText();
			UItext.text = text;
			UItext.transform.position = position;
			StartCoroutine(FloatingAnimation(UItext));
		}

		private TextMeshPro GetText()
		{
			if (pooledTexts.Count > 0)
			{
				var UItext = pooledTexts[0];
				pooledTexts.Remove(UItext);
				UItext.gameObject.SetActive(true);
				return UItext;
			}
			else
			{
				var UItextGameObject = Instantiate(textPrefab);
				var UItext = UItextGameObject.GetComponent<TextMeshPro>();
				return UItext;
			}
		}

		private IEnumerator FloatingAnimation(TextMeshPro UItext)
		{
			var startPosition = UItext.transform.position;
			var targetPosition = startPosition + new Vector3(1f, 1f, 0f) ;
			var elapsedTime = 0f;

			while (elapsedTime < duration)
			{
				var t = elapsedTime / duration;
				UItext.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			UItext.gameObject.SetActive(false);
			pooledTexts.Add(UItext);
		}


	}

}