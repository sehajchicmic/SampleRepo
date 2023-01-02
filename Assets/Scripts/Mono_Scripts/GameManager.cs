using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
     
    public static GameManager instance;

    [Header("References of Scripts")]
    public BingoNumberDisplay bingoNumberDisplay;
    public UIManager uIManager;
    public Pattern_SO pattern_SO;
    public Player player;
    public SaveLoader saveLoader;
    public scrollViewSystem cardnumber;

    [Header("Lists of cards")]
    public List<CardController> cards;
    public List<int> presentInAll=new List<int>();

    [Header("PowerPlay Components")]
    public Image fillArea;
    public Image powerPlay;
    public TextMeshProUGUI powerPlayText;
    public List<powerups> PowerImagesCommon = new List<powerups>();
    public List<powerups> PowerImagesRare = new List<powerups>() ;
    public List<powerups> PowerImagesEpic = new List<powerups>();
    List<powerupsStorage> powerupStorages = new List<powerupsStorage>();

    //private checks
    string currentPower;
    bool doubleRewards = false;
    bool doubleDaub = false;
    bool doublePayout = false;

    [Header("Per Match Progress")]
    public int localCoins = 0;
    public int localXp = 0;

    [System.Serializable]
    public struct powerups
    {
        public string powerUpName;
        public Sprite powerUpImage;
    }
    struct powerupsStorage
    {
        public GameObject gameObject;
        public string Powerup;


        public powerupsStorage(GameObject randomSelectedTile, string currentPower) : this()
        {
            this.gameObject = randomSelectedTile;
            this.Powerup = currentPower;
        }
    }

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
        GameObject tempGameObject = gameObject;
        Debug.Log($"are equal {gameObject == tempGameObject} and refrence equal {GameObject.ReferenceEquals(gameObject, tempGameObject)} and " +
            $"instance ids are {gameObject.GetInstanceID()} and {tempGameObject.GetInstanceID()}" +
            $"refrence ids are {gameObject.GetHashCode()} and {tempGameObject.GetHashCode()}");


        //Loading Previous Player Prefs
        player = saveLoader.LoadPlayerData();
        if(player.playerXP > 100)
        {
            player.playerXP -= 100;
            player.playerLevel += 1;
        }
        uIManager.SetCoins(player.playerCoins);
        uIManager.SetPowers(player.playerPowers);
        uIManager.SetEnergy(player.playerEnergy);
        uIManager.SetStars(player.playerStars);
        uIManager.SetLevel(player.playerLevel);
        uIManager.SetXP(player.playerXP);

        Powerplay();//Generating PowerPlayIcon
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Calling to Roll
    public  void Roll(TextMeshProUGUI rollsLeft)
    {
        bingoNumberDisplay.Display(rollsLeft);  
    }

    //Checking wheather value is present or not in Random Rolled Numbers
    public bool MatchChecker(int cardvalue)  
    {
        bool isMatched =bingoNumberDisplay.MatchChecker(cardvalue);
        return isMatched;
    }

    //Checking wheather a pattern is matched or not
    public bool[] PatternCheck(bool[] boolValuesofcard, bool[] previousMatchedPatterns)
    {
        
        bool[] finalResult = new bool[pattern_SO.BingoPatterns.Length];
        for (int i = 0 ; i < pattern_SO.BingoPatterns.Length ; i++)
        {
            if(!previousMatchedPatterns[i])
            {
                bool result = true;
                for (int j = 0; j < pattern_SO.BingoPatterns[i].cells.Length; j++)
                {
                    if (pattern_SO.BingoPatterns[i].cells[j] == true)
                    {
                        if (boolValuesofcard[j] == false)
                        {
                            result = false;
                        }
                    }
                }
                if(result)
                {
                    localCoins += Constants.coinsRewardOnPatternMatch;
                }
                finalResult[i] = result;
            }
        }
        //Debug.Log ( $"inside pattern match returning value {finalResult.Length} " );
        return finalResult;
    }

    //Creating a List of numbers present in all Cards
    public void commonInAll () {
        foreach ( int number in cards [ 0 ].keyValues.Keys ) {
            int valuesMatched = 0;
            foreach ( CardController card in cards ) {
                if ( card.keyValues.ContainsKey ( number ) ) {
                    valuesMatched++;
                    if (valuesMatched == cards.Count ) {
                        presentInAll.Add ( number );
                    }
                }
            }
        }
        foreach ( int number in presentInAll ) {
            Debug.Log ( $"{ number } present in all" );
        }
    }

    //Removing the number  from present in all list which are present in all cards
    public void AutoDaubing(int number)
    {
        foreach(int num in presentInAll) {
            if(num== number ) {
                DaubNumbers ( number );
            }
        }
        presentInAll.Remove(number);
    }

    //Daubing the numbers which are present in all cards
    public void DaubNumbers(int temp)
    {
        foreach (CardController i in cards)
        {
            i.keyValues[temp].GetComponent<Button>().onClick.Invoke();
        }
    }

    //Saving the player data and reloading the  Menu Scene
    public void GameOver()
    {
        if(doubleRewards)
        {
            localCoins += localCoins;
        }
        player.playerCoins += localCoins;
        player.playerXP += localXp;
        player.playerEnergy += 2;
        saveLoader.SavePlayerData(player);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Generating and managing the probability of PowerPlays
    void Powerplay()
    {
        powerPlayText.text = $"{player.playerPowers}";
        powerups selectedPowerUp;
        int probabilityNumber = Random.Range(Constants.PowerPlay.minprobabilityNumber,  Constants.PowerPlay.maxprobabilityNumber);
        if (probabilityNumber ==  Constants.PowerPlay.probabilityofepic && doubleDaub == false) //if epic is called and it is not generated previously in current game
        {
            selectedPowerUp = PowerImagesEpic[Random.Range(0, PowerImagesEpic.Count)];
            doubleDaub = true;
        }
        else if (probabilityNumber > Constants.PowerPlay.probabilityofrare) //if rare is called
        {
            if (doublePayout == false) // if double payout is not activated previously
            {
                selectedPowerUp = PowerImagesRare[Random.Range(0, PowerImagesRare.Count)];
                doublePayout = true;
            }
            else
            {
                selectedPowerUp = PowerImagesRare[Random.Range(1, PowerImagesRare.Count)]; 
            }
        }
        else
        {
            selectedPowerUp = PowerImagesCommon[Random.Range(0, PowerImagesCommon.Count)]; // common powerplay activated
        }
        powerPlay.sprite = selectedPowerUp.powerUpImage;
        currentPower = selectedPowerUp.powerUpName;
    }

    // Incresing the value of slider on daubing
    public void PowerPlaySlider()
    {
        if(fillArea.fillAmount!=1)
            fillArea.fillAmount += Constants.PowerPlay.slidingValue;
        
    }

    //Workings of the PowerPlays
    public void GeneratePowerPlay()
    {
        if (fillArea.fillAmount == 1 && player.playerPowers !=0)
        {
            fillArea.fillAmount = 0;
            player.playerPowers -= 1;
            Debug.Log("PowerPlayCalled");
            foreach (CardController card in cards)
            {
                GameObject randomSelectedTile = card.enabledkeyValues.ElementAt(Random.Range(0, card.enabledkeyValues.Count)).Value;
                if (currentPower == "SingleDaub") // if PowerPlay is SingleDaub
                {
                    card.Powerup = true;
                    randomSelectedTile.GetComponent<Button>().onClick.Invoke();
                    Debug.Log("Rare");
                }
                else if (currentPower == "DoubleDaub") // if PowerPlayIs DoubleDaubed
                {
                    //card.Powerup = true;
                    //temp.GetComponent<Button>().onClick.Invoke();
                    foreach (CardController card1 in cards)
                    {
                        GameObject randomSelectedTiles = card1.enabledkeyValues.ElementAt(Random.Range(0, card1.enabledkeyValues.Count)).Value;
                        card1.Powerup = true;
                        randomSelectedTiles.GetComponent<Button>().onClick.Invoke();
                    }
                    Debug.Log("Epic");
                }
                else // if any otherthen above mentioned  poweplay is activated
                {
                    //randomSelectedTile.GetComponent<Image>().color = currentPower;
                    Debug.Log($"adding into list {randomSelectedTile is null}");
                    powerupStorages.Add(new powerupsStorage(randomSelectedTile, currentPower));
                    randomSelectedTile.GetComponent<Image>().sprite = powerPlay.sprite;
                }
            }
            Powerplay();
        }
        
    }

    //Giving the rewards to the player if they daub the powered tile
    public void PowerPlayReward(GameObject tobeChecked)
    {

        //Debug.Log($"Hello {tobeChecked.GetInstanceID()}");
        foreach(powerupsStorage check in powerupStorages)
        {
            //Debug.Log($" inside for loop{check.gameObject is null}");
            if (GameObject.ReferenceEquals(check.gameObject,tobeChecked))
            {
                Debug.Log($"for loop instance ids {check.gameObject.GetInstanceID()} ");
                //Debug.Log("temp Matched");
                if (check.Powerup == "DoubleXp") //DoubleXp
                {
                    localXp += Constants.XpRewardOnDaub;
                    Debug.Log("Rewarded : Double Xp");
                }
                else if (check.Powerup == "MoneyCell") // MoneyCell
                {
                    localCoins += Constants.coinsRewardOnMoneyCell;
                    Debug.Log("Rewarded : MoneyCell");
                }
                else if (check.Powerup == "DoublePayout") //DoublePayout
                {
                    doubleRewards = true;
                    Debug.Log("Rewarded : Double Payout");
                }
                else if (check.Powerup == "FreeEnergy") //Free-Energy
                {
                    player.playerEnergy += Constants.energyRewardOnFreeEnergy;
                    Debug.Log("Rewarded : FreeEnergy");
                }
            }
        }
    }
}
