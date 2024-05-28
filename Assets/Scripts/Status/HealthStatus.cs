public class HealthStatus : Status
{
    public StatusBar healthBarInstance;

    public override void UpdateStatusBarValue(float status)
    {
        if (healthBarInstance != null)
        {
            healthBarInstance.UpdateBarValue(status);
        }
    }
}