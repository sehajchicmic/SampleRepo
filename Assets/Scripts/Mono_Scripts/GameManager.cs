using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public BingoNumberDisplay bingoNumberDisplay;
    public List<CardController> cards;
    //public List<IDictionary> Elements;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool MatchChecker(GameObject temp)
    {
        bool temp1 =bingoNumberDisplay.MatchChecker(temp);
        return temp1;
    }
    public  void Roll(TextMeshProUGUI rollsLeft)
    {
        bingoNumberDisplay.Display(rollsLeft);
        Debug.Log($"{cards.Count} Cards Generated");
    }
}
