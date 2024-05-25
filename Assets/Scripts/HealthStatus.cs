public class HealthStatus : Status
{
    public override void InitStatus()
    {
        statusBarInstance = FindObjectOfType<HealthBar>();
    }
}