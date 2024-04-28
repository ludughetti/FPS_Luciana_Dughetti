using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    [SerializeField] protected float sliderSpeed = 1f;
    [SerializeField] protected Slider sliderBar;

    protected float _currentValue = 0f;
    private float _barVelocity = 0f;

    private void Update()
    {
        float sliderValue = Mathf.SmoothDamp(sliderBar.value, _currentValue, ref _barVelocity, sliderSpeed * Time.deltaTime);
        sliderBar.value = sliderValue;
    }
}