using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class HeroMove : ScriptableObject
{
    public enum Type
    {
        OnSelf,
        OnTarget,
    }

    public Type MoveType;
    public string MoveName;
    public float damage;
    public float healing;
    public float strength;
    public float fortitude;
    public float quantity = 1;

}
