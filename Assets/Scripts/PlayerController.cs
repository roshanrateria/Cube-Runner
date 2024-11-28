using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
//Animator anim;

    [SerializeField]
    float speed;
    bool canjump;
    [SerializeField]
    float jumpForce;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
      //  anim = GetComponent<Animator>();
    }
    void Start()
    {
       // rb.velocity = Vector3.forward * speed;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canjump)
        {

           // anim.SetTrigger("jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canjump = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canjump = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("Game");
        }
    }
}
