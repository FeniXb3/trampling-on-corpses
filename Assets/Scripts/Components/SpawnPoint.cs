using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    public void SpawnNewPlayer()
    {
        var spawnPoint = GameObject.FindWithTag("SpawnPoint").transform;
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}