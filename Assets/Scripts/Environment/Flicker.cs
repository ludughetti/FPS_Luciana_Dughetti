using UnityEngine;

public class Flicker : MonoBehaviour
{
    [SerializeField] private float maxInterval = 1;
    [SerializeField] private float maxFlicker = 0.75f;

    protected bool _isOn;
    private float _timer;
    private float _delay;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _delay)
        {
            ToggleLight();
        }
    }

    private void ToggleLight()
    {
        _isOn = !_isOn;

        if (_isOn)
        {
            Toggle();
            _delay = Random.Range(0, maxInterval);
        }
        else
        {
            Toggle();
            _delay = Random.Range(0, maxFlicker);
        }

        _timer = 0;
    }

    protected virtual void Toggle()
    {
        Debug.Log("Not implemented for Flicker class");
    }
}
