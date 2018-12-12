using UnityEngine;

public class SetAnimatorBoolOnEvent : EventHandlingComponent
{
	[SerializeField] private Animator animator;
	[SerializeField] private string boolName;
	[SerializeField] private bool targetValue = true;

	protected override void OnEvent(object arg)
	{
		animator.SetBool(boolName, targetValue);
	}
}
