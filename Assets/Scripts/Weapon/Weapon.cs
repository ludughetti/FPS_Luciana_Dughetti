using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float weaponDamage = 20f;
    [SerializeField] protected float weaponRange = 10f;
    [SerializeField] protected float weaponCooldown = 1f;

    public Action<Vector3> OnWeaponAttack = delegate { };

    protected float _currentWeaponCooldown = 0f;

    private void Update()
    {
        if (_currentWeaponCooldown > 0f)
            _currentWeaponCooldown -= Time.deltaTime;
    }

    public virtual void AttackWithWeapon(Vector3 hitPosition)
    {
        Debug.Log($"{name}: AttackWithWeapon not implemented for base Weapon class");
    }

    public float GetWeaponDamage()
    {
        return weaponDamage;
    }

    public float GetWeaponRange()
    {
        return weaponRange;
    }
    
    protected void TriggerWeaponCooldown()
    {
        _currentWeaponCooldown = weaponCooldown;
    }

}