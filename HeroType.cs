using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class HeroType : ScriptableObject
{
    public string Name;
    public Sprite sprite;
    public Color color;

    public List<HeroMove> moveset;
}
