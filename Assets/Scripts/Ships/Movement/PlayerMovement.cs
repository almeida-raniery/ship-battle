using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : ShipMovement
{
    public TMP_Text speedDisplay;
    void Update() {
        ControlAcceleration();
        ControlSteering();

        speedDisplay.text = string.Format("{0:00.0}m/s", rb2D.velocity.sqrMagnitude);
    }

    void ControlAcceleration() 
    {
        bool accelButtonDown = Input.GetButtonDown("Accelerate");
        bool decelButtonDown = Input.GetButtonDown("Decelerate");
        int sailPos          = sailPosIndex;

        if(accelButtonDown && sailPosIndex < sailSpeeds.Length - 1) 
        {
            sailPos += 1;
        } 
        else if (decelButtonDown && sailPosIndex > 0)
        {
            sailPos -=1;
        }

        SetSailPos((SailPosition) sailPos);
    }

    void ControlSteering()
    {
        float hAxis    = Input.GetAxis("Horizontal");
        torque = hAxis * -steeringSpeed;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();   
    }
}
