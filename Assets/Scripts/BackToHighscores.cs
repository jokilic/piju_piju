using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BackToHighscores : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButton("Cancel"))
            SceneManager.LoadScene("Highscores");
    }
}
