using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private TextMeshProUGUI hp;
    [SerializeField] private TextMeshProUGUI heroTitle;
    
    [SerializeField] private TextMeshProUGUI strengthText;
    [SerializeField] private TextMeshProUGUI fortitudeText;
    [SerializeField] private TextMeshProUGUI curseText;
    public Hero heroRef;



    private void Awake()
    {
        slider = GetComponent<Slider>();
        heroTitle.text = heroRef.HeroType.Name;
    }


    private void Update()
    {
        slider.value = heroRef.Health.value;
        slider.maxValue = heroRef.MaxHealth.value;
        hp.text = slider.value.ToString() + "/" + slider.maxValue;

        strengthText.text = "Strength " + heroRef.Strength.value;
        fortitudeText.text = "Fortitude " + heroRef.Fortitude.value;
        curseText.text = "Curses " + heroRef.Curse.value;
    }
}
