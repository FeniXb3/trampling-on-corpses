using UnityEngine;

public class ExitArea : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    [SerializeField] private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            sceneController.NextLevel(sceneToLoad);
        }
    }
}