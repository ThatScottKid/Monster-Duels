using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public HeroType HeroType;
    public FloatVariable Health, MaxHealth, Strength, Fortitude, Curse;
    [HideInInspector] public Color col;
    [HideInInspector] public List<HeroMove> moves;



    private void Awake()
    {
        moves = HeroType.moveset;
        col = HeroType.color;
        gameObject.GetComponent<SpriteRenderer>().sprite = HeroType.sprite;

        Health.value = MaxHealth.value;
        Strength.value = 0;
        Fortitude.value = 0;
        Curse.value = 0f;
    }


    public void ManageHealth(float amount)
    {
        Health.value -= amount;

        if (Health.value >= MaxHealth.value)
        {
            Health.value = MaxHealth.value;
        }
    }


    public void ManageStat(FloatVariable stat, float amount)
    {
        stat.value -= amount;
    }


}
