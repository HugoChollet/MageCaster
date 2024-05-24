using UnityEngine;


public class Cast : MonoBehaviour
{
    public float quality = 100;
    public float castingTime = 0;
    public float lifetime = 5;
    public float manaCost = 0;

    public virtual Vector3 DetermineSpawn()
    {
        return transform.position;
    }

    public virtual Quaternion DetermineRotation()
    {
        return transform.rotation;
    }

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    void FixedUpdate()
    {

    }

}
