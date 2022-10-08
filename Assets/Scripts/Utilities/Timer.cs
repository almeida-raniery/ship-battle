using UnityEngine;
public delegate void AlarmDelegate();
public class Timer 
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