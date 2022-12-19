using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void onClickEnergyPanel1 () {
        Debug.Log ( "1 Energy added ⚡" );
    }
    public void onClickEnergyPanel2 () {
        Debug.Log ( "5 Energy added ⚡" );
    }
    public void onClickEnergyPanel3 () {
        Debug.Log ( "20 Energy added ⚡" );
    }
    public void onClickPowerplayPanel1 () {
        Debug.Log ( "5 Powerplay added" );
    }
    public void onClickPowerplayPanel2 () {
        Debug.Log ( "10 Powerplay added" );
    }
    public void onClickPowerplayPanel3 () {
        Debug.Log ( "50 Powerplay added" );
    }
    public void onClickCoinPanel1 () {
        Debug.Log ( "500 Coin added" );
    }
    public void onClickCoinPanel2 () {
        Debug.Log ( "2000 Coin added" );
    }
    public void onClickCoinPanel3 () {
        Debug.Log ( "5000 Coin added" );
    }
}
