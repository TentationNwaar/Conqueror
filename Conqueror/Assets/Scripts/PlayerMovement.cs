using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 30000f;
    public float sidewaysForce = 70f;
    public float upForce = 30f;
    private bool canJump = true;
    public GameObject pauseMenu;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Add a forward force
        rb.AddForce(0,0,forwardForce * Time.deltaTime);

        if (Input.GetKey("d")|| Input.GetKey("right"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0,ForceMode.VelocityChange);
        }

        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0,ForceMode.VelocityChange);
        }        

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        
        if (canJump == true && Input.GetKey("space"))
        {
            rb.AddForce(Vector3.up * upForce);
            StartCoroutine(CanJump());
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            pauseMenu.gameObject.SetActive(true);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Fly")
        {
            rb.AddForce(Vector3.up * 30000);
        }

        if (collision.collider.tag == "Ground")
        {
           canJump = true;
        }
    }

    public IEnumerator CanJump()
    {
        yield return new WaitForSeconds(0.3f);
        canJump = false;
        
    }
}
