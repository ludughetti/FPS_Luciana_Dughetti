using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float projectileDamage = 20f;
    [SerializeField] protected float weaponRange = 10f;
    [SerializeField] protected float weaponCooldown = 1f;
    [SerializeField] protected ProjectileTrace trace;
    [SerializeField] private Transform barrelEnd;
    [SerializeField] private ParticleSystem smokeEffect;

    public Action<Vector3> OnWeaponFired = delegate { };

    private float _currentWeaponCooldown = 0f;
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

    private void Update()
    {
        if (_currentWeaponCooldown > 0f)
            _currentWeaponCooldown -= Time.deltaTime;
    }

    public virtual void FireWeapon(Vector3 hitPosition)
    {
        if(_currentWeaponCooldown <= 0f)
        {
            TriggerWeaponCooldown();
            OnWeaponFired.Invoke(hitPosition);
        }
        else
            Debug.Log($"Weapon still in cooldown: {_currentWeaponCooldown}");
    }

    public float GetProjectileDamage()
    {
        return projectileDamage;
    }

    public float GetWeaponRange()
    {
        return weaponRange;
    }
    
    private void TriggerWeaponCooldown()
    {
        _currentWeaponCooldown = weaponCooldown;
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