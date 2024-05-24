
public class ManaBar : StatusBar
{
    public override void InitStatus()
    {
        slider.maxValue = playerStatus.maxMana;
        slider.value = playerStatus.currentMana;
    }
}
