using UnityEngine;

public class Status : MonoBehaviour
{
    public int maxStatus = 100;
    public float statusCooldown = 1;
    public float statusRegen = 0.001f;
    public float currentStatus;
    public static StatusBar statusBarInstance;
    private float statusCounter = 0;

    void Start()
    {
        InitStatus();
    }

    public virtual void InitStatus() { }

    public bool UseStatus(float cost)
    {
        if (currentStatus >= cost)
        {
            UpdateStatusBarValue(currentStatus - cost);
            currentStatus -= cost;
            statusCounter = 0;
            return true;
        }
        return false;
    }

    public void ManageStatus()
    {
        if (currentStatus < maxStatus)
        {
            statusCounter += Time.deltaTime;
            if (statusCounter > statusCooldown)
            {
                currentStatus += statusRegen;
                UpdateStatusBarValue(currentStatus);
            }
        }
        else if (currentStatus > maxStatus)
        {
            currentStatus = maxStatus;
            UpdateStatusBarValue(maxStatus);
        }
    }

    void UpdateStatusBarValue(float status)
    {
        if (statusBarInstance != null)
        {
            statusBarInstance.UpdateBarValue(status);
        }
    }
}