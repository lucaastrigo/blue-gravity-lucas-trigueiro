using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object")]
public class ClothObject : ScriptableObject
{
    public enum type { cloth, hair, hat }
    public type itemType;
    public Sprite[] idle;
    public Sprite[] walkDown;
    public Sprite[] walkLeft;
    public Sprite[] walkRight;
    public Sprite[] walkUp;
    public int value;

    public bool equipped;
    public bool bought;
}
