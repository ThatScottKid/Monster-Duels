using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [HideInInspector] public HeroType HeroType = null;
    public FloatVariable Health, MaxHealth, Strength, Fortitude, Curse;
    public bool isPlayerL;
    [HideInInspector] public Color col;
    [HideInInspector] public List<HeroMove> moves;

    public HeroType[] Heroes;
    


    private void Awake()
    {
        if (isPlayerL == true)
        {
            int selectedHero = PlayerPrefs.GetInt("PlayerL");
            HeroType = Heroes[selectedHero];
        }
        else
        {
            int selectedHero = PlayerPrefs.GetInt("PlayerR");
            HeroType = Heroes[selectedHero];
        }

        moves = HeroType.moveset;
        col = HeroType.color;
        gameObject.GetComponent<SpriteRenderer>().sprite = HeroType.sprite;

        Health.value = MaxHealth.value;
        Strength.value = 0;
        Fortitude.value = 0;
        Curse.value = 0f;
    }


    public void DamageHealth(float amount)
    {
        Health.value -= amount;

        CheckHealth();
    }


    public void HealHealth(float amount)
    {
        Health.value += amount;

        CheckHealth();
    }


    public void ManageStrength(float amount)
    {
        Strength.value += amount;
    }


    public void ManageFortitude(float amount)
    {
        Fortitude.value += amount;
    }


    public void ManageCurse(float amount)
    {
        Curse.value += amount;
    }


    public void CheckHealth()
    {
        if (Health.value <= 0f)
        {
            Health.value = 0f;
        }

        if (Health.value >= MaxHealth.value)
        {
            Health.value = MaxHealth.value;
        }
    }
}
