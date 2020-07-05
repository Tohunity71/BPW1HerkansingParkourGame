using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variabelen voor mijn movement
    public float moveSpeed = 3.5f;
    public float jumpHeight = 5f;
    public float vert, hor;
    public Rigidbody rb;

    //Variabelen voor mijn Jumps
    private bool isGrounded;
    [HideInInspector] public int jumps;

    //Variabelen voor mijn gravity Jump
    public float jumpFallMulitplier = 1f;
    public float lowJumpMultiplier = 1f;

    //Variabelen voor verschillende platforms
    public float jumpPadForce = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Character Controller 
        vert = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");

        Vector3 moveDir = vert * transform.forward + hor * transform.right;

        rb.MovePosition(transform.position + moveDir * Time.deltaTime * moveSpeed);

        //Jump, Het zorgt ervoor dat je maar 2 keer kan springen. 
        if (Input.GetButtonDown("Jump") && jumps < 2)
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            jumps++;
            Debug.Log("Ik spring" + jumps);
        }

        //Gravity aanpassing op mijn Jump, Low Jump is als je maar een keer springt.  
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (jumpFallMulitplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButtonDown("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }

    // Jump check, Dit checked of mijn Player op de grond zit. 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "blue" || collision.gameObject.tag == "orange")
        {
            jumps = 0;
            isGrounded = true;
        }

    }

    //Checked of je van de grond af bent
    private void OnCollisionExit(Collision collision)
    {
        //Collission with ground
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "blue" || collision.gameObject.tag == "orange")
        {
            isGrounded = false;
        }
    }

}