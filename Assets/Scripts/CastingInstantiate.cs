using UnityEngine;
using UnityEngine.InputSystem;

public class CastingInstantiate : MonoBehaviour
{
    public Key castKey = Key.A;
    public GameObject cast;

    float counter = 0;

    private void Update()
    {
        InstantiateCasting();
    }

    private void InstantiateCasting()
    {
        if (Keyboard.current.FindKeyOnCurrentKeyboardLayout(castKey.ToString()).isPressed)
        {
            // Debug.Log(Input.inputString + " key was pressed.");
            counter += Time.deltaTime;
            if (counter > cast.GetComponent<Cast>().castingTime)
            {
                counter = 0;
                Instantiate(cast, cast.GetComponent<Cast>().determineSpawn(), cast.GetComponent<Cast>().determineRotation());
            }
        }
        else
        {
            counter = 0;
        }
    }


}