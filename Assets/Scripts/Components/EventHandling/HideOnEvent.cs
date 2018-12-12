using System.Collections;
using UnityEngine;

public class HideOnEvent : EventHandlingComponent
{
	[SerializeField] private SpriteRenderer rendererToHide;
	[SerializeField] private float delay = 0.2f;

	protected override void OnEvent(object arg)
	{
		StartCoroutine(HidePlayerBody());
	}
	
	IEnumerator HidePlayerBody()
	{
		yield return new WaitForSeconds(delay);
		rendererToHide.enabled = false;
	}
}
