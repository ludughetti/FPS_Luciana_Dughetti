using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField] protected LayerMask target;
    [SerializeField] protected Weapon weapon;

    public void Attack()
    {
        bool wasTargetHit = weapon.Attack(target, out var targetHit);
        Debug.Log($"{name}: Attack executed, was target hit? {wasTargetHit}");

        if (wasTargetHit)
            DamageEnemy(targetHit);
    }

    private void DamageEnemy(GameObject targetHit)
    {
        if (targetHit.TryGetComponent<CharacterHealth>(out var targetHealth))
            targetHealth.TakeDamage(weapon.GetWeaponDamage());
    }
}