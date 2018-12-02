using UnityEngine;

public interface IUnityService
{
    float GetDeltaTime();
    float GetAxisRaw(string axisName);
}

class UnityService : IUnityService
{
    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }

    public float GetAxisRaw(string axisName)
    {
        return Input.GetAxisRaw(axisName);
    }
}