using UnityEngine;

public class ExitArea : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            EventManager.Instance.TriggerEvent(EventType.ChangeLevel, sceneToLoad);
        }
    }
}