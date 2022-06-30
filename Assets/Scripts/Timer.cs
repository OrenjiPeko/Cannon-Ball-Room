using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public GameObject player;
    public GameObject explosion;
    GameObject expCurrent;

    public Text timer;
    public Text score;

    bool countdown;
    public static bool game;
    bool explode;

    float countTimer;
    float gameTimer;

    public static int currentScore;

	// Use this for initialization
	void Start ()
    {
        countdown = true;
        game = false;
        explode = false;

        countTimer = 3f;
        gameTimer = 45f;

        currentScore = 0;
        score.text = "";
	}
	
	// Update is called once per frame
	void Update ()
    {
        player.transform.position = player.transform.position;       

		if (countdown)
        {
            countTimer -= Time.deltaTime;
            timer.text = "" + countTimer.ToString("F0");

            if(countTimer <= 0)
            {
                game = true;
                countdown = false;
            }
        }

        if (game)
        {
            gameTimer -= Time.deltaTime;
            timer.text = "" + gameTimer.ToString("F0");

            if(gameTimer <= 0)
            {
                explode = true;
                game = false;
            }
        }

        if (explode)
        {           
            StartCoroutine("Explode");
            explode = false;
        }

        if (!countdown && !game)
        {
            timer.text = "";
            score.text = "" + currentScore.ToString();
            score.fontSize = currentScore;
        }

        Debug.Log(currentScore + "");
    }

    private void FixedUpdate()
    {
        expCurrent.transform.localScale += new Vector3(2.5f, 2.5f, 2.5f) * Time.fixedDeltaTime;
    }

    IEnumerator Explode()
    {
        expCurrent = Instantiate(explosion, player.transform.position, player.transform.rotation);
        player.transform.position = player.transform.position;
        yield return new WaitForSeconds(3f);
        if(PlayerPrefs.GetInt("Score") < currentScore)
        {
            PlayerPrefs.SetInt("Score", currentScore);
        }
        Destroy(expCurrent.gameObject);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenu");
    }

}
