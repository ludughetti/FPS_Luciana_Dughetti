using UnityEngine;

public class PlayerCombat : CharacterCombat
{
    public bool IsPointingAtEnemy()
    {
        return Physics.Raycast(transform.position, transform.forward, Mathf.Infinity, target);
    }
}
