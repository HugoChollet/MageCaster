using UnityEngine;
using UnityEngine.InputSystem;

public class CastingInstantiate : MonoBehaviour
{
    public Key castKey = Key.A;
    public GameObject cast;
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
            if (counter > cast.GetComponent<Magic>().castingTime)
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
        if (playerStatus.manaStatus.UseStatus(cast.GetComponent<Magic>().manaCost))
        {
            Instantiate(cast, cast.GetComponent<Magic>().DetermineSpawn(), cast.GetComponent<Magic>().DetermineRotation());
        }
    }


}