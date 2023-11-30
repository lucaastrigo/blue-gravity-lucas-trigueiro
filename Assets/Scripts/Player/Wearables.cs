using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wearables : MonoBehaviour
{
    public GameObject cloth;
    public GameObject hair;
    public GameObject hat;

    public Color hairColor;

    [HideInInspector] public SpriteRenderer clothSprite; 
    [HideInInspector] public SpriteRenderer hairSprite; 
    [HideInInspector] public SpriteRenderer hatSprite;

    private void Start()
    {
        clothSprite = cloth.GetComponent<SpriteRenderer>();
        hairSprite = hair.GetComponent<SpriteRenderer>();
        hatSprite = hat.GetComponent<SpriteRenderer>();
    }
}
