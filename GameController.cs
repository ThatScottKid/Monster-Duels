using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameController : MonoBehaviour
{
    [SerializeField] private Hero heroL = null;
    [SerializeField] private Hero heroR = null;
    private bool playerLTurn;
    public Button[] actions;
    


    private void Awake()
    {
        playerLTurn = true;
        SetupButtons();
    }


    private void SetupButtons()
    {
        for (int i = 0; i < actions.Length; i++)
        {
            if (playerLTurn == true)
            {
                actions[i].GetComponentInChildren<TextMeshProUGUI>().text = heroL.moves[i].MoveName;
                actions[i].GetComponent<Image>().color = heroL.col;
            }
            else if(playerLTurn == false)
            {
                actions[i].GetComponentInChildren<TextMeshProUGUI>().text = heroR.moves[i].MoveName;
                actions[i].GetComponent<Image>().color = heroR.col;
            }
        }
    }


    private void ChangeTurns()
    {
        playerLTurn = !playerLTurn;
        SetupButtons();
    }


    public void SelectMove(int selection)
    {
        if (playerLTurn == true)
        {
            //Player L
            PerformMove(heroL, heroR, heroL.moves[selection]);
            heroL.Health.value -= heroL.Curse.value;
        }
        else
        {
            //Player R
            PerformMove(heroR, heroL, heroR.moves[selection]);
            heroR.Health.value -= heroR.Curse.value;
        } 
    }


    private void PerformMove(Hero self, Hero target, HeroMove move)
    {
        switch (move.MoveType)
        {
            case HeroMove.Type.OnSelf:      // Perform "on self" move
                self.ManageHealth(((move.damage + self.Strength.value) * move.quantity) - self.Fortitude.value);
                self.ManageHealth((-move.healing - self.Fortitude.value) * move.quantity);

                break;
            case HeroMove.Type.OnTarget:        // Perform "on target move
                target.ManageHealth(((move.damage + self.Strength.value) * move.quantity) - target.Fortitude.value);
                target.ManageHealth((-move.healing - self.Fortitude.value) * move.quantity);
                
                break;
        }

        Debug.Log(
            self.name + " has attacked " + target.name + " for " + move.damage + " damage " + move.quantity + " times and healed for " + move.healing);

        ChangeTurns();
    }

}
