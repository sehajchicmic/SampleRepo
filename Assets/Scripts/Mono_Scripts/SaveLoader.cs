using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SaveLoader : MonoBehaviour
{
    public void SavePlayerData(Player player)
    {
        string serializedData = JsonUtility.ToJson(player,true);

        PlayerPrefs.SetString(Constants.PlayerPrefsKeys.PlayerString, serializedData);
    }

    public Player LoadPlayerData()
    {
        Player newPlayer = new Player();

        string value = PlayerPrefs.GetString(Constants.PlayerPrefsKeys.PlayerString, JsonUtility.ToJson(newPlayer, true));
        Player player = (Player)JsonUtility.FromJson(value,typeof(Player));
        return player;
    }
}
