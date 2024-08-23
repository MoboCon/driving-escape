using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeniuP : MonoBehaviour
{
    public void LoadMap()
    {
        SceneManager.LoadScene("Meniu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}