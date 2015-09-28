using UnityEngine;
using System.Collections;

public class FuelGenerater : MonoBehaviour {

    public Vector2 velocity = new Vector2(-2, 0);
    public float range = 4;

    // Use this for initialization
    void Start()
    {

        GetComponent<Rigidbody2D>().velocity = velocity;
        transform.position = new Vector3(transform.position.x, transform.position.y - range * Random.value, transform.position.z);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
