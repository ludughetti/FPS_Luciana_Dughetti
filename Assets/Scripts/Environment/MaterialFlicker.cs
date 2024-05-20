using UnityEngine;

public class MaterialFlicker : Flicker
{
    [SerializeField] protected Color onColor = Color.white;
    [SerializeField] protected Color offColor = Color.black;

    protected readonly string emissionColorField = "_EmissionColor";
    protected readonly string materialName = "Neon_01";
    protected Material _material;

    private void Start()
    {
        Material[] materials = GetComponent<Renderer>().materials;
        foreach (var material in materials)
        {
            if(material.name.Contains(materialName))
            {
                _material = material;
                break;
            }  
        }
    }

    protected override void Toggle()
    {
        if (_isOn)
            _material.SetColor(emissionColorField, onColor);
        else
            _material.SetColor(emissionColorField, offColor);
    }
}
