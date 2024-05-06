using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float weaponRange = 10f;
    [SerializeField] protected BulletTrace trace;
    [SerializeField] private Transform barrelEnd;

    public Action<Vector3> OnWeaponFired = delegate { };

    private void OnEnable()
    {
        OnWeaponFired += CreateBulletTrace;
    }

    private void OnDisable()
    {
        OnWeaponFired -= CreateBulletTrace;
    }

    public virtual void FireWeapon(Vector3 hitPosition)
    {
        OnWeaponFired.Invoke(hitPosition);
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