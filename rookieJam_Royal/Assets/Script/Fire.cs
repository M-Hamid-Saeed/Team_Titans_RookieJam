using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Rigidbody rb;  // Reference to the Rigidbody component
    public float speed = 10.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Set the velocity for bullet movement
        rb.velocity = transform.up * speed;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy collision detected.");
            ObjectPooler.Instance.Free(gameObject);
        }
    }

}
