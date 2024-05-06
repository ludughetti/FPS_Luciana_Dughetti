using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float projectileDamage = 20f;
    [SerializeField] protected float weaponRange = 10f;
    [SerializeField] protected ProjectileTrace trace;
    [SerializeField] private Transform barrelEnd;
    [SerializeField] private ParticleSystem smokeEffect;

    public Action<Vector3> OnWeaponFired = delegate { };

    private void OnEnable()
    {
        OnWeaponFired += PlaySmokeEffect;
        OnWeaponFired += CreateProjectileTrace;
    }

    private void OnDisable()
    {
        OnWeaponFired -= PlaySmokeEffect;
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

    private void PlaySmokeEffect(Vector3 hitPosition)
    {
        smokeEffect.Play();
    }
}