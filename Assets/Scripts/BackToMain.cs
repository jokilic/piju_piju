using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BackToMain : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButton("Cancel"))
            SceneManager.LoadScene("Main");
    }
}
