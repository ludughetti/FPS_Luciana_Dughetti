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

    public override bool Attack(LayerMask target, out GameObject targetHit)
    {
        if (_currentWeaponCooldown > 0f)
        {
            Debug.Log($"Weapon still in cooldown: {_currentWeaponCooldown}");

            targetHit = null;
            return false;
        }

        TriggerWeaponCooldown();
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, GetWeaponRange(), target))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.point.magnitude, Color.yellow, 2);
            OnWeaponAttack.Invoke(hit.point);

            targetHit = hit.transform.gameObject;
            return true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * GetWeaponRange(), Color.white, 2);
            OnWeaponAttack.Invoke(transform.forward * GetWeaponRange());
        }

        targetHit = null;
        return false;
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
