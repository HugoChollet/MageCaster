
using UnityEngine;
using UnityEngine.UI;


public class StatusBar : MonoBehaviour
{

    protected Slider slider;
    protected PlayerStatus playerStatus;
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        playerStatus = GetComponent<PlayerStatus>();
        InitStatus();
    }

    public virtual void InitStatus()
    {
        return;
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
