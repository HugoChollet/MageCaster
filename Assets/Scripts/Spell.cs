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
        Transform cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;

        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        // The extents of the Bounding Box. This is always half of the size of the Bounds.
        float spellSize = mesh.bounds.extents.z * transform.localScale.z;

        // Calculate the spawn position around the player
        Quaternion rotAroundPlayer = Quaternion.Euler(0, anglePos, 0);
        Vector3 distanceFromPlayer = rotAroundPlayer * cameraTransform.forward * (distance + spellSize);
        Vector3 spawnPosition = playerTransform.position + distanceFromPlayer;

        return spawnPosition;
    }

    public override Quaternion determineRotation()
    {
        Transform cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;

        // Calculate the spawn position around the player
        Quaternion rotation = Quaternion.LookRotation(cameraTransform.forward);

        return rotation;
    }

}
