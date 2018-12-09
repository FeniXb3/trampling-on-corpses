using UnityEngine;

public class EmitParticlesOnEvent : EventHandlingComponent
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private int amount = 100;
    
    protected override void OnEvent(object arg)
    {
        particles.Emit(amount);
    }
}
