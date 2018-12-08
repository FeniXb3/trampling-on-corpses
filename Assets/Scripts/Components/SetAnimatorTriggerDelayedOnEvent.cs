using System.Collections;
using UnityEngine;

public class SetAnimatorTriggerDelayedOnEvent : MonoBehaviour
{
	[SerializeField] private Animator animator;
	[SerializeField] private EventType eventType;
	[SerializeField] private string triggerName;
	[SerializeField] private float delay = 1.5f;
	
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
		StartCoroutine(SetTriggerDelayed());
	}
	
	IEnumerator SetTriggerDelayed()
	{
		yield return new WaitForSeconds(delay);
		animator.SetTrigger(triggerName);
	}
}
