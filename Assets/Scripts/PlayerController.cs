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
    private int jumps;

    //Variabelen voor mijn gravity Jump
    public float jumpFallMulitplier = 1f;
    public float lowJumpMultiplier = 1f;

    //Variabelen voor Wall Jump
    private int wallJumps;
    public float wallJumpHeight = 20f;
    public int wallJumpRepelForce = 16;
    private bool isOnWall;
    private int Side;

    //Variabelen voor verschillende platforms
    public float Boost = 10f;
    public float jumpForce = 10f;

    //test UI 
    public GameObject testWallJump; 

    private void Awake()
    { 
        rb = GetComponent<Rigidbody>();
        testWallJump.SetActive(false);
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
        if (Input.GetButtonDown("Jump") && jumps < 2 && !isOnWall)
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            jumps++;
            Debug.Log("Ik spring" + jumps);
        }

        // checked of hij op de muur zit 
        //if (Input.GetButtonDown("Jump") && jumps == 0 && isOnWall == true)
        //{
           //rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
           //jumps++;
        //}

        //Gravity aanpassing op mijn Jump, Low Jump is als je maar een keer springt.  
        if (rb.velocity.y < 0)
        {
           rb.velocity += Vector3.up * Physics.gravity.y * (jumpFallMulitplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButtonDown("Jump"))
        {
           rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        Debug.Log("wallJump count is" + wallJumps);

    }

    // Jump check, Dit checked of mijn Player op de grond zit. 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "blue" || collision.gameObject.tag == "orange")
        {
            jumps = 0;
            wallJumps = 0;
            isGrounded = true;              
        }

        //Wall Jump Check
       //if (!isGrounded && wallJumps < 1 && collision.gameObject.tag == "BlueWall" && Input.GetButtonDown("Jump") || !isGrounded && wallJumps < 1 && collision.gameObject.tag == "OrangeWall" && Input.GetButtonDown("Jump"))
        //{           
           //rb.AddForce(new Vector3(Side, wallJumpHeight, 0), ForceMode.Impulse);
           //wallJumps++;
           //Debug.Log("WallJump");
        //}

        //Console tekst test
        if (collision.gameObject.tag == "BlueWall" || collision.gameObject.tag == "OrangeWall")
        {
            Debug.Log("HitwallEnterCol");          
        }

        //Jump Platform
        if (collision.gameObject.tag == "PlatformJump")
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumps = 2;
            Debug.Log("Ik sta op een Jump pad!");
        }

    }

    //Checked aan welke kant je van de muur staat. 
    private void OnTriggerEnter(Collider collision)
    {
        if (this.gameObject.transform.position.x < collision.gameObject.transform.position.x)
        {
            Debug.Log("links");
            Side = wallJumpRepelForce * -1;
        }
        else if (this.gameObject.transform.position.x > collision.gameObject.transform.position.x)
        {
            Debug.Log("rechts");
            Side = wallJumpRepelForce;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        //Wall jump Mechanic, Dit zorgt ervoor dat je kan springen vanaf de muur. 

        if (!isGrounded && wallJumps < 1 && collision.gameObject.tag == "BlueWall" && Input.GetButtonDown("Jump") || !isGrounded && wallJumps < 1 && collision.gameObject.tag == "OrangeWall" && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(Side, wallJumpHeight, 0), ForceMode.Impulse);
            wallJumps++;
            Debug.Log("WallJump");          
        }

        //Checked of je de muur aanraakt
        if (collision.gameObject.tag == "BlueWall" || collision.gameObject.tag == "OrangeWall")
        {
            isOnWall = true; 
            Debug.Log("HitWall");
        }
        testWallJump.SetActive(true);
    }

    // Verschillende platforms met ablities
    private void OnCollisionStay(Collision collision)
    {
        //Boost Platform
        if (collision.gameObject.tag == "PlatformBoost")
        {
            rb.AddForce(transform.forward * Boost, ForceMode.Impulse);
            Debug.Log("Ik sta op een boost pad!");
        }
    }

    //Checked of je niet op de muur meer bent
    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "BlueWall" || collision.gameObject.tag == "OrangeWall")
        {
            isOnWall = false;           
        }
        testWallJump.SetActive(false);
    }

    //Checked of je van de grond af bent
    private void OnCollisionExit(Collision collision) 
    {
        //Collission with ground
        if(collision.gameObject.tag == "ground" || collision.gameObject.tag == "blue" || collision.gameObject.tag == "orange")
        {
            isGrounded = false;
        }
    }




}