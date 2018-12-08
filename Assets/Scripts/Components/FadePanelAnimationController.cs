using UnityEngine;

public class FadePanelAnimationController : MonoBehaviour
{
	private Animator animator;
	
	private void OnEnable()
	{
		EventManager.Instance.AddListener(EventType.ChangeLevel, OnChangeLevel);
	}

	private void OnDisable()
	{
		EventManager.Instance.RemoveListener(EventType.ChangeLevel, OnChangeLevel);
	}

	private void Start()
	{
		animator = gameObject.GetComponent<Animator>();
	}

	private void OnChangeLevel(object arg)
	{
		animator.SetTrigger("SceneExit");
	}
}
