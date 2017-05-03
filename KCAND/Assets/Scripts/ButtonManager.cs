using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

	public InstantiateLevelObjects inst;
	private bool pause = false;
	public AudioSource sound1;
	public AudioSource sound2;
	public AudioSource sound3;
	public AudioSource sound4;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene().name == "SceneLeo" && Input.GetKeyDown(KeyCode.P))
			PauseGame();
	}

	public void ClickDisease(Text value)
	{
		if(value.color != Color.red)
			inst.DiscoverDisease(value);
	}

	public void PauseGame()
	{
		pause = !pause;
		if (pause)
		{
			Time.timeScale = 0;
			inst.pauseGamePanel.SetActive(true);
			sound1.Pause();
			sound2.Pause();
			sound3.Pause();
			sound4.Pause();
		}
		else
		{
			Time.timeScale = 1;
			inst.pauseGamePanel.SetActive(false);
			sound1.UnPause();
			sound2.UnPause();
			sound3.UnPause();
			sound4.UnPause();
		}
	}

	public void ClickBackToMenu()
	{
		SceneManager.LoadScene("Morgane");
	}

	public void ClickResume()
	{
		pause = false;
		Time.timeScale = 1;
		inst.pauseGamePanel.SetActive(false);
		sound1.UnPause();
		sound2.UnPause();
		sound3.UnPause();
		sound4.UnPause();
	}
}
