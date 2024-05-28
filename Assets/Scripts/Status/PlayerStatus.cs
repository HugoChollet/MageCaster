using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public HealthStatus healthStatus;
    public ManaStatus manaStatus;

    void Start()
    {
    }

    void Update()
    {
        healthStatus.ManageStatus();
        manaStatus.ManageStatus();
    }
}