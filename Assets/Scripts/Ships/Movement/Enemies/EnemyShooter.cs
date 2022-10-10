using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyShooter : EnemyBase
{
    public UnityEvent onPlayerClose;
    public UnityEvent onPlayerEscape;

    private Cannon[] cannons;

    protected override void Start()
    {
        base.Start();

        cannons = GetComponentsInChildren<TurretCannon>();

        foreach (TurretCannon cannon in cannons)
            cannon.target = target;

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
            Disengage();
        
        onPlayerClose.Invoke();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            Engage(target.transform);

        onPlayerEscape.Invoke();
    }

    protected override void Engage(Transform other)
    {
        SetSailPos(SailPosition.Mid);
        isFollowing  = true;
    }

    protected override void Disengage()
    {
        isFollowing  = false;
        torque      = 0;
        rb2D.angularVelocity = 0;

        SetSailPos(SailPosition.Folded);
    }
}
