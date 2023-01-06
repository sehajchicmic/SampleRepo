using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopController : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
    }
    #region SHOP CURRENCY
    public void onClickEnergyPanel1 () {
        gameManager.player.playerEnergy+=1;
        gameManager.saveLoader.SavePlayerData ( gameManager.player );
        gameManager.uIManager.SetEnergy ( gameManager.player.playerEnergy );
        Debug.Log ( "1 Energy added ⚡" );
    }
    public void onClickEnergyPanel2 () {
        gameManager.player.playerEnergy += 5;
        gameManager.saveLoader.SavePlayerData ( gameManager.player );
        gameManager.uIManager.SetEnergy ( gameManager.player.playerEnergy );
        Debug.Log ( "5 Energy added ⚡" );
    }
    public void onClickEnergyPanel3 () {
        gameManager.player.playerEnergy += 20;
        gameManager.saveLoader.SavePlayerData ( gameManager.player );
        gameManager.uIManager.SetEnergy ( gameManager.player.playerEnergy );
        Debug.Log ( "20 Energy added ⚡" );
    }
    public void onClickPowerplayPanel1 () {
        gameManager.player.playerPowers += 5;
        gameManager.saveLoader.SavePlayerData ( gameManager.player );
        gameManager.uIManager.SetPowers ( gameManager.player.playerPowers );
        Debug.Log ( "5 Powerplay added" );
    }
    public void onClickPowerplayPanel2 () {
        gameManager.player.playerPowers += 10;
        gameManager.saveLoader.SavePlayerData ( gameManager.player );
        gameManager.uIManager.SetPowers ( gameManager.player.playerPowers );
        Debug.Log ( "10 Powerplay added" );
    }
    public void onClickPowerplayPanel3 () {
        gameManager.player.playerPowers += 50;
        gameManager.saveLoader.SavePlayerData ( gameManager.player );
        gameManager.uIManager.SetPowers ( gameManager.player.playerPowers );
        Debug.Log ( "50 Powerplay added" );
    }
    public void onClickCoinPanel1 () {
        gameManager.player.playerCoins += 500;
        gameManager.saveLoader.SavePlayerData ( gameManager.player );
        gameManager.uIManager.SetCoins ( gameManager.player.playerCoins );
        Debug.Log ( "500 Coin added" );
    }
    public void onClickCoinPanel2 () {
        gameManager.player.playerCoins += 2000;
        gameManager.saveLoader.SavePlayerData ( gameManager.player );
        gameManager.uIManager.SetCoins ( gameManager.player.playerCoins );
        Debug.Log ( "2000 Coin added" );
    }
    public void onClickCoinPanel3 () {
        gameManager.player.playerCoins += 5000;
        gameManager.saveLoader.SavePlayerData ( gameManager.player );
        gameManager.uIManager.SetCoins ( gameManager.player.playerCoins );
        Debug.Log ( "5000 Coin added" );
    }
    #endregion
}
