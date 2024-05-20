using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private ParticleSystem hitParticle;

    public event Action<float> OnHeal = delegate { };
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
        TakeDamage(10f);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log($"{name}: {damage} damage received");
        _health -= damage;

        if(hitParticle != null)
            hitParticle.Play();

        if (_health <= 0)
            OnDeath.Invoke();
        else
            OnDamageTaken.Invoke(_health);
    }

    public float GetCurrentHealth()
    {
        return _health;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void Heal(float healAmount)
    {
        Debug.Log($"{name}: Healing player for {healAmount}");
        _health += healAmount;
        Debug.Log($"{name}: Player was healed, currentHP is {_health}");

        if (_health >= maxHealth)
            _health = maxHealth;

        OnHeal.Invoke(_health);
    }
}
