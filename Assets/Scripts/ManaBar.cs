using UnityEngine.UI;

public class ManaBar : Bar
{
    Slider slider;
    PlayerStatus playerStatus;
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        playerStatus = GetComponent<PlayerStatus>();
        slider.maxValue = playerStatus.maxMana;
        slider.value = playerStatus.currentMana;
    }

    public void UpdateBarValue(float mana)
    {
        slider.value = mana;
    }

    public void UpdateBarMax(float max)
    {
        slider.maxValue = max;
    }
}
