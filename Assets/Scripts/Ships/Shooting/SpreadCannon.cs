using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadCannon : Cannon
{
    public int numberOfBullets;
    [Range(20, 120)]
    public int spreadAngle;
    private int spreadMedian;
    private float spreadOffset;

    void Start()
    {
        spreadMedian = spreadAngle/numberOfBullets;
        spreadOffset = (spreadAngle/2f) - (spreadMedian/2f);
    }
    public override void Shoot() 
    {
        for (int i = 0; i < numberOfBullets; i++) 
        {
            float baseAngle   = i * spreadMedian;
            float aimAngle    = transform.rotation.eulerAngles.z;
            float bulletAngle = aimAngle + baseAngle - spreadOffset;

            Quaternion rotation = Quaternion.AngleAxis(bulletAngle, Vector3.forward);
            CannonBall bullet   = MakeBullet();

            bullet.transform.rotation = rotation;
            bullet.transform.position = new Vector3(transform.position.x, transform.position.y, 1);

            bullet.gameObject.SetActive(true);
        }
    }
}
