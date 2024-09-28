using UnityEngine;
using UnityEngine.InputSystem;

public class CastingInstantiate : MonoBehaviour
{
    public Key castKey = Key.A;
    public MagicGrid magicGrid;
    private PlayerStatus playerStatus;

    float counter = 0;

    void Start()
    {
        playerStatus = GetComponentInParent<PlayerStatus>();
    }

    void Update()
    {
        CastingInput();
    }

    private void CastingInput()
    {
        if (Keyboard.current.FindKeyOnCurrentKeyboardLayout(castKey.ToString()).isPressed)
        {
            counter += Time.deltaTime;
            if (counter > magicGrid.GetSelectedMagic().castingTime)
            {
                counter = 0;
                CastInstantiate();
            }
        }
        else
        {
            counter = 0;
        }
    }

    private void CastInstantiate()
    {
        if (playerStatus.manaStatus.UseStatus(magicGrid.GetSelectedMagic().manaCost))
        {
            Instantiate(magicGrid.GetSelectedMagic(), magicGrid.GetSelectedMagic().DetermineSpawn(), magicGrid.GetComponent<Magic>().DetermineRotation());
        }
    }


}