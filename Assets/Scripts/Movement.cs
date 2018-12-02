using UnityEngine;

public class Movement
{
    private readonly float speed;

    public Movement(float speed)
    {
        this.speed = speed;
    }

    public Vector3 Calculate(float horizontal, float deltaTime)
    {
        var x = horizontal * speed * deltaTime;
        return new Vector3(x, 0, 0);
    }
}