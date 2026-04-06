using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = transform.forward * speed;
        Destroy(gameObject, 3f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Target")
            Debug.Log("HIT");

        Destroy(gameObject);
    }
}
