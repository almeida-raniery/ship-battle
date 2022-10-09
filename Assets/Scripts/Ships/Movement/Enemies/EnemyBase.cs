using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : ShipMovement
{
    public Transform target;
    public float followOffset;

    protected Vector2 targetPos;
    protected bool isFollowing;

    protected abstract void Disengage();

    protected abstract void Engage(Transform other);

    protected void RotateTowardsTarget(Transform target, Vector3 alignAxis)
    {
        float targetSide = Vector2.Dot(transform.right, target.right);

        Vector2 offset         = targetSide * target.right * followOffset;
        Vector2 chasePosition  = (Vector2) target.position + offset;
        Vector2 delta          = chasePosition  - rb2D.position;
        Vector3 rotationVector = Vector3.Cross(delta, alignAxis);

        torque = -rotationVector.normalized.z * steeringSpeed;

        targetPos = chasePosition;
    }
}
