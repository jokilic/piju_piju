using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
    private int score;
    private string username;

    void Start()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
        username = PlayerPrefs.GetString("player");
        UpdateScore ();
		StartCoroutine (SpawnWaves ());
    }

	void Update()
	{
		if (restart)
		if ((Input.touchCount > 0) || Input.GetButton("Fire1"))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButton("Cancel"))
        {
            if (score > 0)
            {
                PlayerPrefs.SetInt("whiteScore", score);
                WhiteHighscores.AddNewHighscore(username, score);
            }

           /* if (PlayerPrefs.HasKey("whiteHighscore"))
            {
                if (PlayerPrefs.GetInt("whiteHighscore") < PlayerPrefs.GetInt("whiteScore"))
                    PlayerPrefs.SetInt("whiteHighscore", PlayerPrefs.GetInt("whiteScore"));
            }
            else
                PlayerPrefs.SetInt("whiteHighscore", score);*/
        }
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while(true)
		{
			
			for (int i = 0; i < hazardCount; i++)
				{
					GameObject hazard = hazards [Random.Range (0, hazards.Length)];
					Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					Quaternion spawnRotation = Quaternion.identity;
					Instantiate (hazard, spawnPosition, spawnRotation);
					yield return new WaitForSeconds (spawnWait);
				}
				
			yield return new WaitForSeconds (waveWait);

			if (gameOver)
			{
				restartText.text = "Tap to restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
        if (score > 0)
        {
            PlayerPrefs.SetInt("whiteScore", score + 10);
            WhiteHighscores.AddNewHighscore(username, score + 10);
        }

        /*if (PlayerPrefs.HasKey("whiteHighscore"))
        {
            if (PlayerPrefs.GetInt("whiteHighscore") < PlayerPrefs.GetInt("whiteScore"))
                PlayerPrefs.SetInt("whiteHighscore", PlayerPrefs.GetInt("whiteScore"));
        }
        else
            PlayerPrefs.SetInt("whiteHighscore", score + 10);*/

        gameOverText.text = "Game over";
		gameOver = true;
	}
}
