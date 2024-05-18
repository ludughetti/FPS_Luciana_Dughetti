using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] protected ProjectileTrace trace;
    [SerializeField] private Transform barrelEnd;
    [SerializeField] private ParticleSystem smokeEffect;

    private void OnEnable()
    {
        OnWeaponAttack += PlaySmokeEffect;
        OnWeaponAttack += CreateProjectileTrace;
    }

    private void OnDisable()
    {
        OnWeaponAttack -= PlaySmokeEffect;
        OnWeaponAttack -= CreateProjectileTrace;
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

    public override void AttackWithWeapon(Vector3 hitPosition)
    {
        if (_currentWeaponCooldown <= 0f)
        {
            TriggerWeaponCooldown();
            OnWeaponAttack.Invoke(hitPosition);
        }
        else
            Debug.Log($"Weapon still in cooldown: {_currentWeaponCooldown}");
    }
}
