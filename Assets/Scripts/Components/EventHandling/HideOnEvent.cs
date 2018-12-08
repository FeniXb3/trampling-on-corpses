using System.Collections;
using UnityEngine;

public class HideOnEvent : MonoBehaviour
{
	[SerializeField] private SpriteRenderer rendererToHide;
	[SerializeField] private EventType eventType;
	[SerializeField] private float delay = 0.2f;
	
	private void OnEnable()
	{
		EventManager.Instance.AddListener(eventType, OnEvent);
	}

	private void OnDisable()
	{
		EventManager.Instance.RemoveListener(eventType, OnEvent);
	}

	private void OnEvent(object arg)
	{
		StartCoroutine(HidePlayerBody());
	}
	
	IEnumerator HidePlayerBody()
	{
		yield return new WaitForSeconds(delay);
		rendererToHide.enabled = false;
	}

}
