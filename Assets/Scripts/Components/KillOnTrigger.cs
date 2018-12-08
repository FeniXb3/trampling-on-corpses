using UnityEngine;

public class KillOnTrigger : MonoBehaviour
{
    private SpawnPoint spawnPoint;

    private void Start()
    {
        spawnPoint = GameObject.FindWithTag("SpawnPoint").GetComponent<SpawnPoint>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ShouldKill(other))
        {
            Kill(other.gameObject);
        }
    }

    private bool ShouldKill(Collider2D other)
    {
        return other.CompareTag("Player") && other.GetComponent<Dead>() == null;
    }

    private void Kill(GameObject objectToKill)
    {
        objectToKill.AddComponent<Dead>();
        spawnPoint.SpawnNewPlayer();
    }
}