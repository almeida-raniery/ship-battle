using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        
    }
    void Update()
    {
        transform.position = new Vector3 (target.position.x, target.position.y, transform.position.z);
    }
}
