using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerName : MonoBehaviour
{
    private InputField input;

    void Start()
    {
        input = GameObject.Find("InputField").GetComponent<InputField>();
        if (PlayerPrefs.HasKey("player"))
            input.text = PlayerPrefs.GetString("player");
    }

    public void GetInput(string text)
    {
        Debug.Log(text);
        PlayerPrefs.SetString("player", text);
    }
}
