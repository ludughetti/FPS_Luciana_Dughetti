using UnityEngine;

public class MaterialLightFlicker : MaterialFlicker
{    
    [SerializeField] private float minIntensity = 0.1f;
    [SerializeField] private Renderer lightMeshRenderer;

    private float _defaultIntensity;
    private Light _light;

    private void Start()
    {
        _light = GetComponent<Light>();
        _defaultIntensity = _light.intensity;

        Material[] materials = lightMeshRenderer.materials;
        foreach (var material in materials)
        {
            if (material.name.Contains(materialName))
            {
                _material = material;
                break;
            }
        }
    }

    protected override void Toggle()
    {
        if(_isOn)
        {
            _light.intensity = _defaultIntensity;
            _material.SetColor(emissionColorField, onColor);
        }
        else
        {
            _light.intensity = Random.Range(minIntensity, _defaultIntensity);
            _material.SetColor(emissionColorField, offColor);
        }
    }
}
