using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField] private LayerMask target;
    [SerializeField] private Weapon weapon;

    public void Shoot()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Mathf.Infinity, target)) 
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
}