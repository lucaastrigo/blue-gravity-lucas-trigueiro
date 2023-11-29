using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ClothObject testCloth;

    public float speed;
    public AnimationManager[] animationManagers;
    
    private bool canMove, moving;
    private float xMove, yMove;
    private Vector2 moveDir;
    //private Animator anim;
    private Rigidbody2D rb;
    private Wearables wearables;

    void Start()
    {
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        wearables = GetComponent<Wearables>();

        canMove = true;
        moving = false;
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            xMove = Input.GetAxisRaw("Horizontal");
            yMove = Input.GetAxisRaw("Vertical");

            //anim.SetFloat("xMove", xMove);
            //anim.SetFloat("yMove", yMove);

            moveDir = new Vector2(xMove, yMove).normalized;

            if(rb != null) rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);

            if (xMove != 0 || yMove != 0)
            {
                moving = true;
                //anim.SetBool("walk", true);
            }
            else
            {
                moving = false;
                //anim.SetBool("walk", false);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(testCloth != null)
            {
                switch (testCloth.itemType)
                {
                    case ClothObject.type.cloth:
                        wearables.cloth.SetActive(true);

                        AnimationManager clothManager = wearables.cloth.GetComponent<AnimationManager>();

                        if (clothManager != null)
                        {
                            clothManager.animations[0].sprites = null;
                            clothManager.animations[1].sprites = null;
                            clothManager.animations[2].sprites = null;
                            clothManager.animations[3].sprites = null;
                            clothManager.animations[4].sprites = null;

                            clothManager.animations[0].sprites = testCloth.idle;
                            clothManager.animations[1].sprites = testCloth.walkDown;
                            clothManager.animations[2].sprites = testCloth.walkLeft;
                            clothManager.animations[3].sprites = testCloth.walkRight;
                            clothManager.animations[4].sprites = testCloth.walkUp;
                        }

                        break;

                    case ClothObject.type.hair:
                        wearables.hair.SetActive(true);
                        wearables.hat.SetActive(false);

                        AnimationManager hairManager = wearables.hair.GetComponent<AnimationManager>();

                        if (hairManager != null)
                        {
                            hairManager.animations[0].sprites = null;
                            hairManager.animations[1].sprites = null;
                            hairManager.animations[2].sprites = null;
                            hairManager.animations[3].sprites = null;
                            hairManager.animations[4].sprites = null;

                            hairManager.animations[0].sprites = testCloth.idle;
                            hairManager.animations[1].sprites = testCloth.walkDown;
                            hairManager.animations[2].sprites = testCloth.walkLeft;
                            hairManager.animations[3].sprites = testCloth.walkRight;
                            hairManager.animations[4].sprites = testCloth.walkUp;
                        }

                        break;

                    case ClothObject.type.hat:
                        wearables.hat.SetActive(true);
                        wearables.hair.SetActive(false);

                        AnimationManager hatManager = wearables.hat.GetComponent<AnimationManager>();

                        if (hatManager != null)
                        {
                            hatManager.animations[0].sprites = null;
                            hatManager.animations[1].sprites = null;
                            hatManager.animations[2].sprites = null;
                            hatManager.animations[3].sprites = null;
                            hatManager.animations[4].sprites = null;

                            hatManager.animations[0].sprites = testCloth.idle;
                            hatManager.animations[1].sprites = testCloth.walkDown;
                            hatManager.animations[2].sprites = testCloth.walkLeft;
                            hatManager.animations[3].sprites = testCloth.walkRight;
                            hatManager.animations[4].sprites = testCloth.walkUp;
                        }
                        break;
                }
            }
        }
    }
}
