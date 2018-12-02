using UnityEngine;

public interface IInputService
{
    float GetAxisRaw(string axisName);
    bool GetButton(string buttonName);
}

class UnityInputService : IInputService
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
        return Input.GetButton(buttonName);
    }
}
