using UnityEngine;
public class EnemyChaser : EnemyBase
{
    public float disengageDelay;
    private Timer disengageTimer;
    private Transform target;

    protected override void Start()
    {
        base.Start();

        disengageTimer = new Timer(disengageDelay);
    }


    protected override void FixedUpdate()
    {
        if (isFollowing)
            RotateTowardsTarget(target, transform.up);

        base.FixedUpdate();
    }

    void Update()
    {
        if (!disengageTimer.isDone)
            disengageTimer.Tick();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
            Engage(other.transform);
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player")
            disengageTimer.SetAlarm(Disengage);
    }    

    protected override void Disengage()
    {
        target      = null;
        isFollowing = false;
        torque      = 0;
        rb2D.angularVelocity = 0;

       SetSailPos(SailPosition.Low);
    }

    protected override void Engage(Transform other)
    {
        target      = other;
        isFollowing = true;

        SetSailPos(SailPosition.Full);
    }
}
