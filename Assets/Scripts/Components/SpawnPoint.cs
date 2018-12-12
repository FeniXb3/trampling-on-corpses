using UnityEngine;

public class SpawnPoint : EventHandlingComponent
{
    [SerializeField] private GameObject playerPrefab;

    protected override void OnEvent(object arg)
    {
        var killedObject = arg as GameObject;
        if(killedObject != null && killedObject.CompareTag(playerPrefab.tag))
        {
            SpawnNewPlayer();
        }
    }

    private void SpawnNewPlayer()
    {
        var spawnPoint = GameObject.FindWithTag("SpawnPoint").transform;
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}