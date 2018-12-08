using UnityEngine;

public class EmitParticlesOnEvent : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private EventType eventType;
    [SerializeField] private int amount = 100;
	
    private void OnEnable()
    {
        EventManager.Instance.AddListener(eventType, OnEvent);
    }

    private void OnDisable()
    {
        EventManager.Instance.RemoveListener(eventType, OnEvent);
    }

    private void OnEvent(object arg)
    {
        particles.Emit(amount);
    }
}
