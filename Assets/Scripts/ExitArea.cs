using UnityEngine;

public class ExitArea : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            sceneController.NextLevel();
        }
    }
}