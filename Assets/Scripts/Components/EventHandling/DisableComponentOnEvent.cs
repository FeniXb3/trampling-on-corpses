using System.Collections;
using UnityEngine;

public class DisableComponentOnEvent : MonoBehaviour
{
	[SerializeField] private MonoBehaviour component;
	[SerializeField] private EventType eventType;
	[SerializeField] private bool runOnce = true;
	
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
		component.enabled = false;
		
		if (runOnce)
		{
			enabled = false;
		}
	}

}
