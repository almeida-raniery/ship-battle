using UnityEngine;

public class AttachedHealthBar : HealthBar
{
    public Vector3 offset;

    protected override void Update()
    {
        base.Update();

        transform.position = target.transform.position + offset;

        if(!target.gameObject.activeInHierarchy)
            gameObject.SetActive(false);
    }
}
