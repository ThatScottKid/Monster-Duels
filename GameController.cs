using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameController : MonoBehaviour
{
    [SerializeField] private Hero heroL = null;
    [SerializeField] private Hero heroR = null;
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private TextMeshProUGUI turnText;
    [SerializeField] private TextMeshProUGUI victoryText;

    private bool playerLTurn;
    public Button[] actions;



    public string PlayerTurnText()
    {
        if (playerLTurn == true)
        {
            return heroL.HeroType.Name + "'s \nTurn";
        }
        else
        {
            return heroR.HeroType.Name + "'s \nTurn";
        }
    }
    

    private void Awake()
    {
        GameOverScreen.SetActive(false);
        playerLTurn = true;
        turnText.text = PlayerTurnText();
        SetupButtons();
    }


    private void SetupButtons()     //Creates unique buttons for hero
    {
        for (int i = 0; i < actions.Length; i++)
        {
            if (playerLTurn == true)
            {
                actions[i].GetComponentInChildren<TextMeshProUGUI>().text =
                    heroL.moves[i].MoveName + ": \n" + heroL.moves[i].description;
                actions[i].GetComponent<Image>().color = heroL.col;
            }
            else if(playerLTurn == false)
            {
                actions[i].GetComponentInChildren<TextMeshProUGUI>().text =
                    heroR.moves[i].MoveName + "\n" + heroR.moves[i].description;
                actions[i].GetComponent<Image>().color = heroR.col;
            }
        }
    }


    public void SelectMove(int selection)
    {
        if (playerLTurn == true)
        {
            if (heroR.Health.value <= 0f)
            {
                GameOver();
            }
            PerformMove(heroL, heroR, heroL.moves[selection]);      //Player L turn
            heroL.Health.value -= heroL.Curse.value;
        }
        else
        {
            if (heroL.Health.value <= 0f)
            {
                GameOver();
            }
            PerformMove(heroR, heroL, heroR.moves[selection]);      //Player R turn
            heroR.Health.value -= heroR.Curse.value;
        }
    }


    private void PerformMove(Hero attacker, Hero defender, HeroMove move)
    {
        switch (move.MoveType)
        {
            case HeroMove.Category.OnSelf:      // Perform "on self" move

                attacker.ManageStrength(move.strength);
                attacker.ManageFortitude(move.fortitude);
                attacker.ManageCurse(move.curse);

                if (move.healing > 0)
                {
                    attacker.HealHealth((move.healing + attacker.Fortitude.value) * move.moveQuantity);
                }
                if (move.damage > 0)
                {
                    attacker.DamageHealth((move.damage + attacker.Strength.value - attacker.Fortitude.value) * move.moveQuantity);
                    if (move.DrainHP == true)
                    {
                        defender.HealHealth(((move.damage + attacker.Strength.value + defender.Fortitude.value) - attacker.Fortitude.value) * move.moveQuantity);
                    }
                }
                break;

            case HeroMove.Category.OnTarget:        // Perform "on target move

                defender.ManageStrength(move.strength);
                defender.ManageFortitude(move.fortitude);
                defender.ManageCurse(move.curse);

                if (move.healing > 0)
                {
                    defender.HealHealth((move.healing + attacker.Fortitude.value) * move.moveQuantity);
                }
                if (move.damage > 0)
                {
                    defender.DamageHealth((move.damage + attacker.Strength.value - defender.Fortitude.value) * move.moveQuantity);
                    if (move.DrainHP == true)
                    {
                        attacker.HealHealth(((move.damage + attacker.Strength.value - defender.Fortitude.value) + attacker.Fortitude.value) * move.moveQuantity);
                    }
                }
                break;
        }
        ChangeTurns();
    }


    private void ChangeTurns()
    {
        playerLTurn = !playerLTurn;
        SetupButtons();
        turnText.text = PlayerTurnText();
    }


    private void GameOver()
    {
        if (heroL.Health.value > 0 && heroR.Health.value <= 0)
        {
            victoryText.text = heroL.HeroType.Name + " Wins!";
        }

        if (heroL.Health.value <= 0 && heroR.Health.value > 0)
        {
            victoryText.text = heroR.HeroType.Name + " Wins!";
        }

        if (heroL.Health.value == 0 && heroR.Health.value == 0)
        {
            victoryText.text = "DRAW";
        }

        GameOverScreen.SetActive(true);
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].interactable = false;
        }
    }


    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1, LoadSceneMode.Single);
    }
}
