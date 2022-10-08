using UnityEngine;

public delegate void AlarmDelegate();
class Timer 
{
    public float count;
    public float stepScale;
    public bool isDone;
    public bool repeat;

    private float maxDelay;
    private AlarmDelegate alarm;
    public Timer(float maxDelay, bool repeat = false, float stepScale = 1)
    {
        this.maxDelay  = maxDelay;
        this.stepScale = stepScale;
        this.count     = maxDelay;
        this.repeat    = repeat;
        this.isDone    = true;
    }

    public void Reset()
    {
        count  = 0;
        isDone = false;
    }

    public float Tick()
    {
        isDone  = count >= maxDelay; 

        if(!isDone)
        {
            count  += Time.deltaTime * stepScale;
        }
        else
        {
            alarm?.Invoke();

            if(repeat)
                Reset();
        }

        return count;
    }

    public void SetAlarm(AlarmDelegate alarm) 
    {
        this.alarm = alarm;

        Reset();
    }

    public void Stop()
    {
        count  = maxDelay;
        isDone = true;
    }

    public void UnsetAlarm()
    {
        alarm = null;
        Stop();
    }
}

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
