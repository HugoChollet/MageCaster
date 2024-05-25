public class ManaBar : StatusBar
{
    public override void InitStatus()
    {
        status = FindFirstObjectByType<PlayerStatus>().manaStatus;
    }
}
