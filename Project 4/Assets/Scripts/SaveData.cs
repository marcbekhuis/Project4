using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public UIInfo uIInfo;


    public void SaveDataTime()
    {
        PlayerPrefs.SetFloat(PlayerPrefs.GetString("CurrentPlayer") + "TimeSec", uIInfo.timeSec);
        PlayerPrefs.SetFloat(PlayerPrefs.GetString("CurrentPlayer") + "TimeMin", uIInfo.timeMin);
    }
    public void SaveCurrentPlayer(string CurrentPlayer)
    {
        PlayerPrefs.SetString("CurrentPlayer", CurrentPlayer);
    }
}
