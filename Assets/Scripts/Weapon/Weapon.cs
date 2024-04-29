using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float weaponRange = 10f;
    [SerializeField] protected BulletTrace trace;
    [SerializeField] private Transform barrelEnd;

    public virtual void FireWeapon(Vector3 hitPosition)
    {
        CreateBulletTrace(hitPosition);
    }

    public float GetWeaponRange()
    {
        return weaponRange;
    }

    private void CreateBulletTrace(Vector3 hitPosition)
    {
        BulletTrace instanceRenderer = Instantiate(trace, barrelEnd.position, Quaternion.identity);
        instanceRenderer.RenderBulletTrace(hitPosition);
    }
}