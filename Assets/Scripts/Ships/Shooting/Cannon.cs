using UnityEngine;

public abstract class Cannon : MonoBehaviour
{
    public BulletFactory bulletFactory;
    public float shootingRate;

    public abstract void Shoot();

    protected CannonBall MakeBullet() 
    {
        GameObject bullet          = bulletFactory.GetBullet();
        CannonBall bulletBehaviour = bullet.GetComponent<CannonBall>();
        
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bulletBehaviour.startPos  = transform.position;

        bulletBehaviour.gameObject.layer = gameObject.layer;
        
        return bulletBehaviour;
    }
}
