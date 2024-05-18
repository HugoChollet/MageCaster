using UnityEngine;


public class Cast : MonoBehaviour
{
    public float quality = 100;
    public float castingTime = 0;
    public float lifetime = 5;
    public virtual Vector3 determineSpawn()
    {
        Debug.Log("oui");

        return transform.position;
    }

    private int cost = 0;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    void FixedUpdate()
    {

    }

}
