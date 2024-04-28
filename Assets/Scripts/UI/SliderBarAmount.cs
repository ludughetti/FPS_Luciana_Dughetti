using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderBarAmount : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Slider sliderBar;

    void Update()
    {
        text.text = Mathf.Round(sliderBar.value).ToString();
    }
}
