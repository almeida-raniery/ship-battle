using UnityEngine;
public class EnemyChaser : EnemyBase
{
    public float disengageDelay;
    public int damage;
    private Timer disengageTimer;
    protected override void Start()
    {
        base.Start();

        disengageTimer = new Timer(disengageDelay);

        Engage(target);
    }


    protected override void FixedUpdate()
    {
        if (isFollowing)
            RotateTowardsTarget(target, transform.up);
        
        Debug.DrawLine(transform.position, targetPos, Color.red, Time.deltaTime);
        base.FixedUpdate();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
            SetSailPos(SailPosition.Full);
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player")
            SetSailPos(SailPosition.Low);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ShipHealth playerHealth = other.gameObject.GetComponent<ShipHealth>();

            playerHealth.TakeDamage(damage);
            gameObject.SetActive(false);
        }
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
    }
}
