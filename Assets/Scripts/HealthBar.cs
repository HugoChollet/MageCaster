public class HealthBar : StatusBar
{
    public override void InitStatus()
    {
        status = FindFirstObjectByType<PlayerStatus>().healthStatus;
    }
}
