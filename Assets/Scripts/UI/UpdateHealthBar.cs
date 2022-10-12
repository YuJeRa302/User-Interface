using UnityEngine;
using UnityEngine.UI;

public class UpdateHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        _slider.value = _slider.maxValue;
    }

    public void UpdateUI(int value) 
    {
        _slider.value = value;
    }
}