using System;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;

    public event Action<float> OnDamageTaken = delegate { };
    public event Action OnDeath = delegate { };

    private float _health;

    private void OnEnable()
    {
        _health = maxHealth;
    }

    [ContextMenu("TakeDamage")]
    public void MockTakeDamage()
    {
        ReceiveDamage(10f);
    }

    public void ReceiveDamage(float damage)
    {
        Debug.Log($"{name}: {damage} damage received");
        _health -= damage;

        if(_health <= 0)
            OnDeath.Invoke();
        else
            OnDamageTaken.Invoke(damage);
    }

    public float GetCurrentHealth()
    {
        return _health;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
}
