using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Script : MonoBehaviour {

    public Text HighScore;

	public void MainloadingGame()
    {
        SceneManager.LoadScene("SampleScene 1");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    void Update()
    {
        HighScore.text = "High Score : \n \n" + PlayerPrefs.GetInt("Score");
    }
}
