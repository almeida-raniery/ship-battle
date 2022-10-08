using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCannon : FrontCannon
{
    // Start is called before the first frame update
    public Transform target;
    public Vector2 aimOffset;
    public float rotationSpeed;
    private Timer shootingTimer;
    public bool isAiming;
    void Start()
    {
        shootingTimer = new Timer(shootingRate, true);
    }

    // Update is called once per frame
    void Update()
    {
        if(!shootingTimer.isDone)
            shootingTimer.Tick();
        
        if (isAiming)
            AimAtTarget();
    }

    public void StartAiming()
    {
        isAiming=true;
        shootingTimer.SetAlarm(Shoot);
    }

    public void StopAiming()
    {
        isAiming=false;
        shootingTimer.UnsetAlarm();
    }

    void AimAtTarget()
    {
        float targetSide = Vector2.Dot(transform.position, target.right);

        Vector3 offset         = Mathf.Sign(targetSide) * aimOffset;
        Vector3 chasePosition  = target.position + offset;
        Vector3 delta          = chasePosition  - transform.position;

        float rotationRate     = Vector3.Cross(delta, transform.right).z;

        transform.Rotate(-rotationRate * transform.forward * rotationSpeed) ;
    }
}
