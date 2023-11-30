using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public float fps;

    [System.Serializable]
    public class AnimationType
    {
        public string animType;
        public Sprite[] sprites;
    }

    public List<AnimationType> animations = new List<AnimationType>();

    [HideInInspector] public int currentAnimationID;
    /*[HideInInspector]*/ public int currentIndex;
    private float timer;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (animations[currentAnimationID].sprites.Length <= 0) return;

        if (timer >= 1 / fps)
        {
            if (currentIndex >= animations[currentAnimationID].sprites.Length - 1)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }

            sr.sprite = animations[currentAnimationID].sprites[currentIndex];
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
