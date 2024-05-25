
using UnityEngine;
using UnityEngine.UI;


public class StatusBar : MonoBehaviour
{

    protected Slider slider;
    protected Status status;
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        InitStatus();
        InitCommonStatus();
    }

    public virtual void InitStatus() { }

    public void InitCommonStatus()
    {
        slider.maxValue = status.maxStatus;
        slider.value = status.currentStatus;
    }

    public void UpdateBarValue(float status)
    {
        slider.value = status;
    }

    public void UpdateBarMax(float max)
    {
        slider.maxValue = max;
    }
}
