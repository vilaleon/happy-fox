using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float jumpMultiplier;

    private bool holdingJumpAxis;
    private bool isAirborne;
    private bool didAirJump;

    void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Crouch(verticalInput < 0 && !isAirborne);

        float horizontalInput = Input.GetAxis("Horizontal");
        if (!playerAnimator.GetBool("isCrouching"))
        {
            Walk(horizontalInput);
        }

        float jumpInput = Input.GetAxis("Jump");
        if (jumpInput == 0) holdingJumpAxis = false;

        if (jumpInput > 0 && !didAirJump && !holdingJumpAxis)
        {
            holdingJumpAxis = true;

            if (isAirborne)
            {
                AirJump();
            }
            else if (!isAirborne)
            {
                Jump();
            }
        }

        if (Math.Abs(playerRigidbody.velocity.normalized.y) > 0.1)
        {
            isAirborne = true;
            playerAnimator.SetBool("isAirborne", true);
            playerAnimator.SetBool("isGoingUp", playerRigidbody.velocity.normalized.y > 0 ? true : false);
        }
        else
        {
            playerAnimator.SetBool("isAirborne", false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !holdingJumpAxis)
        {
            isAirborne = false;
            didAirJump = false;
        }
    }

    #region Movement Methods
    public void Walk(float horizontalInput)
    {
        if (horizontalInput != 0) playerSpriteRenderer.flipX = horizontalInput > 0 ? false : true;
        playerRigidbody.AddForce(Vector2.right * horizontalInput * speedMultiplier, ForceMode2D.Impulse);
        playerAnimator.SetFloat("horizontalInput", horizontalInput);
    }

    public void Crouch(bool isCrouching)
    {
        playerAnimator.SetBool("isCrouching", isCrouching);
    }

    public void Jump()
    {
        playerRigidbody.AddForce(Vector2.up * jumpMultiplier, ForceMode2D.Impulse);
        isAirborne = true;
    }

    public void AirJump()
    {
        playerRigidbody.velocity = playerRigidbody.velocity * Vector2.right;
        playerRigidbody.AddForce(Vector2.up * jumpMultiplier / 1.5f, ForceMode2D.Impulse);
        didAirJump = true;
    }
    #endregion

    public void Scared()
    {
        playerAnimator.SetTrigger("scaredTrigger");
    }

    public void Death()
    {
        playerRigidbody.bodyType = RigidbodyType2D.Static;
        playerAnimator.SetTrigger("deathTrigger");
        gameManager.GameOver();
    }

    public void Cleanup()
    {
        gameObject.SetActive(false);
    }

}
