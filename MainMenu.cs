using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject CharacterSelectMenu;
    [SerializeField] private TextMeshProUGUI CharacterSelectText;
    [SerializeField] private GameObject Help;
    
    private bool isLSelection;

    [HideInInspector] public int playerLSelection = 0;
    [HideInInspector] public int playerRSelection = 0;



    private void Awake()
    {
        CharacterSelectMenu.SetActive(false);
        Help.SetActive(false);
    }


    public void PlayGame()
    {
        PlayerPrefs.SetInt("PlayerL", playerLSelection);
        PlayerPrefs.SetInt("PlayerR", playerRSelection);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }


    public void CharacterSelect()
    {
        CharacterSelectMenu.SetActive(true);
        isLSelection = true;
        CharacterSelectText.text = "Player 1 Select";
    }


    public void HeroSelect(int HeroIndex)
    {
        if (isLSelection == true)
        {
            playerLSelection = HeroIndex;
            isLSelection = false;
            CharacterSelectText.text = "Player 2 Select";
        }
        else
        {
            playerRSelection = HeroIndex;
            PlayGame();
        }
    }


    public void HelpMenu()
    {
        Help.SetActive(true);
    }


    public void QuitMenu()
    {
        
    }


    public void BackButton()
    {
        CharacterSelectMenu.SetActive(false);
        Help.SetActive(false);
    }
}
