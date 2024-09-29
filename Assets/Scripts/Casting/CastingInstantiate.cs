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
        GameObject magicObject = magicGrid.GetSelectedMagic().gameObject;
        Vector3 posMagic = magicGrid.GetSelectedMagic().DetermineSpawn();
        Quaternion rotMagic = magicGrid.GetSelectedMagic().DetermineRotation();

        if (playerStatus.manaStatus.UseStatus(magicGrid.GetSelectedMagic().manaCost))
        {
            Instantiate(magicObject, posMagic, rotMagic);
        }
    }
}