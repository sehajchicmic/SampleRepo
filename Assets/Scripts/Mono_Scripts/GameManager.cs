using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public BingoNumberDisplay bingoNumberDisplay;
    public UIManager uIManager;
    public List<CardController> cards;
    public Pattern_SO pattern_SO;
    public Player player;
    public SaveLoader saveLoader;
    public List<int> presentInAll=new List<int>();
    public scrollViewSystem cardnumber;

    //public List<IDictionary> Elements;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

    }
    private void Start()
    {
        player = saveLoader.LoadPlayerData();
        uIManager.SetCoins(player.playerCoins);
        uIManager.SetPowers(player.playerPowers);
        uIManager.SetEnergy(player.playerEnergy);
        uIManager.SetStars(player.playerStars);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool MatchChecker(int temp)  
    {
        bool temp1 =bingoNumberDisplay.MatchChecker(temp);
        return temp1;
    }

    public  void Roll(TextMeshProUGUI rollsLeft)
    {
        bingoNumberDisplay.Display(rollsLeft);  
    }

    public bool[] PatternCheck(bool[] temp, bool[] previous)
    {
        
        bool[] finalResult = new bool[pattern_SO.BingoPatterns.Length];
        for (int i = 0 ; i < pattern_SO.BingoPatterns.Length ; i++)
        {
            if(!previous[i])
            {
                bool result = true;
                for (int j = 0; j < pattern_SO.BingoPatterns[i].cells.Length; j++)
                {
                    if (pattern_SO.BingoPatterns[i].cells[j] == true)
                    {
                        if (temp[j] == false)
                        {
                            result = false;
                        }
                    }
                }
                finalResult[i] = result;
            }
        }
        //Debug.Log ( $"inside pattern match returning value {finalResult.Length} " );
        return finalResult;
    }
    public void commonInAll () {
        foreach ( int number in cards [ 0 ].keyValues.Keys ) {
            int temp = 0;
            foreach ( CardController card in cards ) {
                if ( card.keyValues.ContainsKey ( number ) ) {
                    temp++;
                    if ( temp == cards.Count ) {
                        presentInAll.Add ( number );
                    }
                }
            }
        }
        foreach ( int number in presentInAll ) {
            Debug.Log ( $"{ number } present in all" );
        }
    }

    public void AutoDaubing(int number)
    {
        foreach(int num in presentInAll) {
            if(num== number ) {
                DaubNumbers ( number );
            }
        }
    }
    public void DaubNumbers(int temp)
    {
        foreach (CardController i in cards)
        {
            i.keyValues[temp].GetComponent<Button>().onClick.Invoke();
        }
    }
    public void GameOver()
    {
        saveLoader.SavePlayerData(player);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
