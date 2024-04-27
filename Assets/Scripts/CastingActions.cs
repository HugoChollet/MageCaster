using UnityEngine;
using UnityEngine.InputSystem;

public class CastingActions : MonoBehaviour
{
    public Key castKey = Key.A;
    public GameObject cast;

    private void Update()
    {
        if (Keyboard.current.FindKeyOnCurrentKeyboardLayout(castKey.ToString()).isPressed)
        {

            Debug.Log(Input.inputString + " key was pressed.");
            Instantiate(cast, transform.position, Quaternion.identity);
        }
    }
}