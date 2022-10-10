using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector2 offset;
    private ShipMovement targetMovement;
    void Start()
    {
        targetMovement = target.GetComponent<ShipMovement>();

    }
    void Update()
    {
        transform.position = new Vector3 (target.position.x, target.position.y, transform.position.z);
    }
}
