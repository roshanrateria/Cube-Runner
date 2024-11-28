using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovementScript : MonoBehaviour
{
    public float speed = -15f;
    public float respawnDistance = 20f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = transform.forward * speed * Time.fixedDeltaTime;

        // Check if the ground object is about to go out of view
        if (transform.position.z < -respawnDistance)
        {
            // Respawn the object
            Respawn();
        }
    }

    void Respawn()
    {
        // Destroy the current object
        Destroy(gameObject);

        // Instantiate a new object at the respawn position

        GameObject newGround = Instantiate(gameObject, new Vector3(0, 0, 130f), Quaternion.identity);
        GroundMovementScript groundScript = newGround.GetComponent<GroundMovementScript>();
        if (groundScript != null)
        {
            groundScript.enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // If the object enters a trigger collider (e.g., a camera trigger), destroy it
        if (other.tag == "CameraTrigger")
        {
            Destroy(gameObject);
        }
    }
}