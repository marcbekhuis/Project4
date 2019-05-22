using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SaveData : MonoBehaviour
{
    public UIInfo uIInfo;


    public void SaveDataTime()
    {
        PlayerPrefs.SetFloat(PlayerPrefs.GetString("CurrentPlayer") + "TimeSec", uIInfo.timeSec);
        PlayerPrefs.SetFloat(PlayerPrefs.GetString("CurrentPlayer") + "TimeMin", uIInfo.timeMin);

        for (int x = 0; x < 8; x++)
        {
            if (PlayerPrefs.GetFloat(x.ToString() + "TimeSec") + PlayerPrefs.GetFloat(x.ToString() + "TimeMin") * 60 < PlayerPrefs.GetFloat(PlayerPrefs.GetString("CurrentPlayer") + "TimeSec") + PlayerPrefs.GetFloat(PlayerPrefs.GetString("CurrentPlayer") + "TimeMin") * 60)
            {
                float timeSec = PlayerPrefs.GetFloat(x.ToString() + "TimeSec");
                float timeMin = PlayerPrefs.GetFloat(x.ToString() + "TimeMin");
                string playerName = PlayerPrefs.GetString(x.ToString() + "PlayerName");

                float timeSec2;
                float timeMin2;
                string playerName2;

                PlayerPrefs.SetFloat(x.ToString() + "TimeSec", PlayerPrefs.GetFloat(PlayerPrefs.GetString("CurrentPlayer") + "TimeSec"));
                PlayerPrefs.SetFloat(x.ToString() + "TimeMin", PlayerPrefs.GetFloat(PlayerPrefs.GetString("CurrentPlayer") + "TimeMin"));
                PlayerPrefs.SetString(x.ToString() + "PlayerName", PlayerPrefs.GetString("CurrentPlayer"));
                for (int y = 1; y < 8; y++)
                {
                    timeSec2 = PlayerPrefs.GetFloat(y.ToString() + "TimeSec");
                    timeMin2 = PlayerPrefs.GetFloat(y.ToString() + "TimeMin");
                    playerName2 = PlayerPrefs.GetString(y.ToString() + "PlayerName");

                    PlayerPrefs.SetFloat(y.ToString() + "TimeSec", timeSec);
                    PlayerPrefs.SetFloat(y.ToString() + "TimeMin", timeMin);
                    PlayerPrefs.SetString(y.ToString() + "PlayerName", playerName);

                    timeSec = timeSec2;
                    timeMin = timeMin2;
                    playerName = playerName2;
                }
                break;
            }
        }

    }
    public void SaveCurrentPlayer(InputField inputfield)
    {
        PlayerPrefs.SetString("CurrentPlayer", inputfield.text);
    }

    public void LoadHighScore(Text display)
    {
        string scores = "";
        for (int x = 0; x < 8; x++)
        {
            scores += PlayerPrefs.GetString(x.ToString() + "PlayerName") + ": " + PlayerPrefs.GetFloat(x.ToString() + "TimeMin").ToString("F0") + ":" + PlayerPrefs.GetFloat(x.ToString() + "TimeSec").ToString("F0") + "\n";
        }
        display.text = scores;
    }
}
