using UnityEngine;
using UnityEngine.Events;

public class CannonBall : MonoBehaviour
{
    public float speed;
    public float range;
    public int damage;
    [HideInInspector]
    public Vector3 startPos;
    [HideInInspector]

    private Rigidbody2D rb2D;

    private new Collider2D collider;

    void Start(){
        startPos = startPos == null? startPos : transform.position;
        rb2D     = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 delta  = transform.position - startPos;
        float distance = delta.sqrMagnitude;
        
        if(distance >= range)
            gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        rb2D.velocity = transform.right * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ShipHealth shipHealth = other.GetComponentInParent<ShipHealth>();

        if(shipHealth)
        {
            shipHealth?.TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
