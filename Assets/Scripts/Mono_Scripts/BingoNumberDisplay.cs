using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BingoNumberDisplay : MonoBehaviour
{
    [SerializeField] List<bingo> bingoDisplay = new List<bingo>();
    // Start is called before the first frame update

    [System.Serializable]
    struct bingo
    {
        public TextMeshProUGUI bingoAlphabet;
        public TextMeshProUGUI bingoNumber;
    }

    //CardController cardController;
    List<int> numbers;
    int totalRolls = 5;

    void Start()
    {

        numbers = new List<int>();
        for (int i = 1; i <= 75; i++)// (int i = (int)cardController.range[0].x; i <= cardController.range[cardController.range.Length].y; i++)
        {
            numbers.Add(i);
        }
        //InvokeRepeating("Display",2f,10f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Display(TextMeshProUGUI rollsLeft)
    {
        if (totalRolls == 0)
        {
            Debug.Log("No Rolls Left");
            return;
        }

        totalRolls--;
        rollsLeft.text = $"{totalRolls} left";
        for (int i = 0; i < bingoDisplay.Count; i++)
        {
            int temp = numbers[Random.Range(0, numbers.Count)];
            numbers.Remove(temp);
            bingoDisplay[i].bingoNumber.text = temp.ToString();
            if (temp <= 15)
            {
                bingoDisplay[i].bingoAlphabet.text = "B";
            }
            else if (temp <= 30)
            {
                bingoDisplay[i].bingoAlphabet.text = "I";
            }
            else if (temp <= 45)
            {
                bingoDisplay[i].bingoAlphabet.text = "N";
            }
            else if (temp <= 60)
            {
                bingoDisplay[i].bingoAlphabet.text = "G";
            }
            else
            {
                bingoDisplay[i].bingoAlphabet.text = "O";
            }
        }

    }

    public bool MatchChecker(GameObject temp)
    {
        foreach (bingo i in bingoDisplay)
        {
            if (i.bingoNumber.text == temp.GetComponentInChildren<TextMeshProUGUI>().text)
            {
                return true;
            }
        }
        Debug.Log("No Match Found");
        return false;
    }
}
