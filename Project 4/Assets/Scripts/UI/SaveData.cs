using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SaveData : MonoBehaviour
{
    public UIInfo uIInfo;

    
    // function to save the time you survived
    public void SaveDataTime()
    {
        // checks if CurrentPlayer is set.
        if (PlayerPrefs.GetString("CurrentPlayer") != "")
        {
            // save the time in sec and min
            PlayerPrefs.SetFloat(PlayerPrefs.GetString("CurrentPlayer") + "TimeSec", uIInfo.timeSec);
            PlayerPrefs.SetFloat(PlayerPrefs.GetString("CurrentPlayer") + "TimeMin", uIInfo.timeMin);

            // loops through the top times to update it
            for (int x = 0; x < 8; x++)
            {
                // check if the new score is higher then a score in the top scores
                if (PlayerPrefs.GetFloat(x.ToString() + "TimeSec") + PlayerPrefs.GetFloat(x.ToString() + "TimeMin") * 60 < PlayerPrefs.GetFloat(PlayerPrefs.GetString("CurrentPlayer") + "TimeSec") + PlayerPrefs.GetFloat(PlayerPrefs.GetString("CurrentPlayer") + "TimeMin") * 60)
                {
                    // saves score of the old top
                    float timeSec = PlayerPrefs.GetFloat(x.ToString() + "TimeSec");
                    float timeMin = PlayerPrefs.GetFloat(x.ToString() + "TimeMin");
                    string playerName = PlayerPrefs.GetString(x.ToString() + "PlayerName");

                    float timeSec2;
                    float timeMin2;
                    string playerName2;

                    // sets the new top high score to new time and name.
                    PlayerPrefs.SetFloat(x.ToString() + "TimeSec", PlayerPrefs.GetFloat(PlayerPrefs.GetString("CurrentPlayer") + "TimeSec"));
                    PlayerPrefs.SetFloat(x.ToString() + "TimeMin", PlayerPrefs.GetFloat(PlayerPrefs.GetString("CurrentPlayer") + "TimeMin"));
                    PlayerPrefs.SetString(x.ToString() + "PlayerName", PlayerPrefs.GetString("CurrentPlayer"));
                    for (int y = 1; y < 8; y++)
                    {
                        // saves the old score
                        timeSec2 = PlayerPrefs.GetFloat(y.ToString() + "TimeSec");
                        timeMin2 = PlayerPrefs.GetFloat(y.ToString() + "TimeMin");
                        playerName2 = PlayerPrefs.GetString(y.ToString() + "PlayerName");

                        // sets the new score
                        PlayerPrefs.SetFloat(y.ToString() + "TimeSec", timeSec);
                        PlayerPrefs.SetFloat(y.ToString() + "TimeMin", timeMin);
                        PlayerPrefs.SetString(y.ToString() + "PlayerName", playerName);

                        // sets scores
                        timeSec = timeSec2;
                        timeMin = timeMin2;
                        playerName = playerName2;
                    }
                    break;
                }
            }
        }

    }

    // Saves currentplayer name
    public void SaveCurrentPlayer(InputField inputfield)
    {
        PlayerPrefs.SetString("CurrentPlayer", inputfield.text);
    }

    // function to display the top scores
    public void LoadHighScore(Text display)
    {
        string scores = "";
        // loops through all the scores and adds them to a string
        for (int x = 0; x < 8; x++)
        {
            scores += PlayerPrefs.GetString(x.ToString() + "PlayerName") + ": " + PlayerPrefs.GetFloat(x.ToString() + "TimeMin").ToString("F0") + ":" + PlayerPrefs.GetFloat(x.ToString() + "TimeSec").ToString("F0") + "\n";
        }
        // sets the string to show on the text object.
        display.text = scores;
    }
}
