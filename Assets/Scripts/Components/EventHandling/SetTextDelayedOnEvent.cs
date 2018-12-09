using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SetTextDelayedOnEvent : EventHandlingComponent
{
	[SerializeField] private Text textComponent;
	[Tooltip("This string will be replaced with parameter sent when event was triggered")]
	[SerializeField] private string placeholder = "{arg}";
	[SerializeField] private string textTemplate;
	[SerializeField] private float delay = 1.5f;

	protected override void OnEvent(object arg)
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
