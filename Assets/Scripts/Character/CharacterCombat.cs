using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField] protected LayerMask target;
    [SerializeField] protected Weapon weapon;

    public void Shoot()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, weapon.GetWeaponRange(), target)) 
        {
            Debug.DrawRay(transform.position, transform.forward * hit.point.magnitude, Color.yellow, 2);
            weapon.FireWeapon(hit.point);
        } 
        else
        {
            Debug.DrawRay(transform.position, transform.forward * weapon.GetWeaponRange(), Color.white, 2);
            weapon.FireWeapon(transform.forward * weapon.GetWeaponRange());
        }
    }

    public bool IsPointingAtEnemy()
    {
        return Physics.Raycast(transform.position, transform.forward, Mathf.Infinity, target);
    }
}