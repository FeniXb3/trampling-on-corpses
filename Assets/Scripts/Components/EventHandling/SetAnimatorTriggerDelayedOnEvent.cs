using System.Collections;
using UnityEngine;

public class SetAnimatorTriggerDelayedOnEvent : EventHandlingComponent
{
	[SerializeField] private Animator animator;
	[SerializeField] private string triggerName;
	[SerializeField] private float delay = 1.5f;

	protected override void OnEvent(object arg)
	{
		StartCoroutine(SetTriggerDelayed());
	}
	
	IEnumerator SetTriggerDelayed()
	{
		yield return new WaitForSeconds(delay);
		animator.SetTrigger(triggerName);
	}
}
