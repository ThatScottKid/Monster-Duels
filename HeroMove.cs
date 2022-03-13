using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class HeroMove : ScriptableObject
{
    public enum Category
    {
        OnTarget,
        OnSelf,
    }

    public Category MoveType;
    public string MoveName;
    public float damage;
    public float healing;
    public float strength;
    public float fortitude;
    public float curse;
    public bool DrainHP;
   
    public float moveQuantity = 1;

    public string description;
}
