using UnityEngine;

public class HPBar : SliderBar
{
    [SerializeField] private CharacterHealth characterHealth;

    private void Start()
    {
        _currentValue = characterHealth.GetCurrentHealth();
        sliderBar.value = _currentValue;
        sliderBar.maxValue = _currentValue;
    }

    private void OnEnable()
    {
        characterHealth.OnDamageTaken += UpdateBarOnDamageReceived;
        characterHealth.OnDeath += UpdateBarValueOnDeath;
    }

    private void OnDisable()
    {
        characterHealth.OnDamageTaken -= UpdateBarOnDamageReceived;
        characterHealth.OnDeath -= UpdateBarValueOnDeath;
    }

    private void UpdateBarOnDamageReceived(float damageReceived)
    {
        _currentValue -= damageReceived;
    }

    private void UpdateBarValueOnDeath()
    {
        _currentValue = 0f;
    }
}