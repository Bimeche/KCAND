using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstantiateLevelObjects : MonoBehaviour {

	// Use this for initialization
	private string levelName;
	public List<GameObject> organsPrefabs;
	public List<GameObject> diseasesPrefabs;
	public int whichDisease;
	private CameraZoom cameraZoom;
	private List<string> diseaseList;
	private List<string> presentDiseases;
	private List<GameObject> diseases;
	public Image good1;
	public Image good2;
	public Image good3;
	public Image good4;
	public Image bad1;
	public Image bad2;
	public Image bad3;
	public Image bad4;
    public int i;
	private Camera sceneCamera;
	public Text dis1;
	public Text dis2;
	public Text dis3;
	public Text dis4;
	public GameObject pauseGamePanel;

	public List<GameObject> GetDiseases(){
		return diseases;
	}

	void Start () {
		pauseGamePanel =  GameObject.Find("Pause");
		pauseGamePanel.SetActive(false);
		sceneCamera = FindObjectOfType<Camera>();
		good1.CrossFadeAlpha(0, 0, true);
		good2.CrossFadeAlpha(0, 0, true);
		good3.CrossFadeAlpha(0, 0, true);
		good4.CrossFadeAlpha(0, 0, true);
		bad1.CrossFadeAlpha(0, 0, true);
		bad2.CrossFadeAlpha(0, 0, true);
		bad3.CrossFadeAlpha(0, 0, true);
		bad4.CrossFadeAlpha(0, 0, true);

		diseaseList = new List<string>();
		presentDiseases = new List<string>();
		diseases = new List<GameObject>();
		diseaseList.Add("Valvulopathie");
		diseaseList.Add("Ulcère");
		diseaseList.Add("Hyperlipidémie");
		diseaseList.Add("Gastrite");
		cameraZoom = FindObjectOfType<CameraZoom>();
		levelName = FindObjectOfType<NavigationBetweenScenes>().GetLevelName();

		if (levelName == "Level1")
		{
			whichDisease = 0;
			diseases.Add(Instantiate(organsPrefabs[0]));
			GameObject temp = Instantiate(diseasesPrefabs[0]);
			cameraZoom.SetHeart(temp.GetComponent<HeartScript>());
			presentDiseases.Add(diseaseList[0]);
		}
		else if (levelName == "Level2")
		{
			whichDisease = 1;
			diseases.Add(Instantiate(organsPrefabs[1]));
			GameObject temp = Instantiate(diseasesPrefabs[1]);
			cameraZoom.SetStomach(temp.GetComponent<StomachScriptIllness2>());
			presentDiseases.Add(diseaseList[1]);
			//diseases.Add(temp);
		}
		else if (levelName == "Level3")
		{
			whichDisease = Random.Range(0, organsPrefabs.Count);
			diseases.Add(Instantiate(organsPrefabs[whichDisease]));
			GameObject temp = Instantiate(diseasesPrefabs[whichDisease]);
			switch (whichDisease)
			{
				case 0:
					cameraZoom.SetHeart(temp.GetComponent<HeartScript>());
					break;
				case 1:
					cameraZoom.SetStomach(temp.GetComponent<StomachScriptIllness2>());
					break;
				case 2:
					cameraZoom.SetTrachea(temp.GetComponent<HeartIllness2>());
					break;
				case 3:
					cameraZoom.SetGastrite(temp.GetComponent<Gastrite>());
					break;
			}
			presentDiseases.Add(diseaseList[whichDisease]);
			//diseases.Add(temp);
			i = whichDisease;
			do
			{
				whichDisease = Random.Range(0, organsPrefabs.Count);
			} while (whichDisease == i);
			diseases.Add(Instantiate(organsPrefabs[whichDisease]));
			temp = Instantiate(diseasesPrefabs[whichDisease]);
			switch (whichDisease)
			{
				case 0:
					cameraZoom.SetHeart(temp.GetComponent<HeartScript>());
					break;
				case 1:
					cameraZoom.SetStomach(temp.GetComponent<StomachScriptIllness2>());
					break;
				case 2:
					cameraZoom.SetTrachea(temp.GetComponent<HeartIllness2>());
					break;
				case 3:
					cameraZoom.SetGastrite(temp.GetComponent<Gastrite>());
					break;
			}
			presentDiseases.Add(diseaseList[whichDisease]);
		}

		foreach (GameObject g in diseases)
		{
			g.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DiscoverDisease(Text value)
	{
		bool goodGuess = false;
		int i = 0;
		while(i < presentDiseases.Count && !goodGuess)
		{
			if (presentDiseases [i] == value.text) {
				goodGuess = true;
				diseases [i].SetActive (true);
			} else {
				sceneCamera.GetComponent<strikeScript> ().nbstrike--;
				if (sceneCamera.GetComponent<strikeScript> ().nbstrike == 0) {
					NavigationBetweenScenes end = FindObjectOfType<NavigationBetweenScenes> ();
					end.SetLose ();
					end.GameOver ();
				}
			}
			i++;
		}
		GoodOrBad(goodGuess, value);
	}

	private void GoodOrBad(bool goodGuess, Text value)
	{
		if (goodGuess)
		{
			switch (value.text)
			{
				case "Valvulopathie":
					dis1.text = value.text;
					good1.CrossFadeAlpha(1, 0, true);
					break;
				case "Ulcère":
					dis2.text = value.text;
					good2.CrossFadeAlpha(1, 0, true);
					break;
				case "Hyperlipidémie":
					dis3.text = value.text;
					good3.CrossFadeAlpha(1, 0, true);
					break;
				case "Gastrite":
					dis4.text = value.text;
					good4.CrossFadeAlpha(1, 0, true);
					break;
			}
		}
		else
		{
			switch (value.text)
			{
				case "Valvulopathie":
					dis1.text = value.text;
					bad1.CrossFadeAlpha(1, 0, true);
					value.color = Color.red;
					break;
				case "Ulcère":
					dis2.text = value.text;
					bad2.CrossFadeAlpha(1, 0, true);
					value.color = Color.red;
					break;
				case "Hyperlipidémie":
					dis3.text = value.text;
					bad3.CrossFadeAlpha(1, 0, true);
					value.color = Color.red;
					break;
				case "Gastrite":
					dis4.text = value.text;
					bad4.CrossFadeAlpha(1, 0, true);
					value.color = Color.red;
					break;
			}
		}
	}

	public void Cured(string value){
		switch (value)
		{
			case "Valvulopathie":
				dis1.color = Color.green;
				break;
			case "Ulcère":
				dis2.color = Color.green;
				break;
			case "Hyperlipidémie":
				dis3.color = Color.green;
				break;
			case "Gastrite":
				dis4.color = Color.green;
				break;
		}

	}

	private string GetDiseaseName(string value)
	{
		string name = "";
		foreach(char c in value)
		{
			if (c == '(')
				break;
			name += c;
		}
		return name;
	}
}
