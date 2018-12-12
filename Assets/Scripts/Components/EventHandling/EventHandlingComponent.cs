using UnityEngine;

public abstract class EventHandlingComponent : MonoBehaviour
{
	[SerializeField] private EventType eventType;
	[SerializeField] private bool runOnce = true;
	
	private void OnEnable()
	{
		EventManager.Instance.AddListener(eventType, OnEventWithCheck);
	}

	private void OnDisable()
	{
		EventManager.Instance.RemoveListener(eventType, OnEventWithCheck);
	}

	private void OnEventWithCheck(object arg)
	{
		OnEvent(arg);
		if (runOnce)
		{
			enabled = false;
		}
	}

	protected abstract void OnEvent(object arg);
}
