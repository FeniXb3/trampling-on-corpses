using UnityEngine;

public class SetAnimatorTriggerOnEvent : EventHandlingComponent
{
	[SerializeField] private Animator animator;
	[SerializeField] private string triggerName;

	protected override void OnEvent(object arg)
	{
		animator.SetTrigger(triggerName);
	}
}
