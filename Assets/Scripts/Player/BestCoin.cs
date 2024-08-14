using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BestCoin
{
    private const string NameSaveCoin = "BestCoin";
    public static void SetBestCoin(int coin)
    {
        if (PlayerPrefs.HasKey(NameSaveCoin))
        {
            int _best = PlayerPrefs.GetInt(NameSaveCoin);
            if(Player.instance.GetCoin() > _best)
            {
                PlayerPrefs.SetInt(NameSaveCoin, coin);
            }
        }
    }
    public static int GetBestCoin()
    {
        if(PlayerPrefs.HasKey(NameSaveCoin))
            return PlayerPrefs.GetInt(NameSaveCoin);
        return 0;
    }
}
