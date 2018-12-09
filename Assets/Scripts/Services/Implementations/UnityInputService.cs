using UnityEngine;

namespace Services.Implementations
{
    class UnityInputService : IInputService
    {
        public float GetAxisRaw(string axisName)
        {
            return Input.GetAxisRaw(axisName);
        }

        public bool GetButton(string buttonName)
        {
            return Input.GetButton(buttonName);
        }
    }
}
