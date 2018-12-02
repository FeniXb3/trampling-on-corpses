using UnityEngine;

public class Movement
{
    private readonly float speed;
    private readonly float jumpForce;

    public Movement(float speed, float jumpForce)
    {
        this.speed = speed;
        this.jumpForce = jumpForce;
    }

    public float GetHorizontalSpeed()
    {
        return Mathf.Abs(Input.GetAxisRaw("Horizontal"));
    }

    public Vector3 CalculateHorizontal(float horizontal, float deltaTime)
    {
        var x = horizontal * speed * deltaTime;
        return new Vector3(x, 0, 0);
    }

    public Vector2 CalculateJump()
    {
        return new Vector2(0, jumpForce);
    }
}