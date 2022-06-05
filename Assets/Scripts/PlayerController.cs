using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float jumpMultiplier;

    private bool isJumping;
    private bool isDoubleJumping;
    private float doubleJumpingDelay = 0.3f;
    private float doubleJumpingDelayTimer = 0.0f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0) playerSpriteRenderer.flipX = horizontalInput > 0 ? false : true;
        if (!playerAnimator.GetBool("isCrouching")) playerRigidbody.AddForce(Vector2.right * horizontalInput * speedMultiplier, ForceMode2D.Impulse);
        playerAnimator.SetFloat("horizontalInput", horizontalInput);

        float jumpInput = Input.GetAxis("Jump");
        if (jumpInput > 0 && !isDoubleJumping)
        {
            if (isJumping && Time.time > doubleJumpingDelayTimer)
            {
                isDoubleJumping = true;
                playerRigidbody.AddForce(Vector2.up * jumpInput * jumpMultiplier, ForceMode2D.Impulse);
            }
            else if (!isJumping)
            {
                isJumping = true;
                doubleJumpingDelayTimer = Time.time + doubleJumpingDelay;
                playerRigidbody.AddForce(Vector2.up * jumpInput * jumpMultiplier, ForceMode2D.Impulse);
            }
        }

        if (Math.Abs(playerRigidbody.velocity.normalized.y) > 0.1)
        {
            isJumping = true;
            playerAnimator.SetBool("isAirborne", true);
            playerAnimator.SetBool("isGoingUp", playerRigidbody.velocity.normalized.y > 0 ? true : false);
        }
        else
        {
            playerAnimator.SetBool("isAirborne", false);
        }

        float verticalInput = Input.GetAxis("Vertical");
        playerAnimator.SetBool("isCrouching", verticalInput < 0 && !isJumping);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isDoubleJumping = false;
        }
    }
}
