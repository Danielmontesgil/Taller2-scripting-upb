using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject peligros;
	public Vector3 spawnValues;
	public int contadorPeligros;
	public float spawnWait;
	public float startWave;
	public float waveWait;
	 
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;

	void Start() {
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update()
	{
		if (restart)
		{
			if(Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
	
	IEnumerator SpawnWaves (){
		yield return new WaitForSeconds (startWave);
		while (true){	
			for (int i = 0; i < contadorPeligros; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (peligros, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if(gameOver)
			{
				restartText.text="Presione 'R' para Reiniciar";
				restart=true;
				break;
			}
		}
	}

	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver(){
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
