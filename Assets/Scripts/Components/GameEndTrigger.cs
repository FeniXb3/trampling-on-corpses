using UnityEngine;

public class GameEndTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            EventManager.Instance.TriggerEvent(EventType.EndGame, Dead.TotalDeaths);
        }
    }
}