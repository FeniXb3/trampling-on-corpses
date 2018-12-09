using System.Collections;
using UnityEngine;

public class DisableComponentOnEvent : EventHandlingComponent
{
	[SerializeField] private MonoBehaviour component;

	protected override void OnEvent(object arg)
	{
		component.enabled = false;
	}

}
