using UnityEngine;

public enum SailPosition {
    None,
    Low,
    Mid,
    Full
}

public class ShipMovement : MonoBehaviour
{
    [HideInInspector]
    public float fullSpeed;
    [HideInInspector]
    public float midSpeed;
    [HideInInspector]
    public float lowSpeed;
    [HideInInspector]
    public float acceleration;
    [HideInInspector]
    public float steeringSpeed;
    [HideInInspector]
    public float driftCompRate;
    [HideInInspector]
    public SailPosition sailPosition;

    private float prevSpeed;
    private float accelerationRate;

    protected Rigidbody2D rb2D;
    protected float maxSpeed;
    protected float currentSpeed;
    protected float torque;
    protected float[] sailSpeeds;
    protected int sailPosIndex;

    protected virtual void Start()
    {
        rb2D         = GetComponent<Rigidbody2D>();
        sailSpeeds   = new float[4] {0, lowSpeed, midSpeed, fullSpeed};

        SetSailPos(sailPosition);
    }

    protected virtual void FixedUpdate()
    {
        UpdateSpeed();
        HandleDrift();

        rb2D.AddForce(transform.up * currentSpeed);
        rb2D.AddTorque(torque);
    }

    protected void UpdateSpeed() 
    {
        float delta       = maxSpeed - currentSpeed;
        float movePercent = acceleration/delta;

        accelerationRate = Mathf.Clamp(accelerationRate + movePercent, 0, 1);
        currentSpeed     = Mathf.Lerp(prevSpeed, maxSpeed, accelerationRate);
    }

    protected void HandleDrift() 
    {
        float hDrift         = Vector2.Dot(rb2D.velocity, transform.right);
        float compensation   = hDrift * driftCompRate;
        Vector2 counterForce = compensation * -transform.right;

        rb2D.AddForce(counterForce, ForceMode2D.Impulse);
    }

    protected int SetSailPos(SailPosition position)
    {
        int index = (int) position;

        maxSpeed     = sailSpeeds[index];
        sailPosIndex = index;

        return index;
    }
}
