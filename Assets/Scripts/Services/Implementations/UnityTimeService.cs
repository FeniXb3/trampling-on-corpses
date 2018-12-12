using UnityEngine;

namespace Services.Implementations
{
    class UnityTimeService : ITimeService
    {
        public float GetDeltaTime()
        {
            return Time.deltaTime;
        }
    }
}