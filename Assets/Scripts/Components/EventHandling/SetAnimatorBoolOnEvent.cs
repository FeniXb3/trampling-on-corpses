using UnityEngine;

public class SetAnimatorBoolOnEvent : MonoBehaviour
{
	[SerializeField] private Animator animator;
	[SerializeField] private EventType eventType;
	[SerializeField] private string boolName;
	[SerializeField] private bool targetValue = true;
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
		animator.SetBool(boolName, targetValue);
		if (runOnce)
		{
			enabled = false;
		}
	}
}
