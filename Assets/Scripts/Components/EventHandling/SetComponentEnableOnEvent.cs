using UnityEngine;

public class SetComponentEnableOnEvent : EventHandlingComponent
{
	[SerializeField] private MonoBehaviour component;
	[SerializeField] private bool targetEnableState;

	protected override void OnEvent(object arg)
	{
		component.enabled = targetEnableState;
	}

}
