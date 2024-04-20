using UnityEngine;

public enum ElementType
{
    Fire,
    Water,
    Earth,
    Metal,
    Snow,
    Stone
}
public class Element : MonoBehaviour
{
    public ElementType element = ElementType.Fire;
    public Material materialElement;
    public float mass = 1;
    public float cost = 1;
}