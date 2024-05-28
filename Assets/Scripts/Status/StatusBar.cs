
using UnityEngine;
using UnityEngine.UI;


public class StatusBar : MonoBehaviour
{

    protected Slider slider;
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
    }

    public virtual void InitStatus() { }



    public void UpdateBarValue(float status)
    {
        slider.value = status;
    }

    public void UpdateBarMax(float max)
    {
        slider.maxValue = max;
    }
}
