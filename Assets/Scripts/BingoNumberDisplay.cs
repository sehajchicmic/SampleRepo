using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BingoNumberDisplay : MonoBehaviour
{
    [SerializeField]List<abc> bingoDisplay = new List<abc>();
    // Start is called before the first frame update

    [System.Serializable]
    struct abc
    {
        public TextMeshProUGUI bingoAlphabet;
        public TextMeshProUGUI bingoNumber;
    }

    CardController cardController;
    List<int> numbers;

    void Start()
    {
        numbers = new List<int>();
        for(int i=1; i<=75; i++)// (int i = (int)cardController.range[0].x; i <= cardController.range[cardController.range.Length].y; i++)
        {
            numbers.Add(i);
        }
        //InvokeRepeating("Display",2f,10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Display()
    {
        for( int i =0; i< bingoDisplay.Count;i++)
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

}
