using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    
    private void OnEnable()
    {
        EventManager.Instance.AddListener(EventType.Kill, OnKill);
    }

    private void OnDisable()
    {
        EventManager.Instance.RemoveListener(EventType.Kill, OnKill);
    }

    private void OnKill(object arg)
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