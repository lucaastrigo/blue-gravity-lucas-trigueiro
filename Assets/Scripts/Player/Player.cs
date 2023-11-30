using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int money;
    public float speed;
    public TextMeshProUGUI moneyText;
    public AnimationManager[] animationManagers;

    [HideInInspector] public bool canMove;
    [HideInInspector] public float xMove, yMove;
    [HideInInspector] public Vector2 moveDir;
    //private Animator anim;
    [HideInInspector] public Rigidbody2D rb;
    private Wearables wearables;

    void Start()
    {
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        wearables = GetComponent<Wearables>();

        canMove = true;

        moneyText.text = "$" + money.ToString();
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

            if (rb != null) rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
        }
    }

    void Update()
    {
        moneyText.text = "$" + money.ToString();

        for (int i = 0; i < animationManagers.Length; i++)
        {
            if (yMove > 0)
            {
                animationManagers[i].currentAnimationID = 4;
            }
            else if (yMove < 0)
            {
                animationManagers[i].currentAnimationID = 1;
            }

            if (xMove > 0 && yMove == 0)
            {
                animationManagers[i].currentAnimationID = 3;
            }
            else if (xMove < 0 && yMove == 0)
            {
                animationManagers[i].currentAnimationID = 2;
            }

            if (xMove == 0 && yMove == 0)
            {
                animationManagers[i].currentAnimationID = 0;
            }
        }
    }

    public void ChangeHairColor()
    {
        if(wearables.hairSprite.color == wearables.hairColor)
        {
            wearables.hairSprite.color = Color.white;
        }
        else
        {
            wearables.hairSprite.color = wearables.hairColor;
        }
    }

    public void EquipUnequipCloth(ClothObject clothObj)
    {
        if (clothObj.equipped)
        {
            UnequipCloth(clothObj);
        }
        else
        {
            EquipCloth(clothObj);
        }
    }

    public void UnequipCloth(ClothObject toUnequip)
    {
        if (toUnequip != null)
        {
            money += toUnequip.value;
            moneyText.text = "$" + money.ToString();

            toUnequip.equipped = false;

            for (int i = 0; i < animationManagers.Length; i++)
            {
                animationManagers[i].currentIndex = 0;
            }

            switch (toUnequip.itemType)
            {
                case ClothObject.type.cloth:
                    wearables.cloth.SetActive(false);

                    AnimationManager clothManager = wearables.cloth.GetComponent<AnimationManager>();

                    if (clothManager != null)
                    {
                        clothManager.animations[0].sprites = null;
                        clothManager.animations[1].sprites = null;
                        clothManager.animations[2].sprites = null;
                        clothManager.animations[3].sprites = null;
                        clothManager.animations[4].sprites = null;
                    }

                    break;

                case ClothObject.type.hair:
                    wearables.hair.SetActive(false);

                    AnimationManager hairManager = wearables.hair.GetComponent<AnimationManager>();

                    if (hairManager != null)
                    {
                        hairManager.animations[0].sprites = null;
                        hairManager.animations[1].sprites = null;
                        hairManager.animations[2].sprites = null;
                        hairManager.animations[3].sprites = null;
                        hairManager.animations[4].sprites = null;
                    }

                    break;

                case ClothObject.type.hat:
                    wearables.hat.SetActive(false);

                    AnimationManager hatManager = wearables.hat.GetComponent<AnimationManager>();

                    if (hatManager != null)
                    {
                        hatManager.animations[0].sprites = null;
                        hatManager.animations[1].sprites = null;
                        hatManager.animations[2].sprites = null;
                        hatManager.animations[3].sprites = null;
                        hatManager.animations[4].sprites = null;
                    }
                    break;
            }
        }
    }

    public void EquipCloth(ClothObject toEquip)
    {
        if (toEquip != null)
        {
            if(toEquip.value <= money)
            {
                money -= toEquip.value;
                moneyText.text = "$" + money.ToString();

                toEquip.equipped = true;

                for (int i = 0; i < animationManagers.Length; i++)
                {
                    animationManagers[i].currentIndex = 0;
                }

                switch (toEquip.itemType)
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

                            clothManager.animations[0].sprites = toEquip.idle;
                            clothManager.animations[1].sprites = toEquip.walkDown;
                            clothManager.animations[2].sprites = toEquip.walkLeft;
                            clothManager.animations[3].sprites = toEquip.walkRight;
                            clothManager.animations[4].sprites = toEquip.walkUp;
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

                            hairManager.animations[0].sprites = toEquip.idle;
                            hairManager.animations[1].sprites = toEquip.walkDown;
                            hairManager.animations[2].sprites = toEquip.walkLeft;
                            hairManager.animations[3].sprites = toEquip.walkRight;
                            hairManager.animations[4].sprites = toEquip.walkUp;
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

                            hatManager.animations[0].sprites = toEquip.idle;
                            hatManager.animations[1].sprites = toEquip.walkDown;
                            hatManager.animations[2].sprites = toEquip.walkLeft;
                            hatManager.animations[3].sprites = toEquip.walkRight;
                            hatManager.animations[4].sprites = toEquip.walkUp;
                        }
                        break;
                }
            }
        }
    }
}
