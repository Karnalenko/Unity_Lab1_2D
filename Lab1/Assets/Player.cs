using UnityEngine;
public class Player : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpHeight = 15f;
    CapsuleCollider2D capsuleCollider;
    Rigidbody2D rbody;
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }
    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movementVector = new Vector2(horizontalInput * movementSpeed * 100 * Time.deltaTime, rbody.velocity.y);
        Debug.Log(Time.deltaTime);
        rbody.velocity = movementVector;
    }
    void Update()
    {
        if (!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (Input.GetButtonDown("Jump"))
        {
            rbody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }
}