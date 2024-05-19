using UnityEngine;

public class EnemyCombat : CharacterCombat
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"{name}: player found, attacking...");
            Attack();
        }
    }
}
