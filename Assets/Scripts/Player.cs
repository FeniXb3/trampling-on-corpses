using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Movement movement;
    [SerializeField] private IUnityService unityService;

    private void Start()
    {
        movement = new Movement(speed);
        if (unityService == null)
        {
            unityService = new UnityService();
        }
    }

    private void FixedUpdate()
    {
        transform.position += movement.Calculate(
            unityService.GetAxisRaw("Horizontal"),
            unityService.GetDeltaTime());
    }
}