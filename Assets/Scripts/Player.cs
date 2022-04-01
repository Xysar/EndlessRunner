using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public ParticleSystem dust;
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;

    public int collected = 0;
    public bool hitGround = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        //horizontalInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {

        rigidbodyComponent.velocity = new Vector3( 4f, rigidbodyComponent.velocity.y, 0);
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            hitGround = true;
            return;
        }

        if (hitGround)
        {

            CreateDust();
        
            hitGround = false;
        }

        if (jumpKeyWasPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * 7f, ForceMode.VelocityChange);
            CreateDust();
        
            jumpKeyWasPressed = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            collected++;
        }
        if(other.gameObject.tag == "killbox")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void CreateDust()
    {
        dust.Play();
    }

   
}
