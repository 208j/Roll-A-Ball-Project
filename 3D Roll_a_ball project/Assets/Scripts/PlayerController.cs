using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Rigidbody of the player.
    private Rigidbody rb;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public GameManager gameManager;

    private int count;
    private float movementX;
    private float movementZ;
    // Jumping variables
    public float jumpForce = 6f;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementZ = movementVector.y;
    }

    void OnJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isGrounded = false;
        }
    }

    void FixedUpdate() // FixedUpdate is called at a fixed interval and is independent of frame rate. 
    {
        

        Vector3 movement = new Vector3(movementX, 0.0f, movementZ); // create a movement vector based on the input
        rb.AddForce(movement * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            if (gameManager != null)
                gameManager.EndGame(false);
            else
                loseTextObject.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter(Collider other) // OnTriggerEnter is called when the Player collides with other ogject
    {
        if (other.gameObject.CompareTag("Pickup")) // check if the other object has the tag "Pickup"
        {
            other.gameObject.SetActive(false); // deactivate the pickup object when the player collides with it
            count = count + 1; // increment the count variable by 1
            SetCountText(); // update the count text on the UI
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString(); 

        if (count >= 12)
        {
            if (gameManager != null)
                gameManager.EndGame(true);
            else
            {
                winTextObject.SetActive(true);
                Destroy(GameObject.Find("Enemy"));
            }
        }
    }
}
