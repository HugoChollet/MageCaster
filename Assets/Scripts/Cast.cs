using UnityEngine;


public class Cast : MonoBehaviour
{
    public float quality = 100;
    public float castingTime = 0;
    public float lifetime = 5;
    public int manaCost = 0;

    public virtual Vector3 determineSpawn()
    {
        return transform.position;
    }

    public virtual Quaternion determineRotation()
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
