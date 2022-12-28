using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public int playerId;
    public int playerLevel;
    public int playerEnergy;
    public int playerCoins;
    public int playerPowers;
    public int playerStars;
    public int playerXP;
    public UIElements uIElements;

    public Player()
    {
        this.playerId = 1;
        this.playerCoins = 200;
        this.playerEnergy = 10;
        this.playerPowers = 20;
        this.playerStars = 15;
    }

}
public class UIElements
{
    public string playerName;
    public Image playerImage;
}
