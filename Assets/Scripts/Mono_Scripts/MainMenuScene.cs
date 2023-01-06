using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScene : MonoBehaviour
{
    public GameObject bingoPanel;
    public GameObject attackPanel;
    public GameObject shopPanel;
    public GameObject buttonPanel;
    public Toggle button;
    public Toggle button1;
    public Toggle button2;
    public Toggle button3;
    void Start () {
        bingoPanel.SetActive(true);
        button1.targetGraphic.color=Color.green;
        attackPanel.SetActive ( false );
        shopPanel.SetActive ( false );
    }
    #region SETTING PANELS
    public void onClickProfile () {
        //Debug.Log ( "Profile Button clicked!" );
    }
    public void onClickAddPack () {
        //Debug.Log ( "Add Packs Button clicked!" );
    }
    public void onClickSettings () {
        //Debug.Log ( "Setting Button Clicked!" );
    }
    public void onClickShop () {
        bingoPanel.SetActive ( false );
        attackPanel.SetActive ( false );
        shopPanel.SetActive ( true );
        //Debug.Log ( "Shop Button Clicked!" );
        if ( button.isOn ) {
            button.targetGraphic.color = Color.green;
        } else {
            button.targetGraphic.color = Color.white;
        }
    }
    public void onClickBingo () {
        bingoPanel.SetActive ( true );
        attackPanel.SetActive ( false );
        shopPanel.SetActive ( false );
        //Debug.Log ( "Bingo Button Clicked!" );
        if ( button1.isOn ) {
            button1.targetGraphic.color = Color.green;
        } else {
            button1.targetGraphic.color = Color.white;
        }
    }
    public void onClickVillage () {
        bingoPanel.SetActive ( false );
        attackPanel.SetActive ( false );
        shopPanel.SetActive ( false );
        SceneManager.LoadScene ( "VillageScene" );
        //Debug.Log ( "Village Button Clicked!" );
        if ( button2.isOn ) {
            button2.targetGraphic.color = Color.green;
        } else {
            button2.targetGraphic.color = Color.white;
        }
    }
    public void onClickAttack () {
        bingoPanel.SetActive ( false );
        attackPanel.SetActive ( true );
        shopPanel.SetActive ( false );
        //Debug.Log ( "Attack Button Clicked!" );
        if ( button3.isOn ) {
            button3.targetGraphic.color = Color.green;
        } else {
            button3.targetGraphic.color = Color.white;
        }
    }
    #endregion
}
