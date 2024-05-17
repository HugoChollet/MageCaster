using UnityEngine;
using UnityEngine.InputSystem;

public class CastingActions : MonoBehaviour
{
    public Key castKey = Key.A;
    public GameObject cast;

    float counter = 0;

    private void Awake()
    {
        ;
    }

    private void Update()
    {
        InstantiateCasting();
    }

    private void InstantiateCasting()
    {
        if (Keyboard.current.FindKeyOnCurrentKeyboardLayout(castKey.ToString()).isPressed)
        {
            Debug.Log(Input.inputString + " key was pressed.");
            counter += Time.deltaTime;
            if (counter > cast.GetComponent<Cast>().castingTime)
            {
                counter = 0;
                Instantiate(cast, determineSpawn(), Quaternion.identity);
            }
        }
        else
        {
            counter = 0;
        }
    }

    private Vector3 determineSpawn()
    {
        // Calculate the spawn position around the player
        float angle = cast.GetComponent<Cast>().position; // Assuming 'position' is in degrees
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        Vector3 distanceFromPlayer = rotation * transform.forward * cast.GetComponent<Cast>().distance;
        Vector3 spawnPosition = transform.position + distanceFromPlayer;

        return spawnPosition;
    }
}