using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private Transform attackArea;

    public override bool Attack(LayerMask target, out GameObject targetHit)
    {
        if (_currentWeaponCooldown > 0f)
        {
            Debug.Log($"Weapon still in cooldown: {_currentWeaponCooldown}");

            targetHit = null;
            return false;
        }

        _currentWeaponCooldown = weaponCooldown;

        if (Physics.SphereCast(attackArea.position, weaponRange, transform.forward, out var hit, weaponRange, target))
        {
            Debug.Log($"{name}: Enemy {hit.transform.gameObject.name} was hit");
            OnWeaponAttack.Invoke(hit.point);

            targetHit = hit.transform.gameObject;
            return true;
        }

        targetHit = null;
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackArea.position, weaponRange);
    }
}
