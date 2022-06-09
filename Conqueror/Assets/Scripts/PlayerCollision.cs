using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    private Rigidbody rb;
    public float upForce = 40f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {        
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
            
        }

        if (collision.collider.tag == "Fly")
        {
            Debug.Log("");
            //rb.AddForce(Vector3.up * 30);

        }
    }
}
