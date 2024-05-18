using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField] protected LayerMask target;
    [SerializeField] protected Weapon weapon;
    [SerializeField] 

    protected bool _isTargetInMeleeRange = false;

    public void Shoot()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, weapon.GetWeaponRange(), target)) 
        {
            Debug.DrawRay(transform.position, transform.forward * hit.point.magnitude, Color.yellow, 2);
            weapon.AttackWithWeapon(hit.point);
            DamageEnemy(hit);
        } 
        else
        {
            Debug.DrawRay(transform.position, transform.forward * weapon.GetWeaponRange(), Color.white, 2);
            weapon.AttackWithWeapon(transform.forward * weapon.GetWeaponRange());
        }
    }

    public virtual void MeleeAttack()
    {
        Debug.Log($"{name}: MeleeAttack() not implemented in CharacterCombat");
    }

    private void DamageEnemy(RaycastHit hit)
    {
        hit.transform.gameObject.GetComponent<CharacterHealth>().TakeDamage(weapon.GetWeaponDamage());
    }
}