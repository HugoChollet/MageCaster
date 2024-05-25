public class ManaStatus : Status
{
    public override void InitStatus()
    {
        statusBarInstance = FindObjectOfType<ManaBar>();
    }
}