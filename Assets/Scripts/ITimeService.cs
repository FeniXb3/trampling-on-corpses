using UnityEngine;

public interface ITimeService
{
    float GetDeltaTime();
}

class UnityTimeService : ITimeService
{
    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }
}