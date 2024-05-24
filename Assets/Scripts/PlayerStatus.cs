using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int maxMana = 100;
    public float manaCooldown = 1;
    public float manaRegen = 0.001f;
    public float currentMana;
    private float counter = 0;


    void Start()
    {
        currentMana = maxMana;
    }

    void Update()
    {
        if (currentMana < maxMana)
        {
            counter += Time.deltaTime;
            if (counter > manaCooldown)
            {
                currentMana += manaRegen;
                UpdateManaBarValue(currentMana);
            }
        }
        else if (currentMana > maxMana)
        {
            currentMana = maxMana;
            UpdateManaBarValue(maxMana);
        }
    }

    public bool UseMana(float cost)
    {
        if (currentMana >= cost)
        {
            UpdateManaBarValue(currentMana - cost);
            currentMana -= cost;
            counter = 0;
            return true;
        }
        return false;
    }

    void UpdateManaBarValue(float mana)
    {
        ManaBar manaBarInstance = FindObjectOfType<ManaBar>();
        if (manaBarInstance != null)
        {
            manaBarInstance.UpdateBarValue(mana);
        }
    }
}