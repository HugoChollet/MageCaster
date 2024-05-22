using UnityEngine.UI;

public class ManaBar : Bar
{
    public int maxMana = 100;
    public int playerMana;
    Slider slider;
    void Start()
    {
        playerMana = maxMana;
        slider = GetComponentInChildren<Slider>();
    }

    void Update()
    {
        slider.maxValue = maxMana;
        slider.value = playerMana;
    }
}
