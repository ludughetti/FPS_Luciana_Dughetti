using UnityEngine;

public class EnemyCombat : CharacterCombat
{
    private bool _hasTargetInAttackRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"{name}: player found, attacking...");
            _hasTargetInAttackRange = true;

            if(!weapon.IsInCooldown())
                Attack();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_hasTargetInAttackRange && !weapon.IsInCooldown()
                && other.CompareTag("Player"))
            Attack();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            _hasTargetInAttackRange = false;
    }
}