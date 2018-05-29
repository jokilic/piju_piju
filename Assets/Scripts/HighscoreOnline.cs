using UnityEngine;
using System.Collections;
using System.Net;
using System;
using System.IO;

public class HighscoreOnline : MonoBehaviour
{
    public string GetHtmlFromUri(string resource)

    {
        string html = string.Empty;
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(resource);
        try
        {
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                bool isSuccess = (int)resp.StatusCode < 299 && (int)resp.StatusCode >= 200;
                if (isSuccess)
                {

                    using (TextReader reader = new StreamReader(resp.GetResponseStream()))
                    {
                        char[] cs = new char[80];
                        reader.Read(cs, 0, cs.Length);
                        foreach (char ch in cs)
                        {
                            html += ch;
                        }
                    }
                }
            }
        }
        catch
        {
            return "";
        }
        return html;
    }
    void Start()
    {
        string HtmlText = GetHtmlFromUri("http://google.com");
        if (HtmlText == "")
        {
            Debug.Log("Connection Not Found");
        }
        else
        {
            if (PlayerPrefs.HasKey("whiteHighscore"))
            {
                WhiteHighscores.AddNewHighscore(PlayerPrefs.GetString("player"), PlayerPrefs.GetInt("whiteHighscore"));
                PlayerPrefs.SetInt("whiteHighscore", 0);
            }

            if (PlayerPrefs.HasKey("blackHighscore"))
            {
                blackHighscores.AddNewHighscore(PlayerPrefs.GetString("player"), PlayerPrefs.GetInt("blackHighscore"));
                PlayerPrefs.SetInt("blackHighscore", 0);
            }
        }
    }
}
