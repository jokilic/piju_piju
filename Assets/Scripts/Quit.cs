using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour
{
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButton("Cancel"))
            Application.Quit();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
