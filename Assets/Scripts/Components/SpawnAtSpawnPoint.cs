using UnityEngine;

public class SpawnAtSpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject spawnPointPrefab;
    
    private void Awake()
    {
        SetSpawnPosition();
    }

    private void SetSpawnPosition()
    {
        var spawnPoint = GameObject.FindWithTag("SpawnPoint");

        if (spawnPoint == null)
        {
            spawnPoint = Instantiate(spawnPointPrefab, transform.position, transform.rotation);
        }

        transform.position = spawnPoint.transform.position;
    }
}