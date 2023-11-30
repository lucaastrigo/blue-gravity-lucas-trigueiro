using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    public GameObject interactionIndicator;
    public GameObject shopMenu;

    private bool inTrigger;
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.E) && !shopMenu.activeInHierarchy)
        {
            player.canMove = false;
            shopMenu.SetActive(true);
            interactionIndicator.SetActive(false);
            player.moveDir = Vector2.zero;
            player.rb.velocity = Vector2.zero;
            player.xMove = 0;
            player.yMove = 0;
        }
    }

    public void QuitShop()
    {
        shopMenu.SetActive(false);
        player.canMove = true;
        interactionIndicator.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inTrigger = true;
            interactionIndicator.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inTrigger = false;
            interactionIndicator.SetActive(false);
        }
    }
}
