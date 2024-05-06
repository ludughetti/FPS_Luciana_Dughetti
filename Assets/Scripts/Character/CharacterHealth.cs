using System;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;

    public event Action<float> OnDamageTaken = delegate { };
    public event Action OnDeath = delegate { };

    private float _health;
    private string playerTag = "Player";

    private void OnEnable()
    {
        _health = maxHealth;
        OnDeath += RemoveCharacterOnDeath;
    }

    private void OnDisable()
    {
        OnDeath -= RemoveCharacterOnDeath;
    }

    [ContextMenu("TakeDamage")]
    public void MockTakeDamage()
    {
        TakeDamage(10f);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log($"{name}: {damage} damage received");
        _health -= damage;

        if (_health <= 0)
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

    private void RemoveCharacterOnDeath()
    {
        Debug.Log($"{name}: Character dead");

        if(!playerTag.Equals(gameObject.tag))
            Destroy(gameObject);
    }
}
