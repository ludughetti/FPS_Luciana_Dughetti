using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float projectileDamage = 20f;
    [SerializeField] protected float weaponRange = 10f;
    [SerializeField] protected ProjectileTrace trace;
    [SerializeField] private Transform barrelEnd;

    public Action<Vector3> OnWeaponFired = delegate { };

    private void OnEnable()
    {
        OnWeaponFired += CreateProjectileTrace;
    }

    private void OnDisable()
    {
        OnWeaponFired -= CreateProjectileTrace;
    }

    public virtual void FireWeapon(Vector3 hitPosition)
    {
        OnWeaponFired.Invoke(hitPosition);
    }

    public float GetProjectileDamage()
    {
        return projectileDamage;
    }

    public float GetWeaponRange()
    {
        return weaponRange;
    }

    private void CreateProjectileTrace(Vector3 hitPosition)
    {
        ProjectileTrace instanceRenderer = Instantiate(trace, barrelEnd.position, Quaternion.identity);
        instanceRenderer.RenderBulletTrace(hitPosition);
    }
}