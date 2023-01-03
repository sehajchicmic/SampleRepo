using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BingoNumberDisplay : MonoBehaviour
{
    [SerializeField] public List<bingo> bingoDisplay = new List<bingo>();

    [System.Serializable]
    public struct bingo
    {
        public TextMeshProUGUI bingoAlphabet;
        public TextMeshProUGUI bingoNumber;
    }

    List<int> numbers;
    int totalRolls;
    int[] ExistingNumbers = new int[] { 0, 0, 0, 0, 0 };
    bool notcalled = true;

    void Start()
    {

        numbers = new List<int>();
        for (int i = 1; i <= 75; i++)
        {
            numbers.Add(i);
        }
        totalRolls = GameManager.instance.totalRolls;
    }

    public void Display(TextMeshProUGUI rollsLeft)
    {
        if(notcalled) {
            GameManager.instance.commonInAll ();
            notcalled = false;
        }
        if (totalRolls == 0)
        {
            Debug.Log("No Rolls Left");
            GameManager.instance.GameOver();
            return;
        }

        totalRolls--;
        rollsLeft.text = $"{totalRolls} left";
        for (int i = 0; i < bingoDisplay.Count; i++)
        {
            int rand = Random.Range(0, 20);
            int temp;
            if(rand < 5 && GameManager.instance.presentInAll.Count != 0)
            {
                temp = GameManager.instance.presentInAll[Random.Range(0, GameManager.instance.presentInAll.Count)];
            }
            else
            {
                temp = numbers[Random.Range(0, numbers.Count)];
            }
            
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
            ExistingNumbers[i] = temp;
            GameManager.instance.AutoDaubing(temp);
        }

    }

    public bool MatchChecker(int temp)
    {
        foreach (int i in ExistingNumbers)
        {
            if (i == temp)
            {
                Debug.Log("Match Found");
                return true;
            }
        }
        Debug.Log("No Match Found");
        return false;
    }
}
