using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    #region Player Prefs Keys

    public class PlayerPrefsKeys
    {
        public static string PlayerString = "Player";


    }

    #endregion

    #region Player Default
    public static int coinsRewardOnPatternMatch = 100;
    public static int XpRewardOnDaub = 1;
    public static int coinsRewardOnMoneyCell = 100;
    public static int energyRewardOnFreeEnergy = 2;

    #endregion
    #region
    public static int totalROllsONTwoCardEntry = 5;
    public static int totalROllsONFourCardEntry = 5;
    public static int totalROllsONSixCardEntry = 5;
    public static int totalROllsONEightCardEntry = 5;
    #endregion

    #region Powerplay
    public class PowerPlay
    {
        public  static int probabilityofepic = 8; //if random between 0 to 10 is greater than 8
        public  static int probabilityofrare = 5; //if random between 0 to 10 is greater than 5 and less then epic

        public static float slidingValue = 0.1f; //Value to be incresed on every Daub
        public static int minprobabilityNumber = 0;
        public static int maxprobabilityNumber = 10;
    }
    #endregion
}
