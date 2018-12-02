using UnityEngine;

public interface IUnityService
{
    float GetDeltaTime();
    float GetAxisRaw(string axisName);
    bool GetButton(string buttonName);
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

    public bool GetButton(string buttonName)
    {
        return Input.GetButton("Jump");
    }
}