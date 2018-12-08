﻿using UnityEngine;

public class SetAnimatorTriggerOnEvent : MonoBehaviour
{
	[SerializeField] private Animator animator;
	[SerializeField] private EventType eventType;
	[SerializeField] private string triggerName;
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
		animator.SetTrigger(triggerName);
		if (runOnce)
		{
			enabled = false;
		}
	}
}
