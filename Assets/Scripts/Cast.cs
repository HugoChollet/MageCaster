using UnityEngine;

public enum Direction
{
    forward,
    upward,
    downward,
    backward,
}

public class Cast : MonoBehaviour
{
    public float quality = 100;
    public float castingTime = 0;
    public float lifetime = 5;
    public Element element; // Element Object like Fire, water...

    public int speed;
    public float distance = 1;
    public int position = 0; // Position range from 0 - 360 degrees around the player

    public Direction direction = Direction.forward;

    private int cost = 0;

    void Start()
    {
        Destroy(gameObject, lifetime);
        GetComponent<Renderer>().material = element.materialElement;
    }
    void FixedUpdate()
    {

    }

}
