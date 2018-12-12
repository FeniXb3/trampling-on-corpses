namespace Services
{
    public interface IInputService
    {
        float GetAxisRaw(string axisName);
        bool GetButton(string buttonName);
    }
}
