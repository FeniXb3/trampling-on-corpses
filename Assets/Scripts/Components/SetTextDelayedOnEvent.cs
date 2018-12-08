using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SetTextDelayedOnEvent : MonoBehaviour
{
	[SerializeField] private Text textComponent;
	[SerializeField] private EventType eventType;
	[Tooltip("This string will be replaced with parameter sent when event was triggered")]
	[SerializeField] private string placeholder = "{arg}";
	[SerializeField] private string textTemplate;
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
		var value = arg.ToString();
		StartCoroutine(SetTextDelayed(value));
	}
	
	IEnumerator SetTextDelayed(string value)
	{
		yield return new WaitForSeconds(delay);
		textComponent.text = textTemplate.Replace(placeholder, value);
	}
}
