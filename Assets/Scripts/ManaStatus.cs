using UnityEngine;

public class ManaStatus : Status
{
    public StatusBar manaBarInstance;

    public override void UpdateStatusBarValue(float status)
    {
        if (manaBarInstance != null)
        {
            manaBarInstance.UpdateBarValue(status);
        }
    }
}