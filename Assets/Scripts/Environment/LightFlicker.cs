using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    [SerializeField] private Light lightObj;
    [SerializeField] private float maxInterval = 1;
    [SerializeField] private float maxFlicker = 0.2f;
    [SerializeField] private float minIntensity = 0.1f;

    private float _defaultIntensity;
    private bool _isOn;
    private float _timer;
    private float _delay;

    private void Start()
    {
        _defaultIntensity = lightObj.intensity;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _delay)
        {
            ToggleLight();
        }
    }

    void ToggleLight()
    {
        _isOn = !_isOn;

        if (_isOn)
        {
            lightObj.intensity = _defaultIntensity;
            _delay = Random.Range(0, maxInterval);
        }
        else
        {
            lightObj.intensity = Random.Range(minIntensity, _defaultIntensity);
            _delay = Random.Range(0, maxFlicker);
        }

        _timer = 0;
    }
}
