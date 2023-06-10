using UnityEngine;

static public class Generic
{
    static public void LimitYVelocity(float limit, Rigidbody2D rb)
    {
        int gravityMultiplier = (int)(Mathf.Abs(rb.gravityScale) / rb.gravityScale);
        if (rb.velocity.y * -gravityMultiplier > limit)
        {
            rb.velocity = Vector2.up * -limit * gravityMultiplier;
        }
    }

    static public void CreateGameMode(Rigidbody2D rb, PlayerController playerController, bool onGroundRequired, float initialVelocity, float gravityScale, bool canHold = false, bool flipOnClick = false, float rotationMod = 0, float yVelocityLimit = Mathf.Infinity)
    {
        if (!Input.GetMouseButton(0) || canHold && playerController.OnGround())
        {
            playerController.clickProcess = false;
        }

        rb.gravityScale = gravityScale * playerController.Gravity;
        LimitYVelocity(yVelocityLimit, rb);

        if (Input.GetMouseButton(0))
        {
            if (playerController.OnGround() && !playerController.clickProcess || !onGroundRequired && !playerController.clickProcess)
            {
                playerController.clickProcess = true;
                rb.velocity = Vector2.up * initialVelocity * playerController.Gravity;
                playerController.Gravity *= flipOnClick ? -1 : 1;
            }
        }
        if (playerController.OnGround() || !onGroundRequired)
        {
            playerController.SpriteRotate.rotation = Quaternion.Euler(0f, 0f, Mathf.Round(playerController.SpriteRotate.rotation.z / 90) * 90);
            playerController.spriteRenderer.flipY = flipOnClick ? playerController.Gravity < 0 : false;
        }
        else
        {
            playerController.SpriteRotate.Rotate(Vector3.back, rotationMod * Time.deltaTime * playerController.Gravity);
        }
    }
}
