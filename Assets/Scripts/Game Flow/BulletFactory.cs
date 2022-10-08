using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    public GameObject bulletObject;
    public int maxPoolSize; 

    [HideInInspector]
    private List<GameObject> bulletPool;
    void Start()
    {
        bulletPool = new List<GameObject>(maxPoolSize);
    }

    // Update is called once per frame
    private GameObject CreateBullet() 
    {
        GameObject bullet = GameObject.Instantiate(bulletObject);

        bullet.SetActive(false);
        bulletPool.Add(bullet);

        return bullet;
    }

    public GameObject GetBullet()
    {
        foreach(GameObject bullet in bulletPool) 
        {
            if (!bullet.activeInHierarchy)
                return bullet;
        }

        if (bulletPool.Count < maxPoolSize) 
            return CreateBullet();
        
        return null;
    }
}
