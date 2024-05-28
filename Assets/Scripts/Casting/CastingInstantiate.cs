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
            // Debug.Log(Input.inputString + " key was pressed.");
            counter += Time.deltaTime;
            if (counter > cast.GetComponent<Cast>().castingTime)
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
        if (playerStatus.manaStatus.UseStatus(cast.GetComponent<Cast>().manaCost))
        {
            Instantiate(cast, cast.GetComponent<Cast>().DetermineSpawn(), cast.GetComponent<Cast>().DetermineRotation());

        }
    }


}