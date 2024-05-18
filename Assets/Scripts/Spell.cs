using UnityEngine;

public enum Direction
{
    forward,
    upward,
    downward,
    backward,
}

public class Spell : Cast
{
    public Element element; // Element Object like Fire, water...

    public int speed;
    public float distance = 1;
    public int anglePos = 0; // Position range from 0 - 360 degrees around the player

    public Direction direction = Direction.forward;

    public void Awake()
    {
        GetComponent<Renderer>().material = element.materialElement;
    }

    public override Vector3 determineSpawn()
    {
        Transform playerTransform = GameObject.FindGameObjectWithTag("CastingSpawn").transform;

        // Calculate the spawn position around the player
        Quaternion rotation = Quaternion.Euler(0, anglePos, 0);
        Vector3 distanceFromPlayer = rotation * playerTransform.forward * distance;
        Vector3 spawnPosition = playerTransform.position + distanceFromPlayer;

        return spawnPosition;
    }
}
