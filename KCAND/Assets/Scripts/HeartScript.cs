using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartScript : MonoBehaviour {

	public bool isZoomed = false;
	public List<Transform> pillsSpawnList;
	private List<Transform> pillsSpawningList;
	public List<GameObject> pillsPrefabs;
	public GameObject redPillPrefab;
	public GameObject greenPillPrefab;
	public GameObject blackPillPrefab;
	public GameObject whitePillPrefab;
	private Hashtable pillsSpawned;
	private int blackPillsClicked = 0;
	private int greenPillsClicked = 0;
	private int redPillsClicked = 0;
	private int whitePillsClicked = 0;
	private int blackPillsCount = 0;
	private int greenPillsCount = 0;
	private int redPillsCount = 0;
	private int whitePillsCount = 0;
	private List<GameObject> pillsToClick;
	private Camera sceneCamera;
	private FillSheet sheet;
	private bool isCure;
    private AudioSource achievement;

	// Use this for initialization
	void Start () {
		bool pulmonaryOedema;
		bool breathlessness;
        achievement = GameObject.Find("achievement").GetComponent<AudioSource>();


		isCure = false;
        sheet = FindObjectOfType<FillSheet>();
        sceneCamera = FindObjectOfType<Camera>();

        pulmonaryOedema = sheet.getPulmonaryOedema();
        breathlessness = sheet.getBreathlessness();

        pillsSpawningList = new List<Transform>();
		foreach(Transform item in pillsSpawnList)
		{
			pillsSpawningList.Add(item);
		}

		Transform whichSpawn;
		GameObject whichPill;
		int numberOfPillsToSpawn;
		pillsSpawned = new Hashtable();
		numberOfPillsToSpawn = Random.Range(2, 5);
		for (int i = 0; i < numberOfPillsToSpawn; i++)
		{
			whichSpawn = pillsSpawnList[Random.Range(0, pillsSpawnList.Count)];
			whichPill = pillsPrefabs[Random.Range(0, pillsPrefabs.Count)];
			pillsSpawned[whichSpawn] = (Instantiate(whichPill, whichSpawn.position, Quaternion.Euler(0,0,0), transform));
			pillsSpawnList.Remove(whichSpawn);
			switch (whichPill.name)
			{
				case "BlackPill":
					blackPillsCount++;
					break;
				case "RedPill":
					redPillsCount++;
					break;
				case "GreenPill":
					greenPillsCount++;
					break;
				case "WhitePill":
					whitePillsCount++;
					break;
				default:
					break;
			}
		}


		pillsToClick = new List<GameObject>();
		if (blackPillsCount == 2)
		{
			// cliquer sur le 2 pilules noires
			foreach (Transform spawn in pillsSpawningList)
			{
				GameObject tempPill = (GameObject)pillsSpawned[spawn];
				if (tempPill != null && tempPill.name.Contains("BlackPill"))
					pillsToClick.Add(tempPill);
			}
		}
		//else if (greenPillsCount >0 && age <= 25){
		//	// ne cliquer sur aucune
		//	pillsToClick.Clear();
		//}
		else if(greenPillsCount == 1 && redPillsCount == 1 && blackPillsCount == 1 && pillsSpawned.Count == 3)
		{
			// cliquer sur la verte
			foreach (Transform spawn in pillsSpawningList)
			{
				GameObject tempPill = (GameObject)pillsSpawned[spawn];
				if (tempPill != null && tempPill.name.Contains("GreenPill"))
					pillsToClick.Add(tempPill);
			}
		}
		else if (pulmonaryOedema)
		{
			// cliquer sur la deuxième en partant de la gauche
			if (pillsSpawned.ContainsKey(pillsSpawningList[0]))
			{
				if (pillsSpawned.ContainsKey(pillsSpawningList[1]))
				{
					pillsToClick.Add((GameObject)pillsSpawned[pillsSpawningList[1]]);
				}
				else if (pillsSpawned.ContainsKey(pillsSpawningList[2]))
				{
					pillsToClick.Add((GameObject)pillsSpawned[pillsSpawningList[2]]);
				}
				else
				{
					pillsToClick.Add((GameObject)pillsSpawned[pillsSpawningList[3]]);
				}
			}
			else if (pillsSpawned.ContainsKey(pillsSpawningList[1]))
			{
				if (pillsSpawned.ContainsKey(pillsSpawningList[2]))
				{
					pillsToClick.Add((GameObject)pillsSpawned[pillsSpawningList[2]]);
				}
				else
				{
					pillsToClick.Add((GameObject)pillsSpawned[pillsSpawningList[3]]);
				}
			}
			else
			{
				pillsToClick.Add((GameObject)pillsSpawned[pillsSpawningList[3]]);
			}
		}
		else if (pillsSpawned.Count == 4 && redPillsCount == 0)
		{
			if (breathlessness)
			{
				// cliquer sur la plus à gauche
				if (pillsSpawned.ContainsKey(pillsSpawningList[0]))
				{
					pillsToClick.Add((GameObject)pillsSpawned[pillsSpawningList[0]]);
				}
				else if (pillsSpawned.ContainsKey(pillsSpawningList[1]))
				{
					pillsToClick.Add((GameObject)pillsSpawned[pillsSpawningList[1]]);
				}
				else if (pillsSpawned.ContainsKey(pillsSpawningList[2]))
				{
					pillsToClick.Add((GameObject)pillsSpawned[pillsSpawningList[2]]);
				}
				else
				{
					pillsToClick.Add((GameObject)pillsSpawned[pillsSpawningList[3]]);
				}
			}
		}
		else if (whitePillsCount > 0)
		{
			// cliquer sur toutes les pilules blanches
			foreach (Transform spawn in pillsSpawningList)
			{
				GameObject tempPill = (GameObject)pillsSpawned[spawn];
				if(tempPill != null && tempPill.name.Contains("WhitePill"))
					pillsToClick.Add(tempPill);
			}
		}
		else
		{
			// cliquer sur toutes les pilules
			foreach (Transform spawn in pillsSpawningList)
			{
				GameObject tempPill = (GameObject)pillsSpawned[spawn];
				if (tempPill != null)
					pillsToClick.Add(tempPill);
			}
		}


		foreach (Transform spawn in pillsSpawningList)
		{
			GameObject tempPill = (GameObject)pillsSpawned[spawn];
			if (tempPill != null)
				tempPill.SetActive(false);
		}

		

	}

	public void DisplayDisease()
	{
		if (!isCure)
		{
			foreach (Transform spawn in pillsSpawningList)
			{
				GameObject tempPill = (GameObject)pillsSpawned[spawn];
				if (tempPill != null)
					tempPill.SetActive(true);
			}
		}
	}

	public void HideDisease()
	{
		foreach (Transform spawn in pillsSpawningList)
		{
			GameObject tempPill = (GameObject)pillsSpawned[spawn];
			if (tempPill != null)
				tempPill.SetActive(false);
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (isZoomed && Input.GetMouseButtonDown(0))
		{
			var ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 1000))
			{
				if (hit.collider.name.Contains("Black"))
				{
					blackPillsClicked++;
					if (pillsToClick.Contains(hit.collider.gameObject))
					{
						pillsToClick.Remove(hit.collider.gameObject);
					}
					else
					{
						sceneCamera.GetComponent<strikeScript> ().nbstrike--;
						if (sceneCamera.GetComponent<strikeScript> ().nbstrike == 0){
							NavigationBetweenScenes end = FindObjectOfType<NavigationBetweenScenes> ();
							end.SetLose ();
							end.GameOver ();
						}
					}
					Destroy(hit.collider.gameObject);
				}
				else if (hit.collider.name.Contains("Red"))
				{
					redPillsClicked++;
					if (pillsToClick.Contains(hit.collider.gameObject))
					{
						pillsToClick.Remove(hit.collider.gameObject);
					}
					else
					{
						sceneCamera.GetComponent<strikeScript> ().nbstrike--;
						if (sceneCamera.GetComponent<strikeScript> ().nbstrike == 0){
							NavigationBetweenScenes end = FindObjectOfType<NavigationBetweenScenes> ();
							end.SetLose ();
							end.GameOver ();
						}
					}
					Destroy(hit.collider.gameObject);
				}
				else if (hit.collider.name.Contains("Green"))
				{
					greenPillsClicked++;
					if (pillsToClick.Contains(hit.collider.gameObject))
					{
						pillsToClick.Remove(hit.collider.gameObject);
					}
					else
					{
						sceneCamera.GetComponent<strikeScript> ().nbstrike--;
						if (sceneCamera.GetComponent<strikeScript> ().nbstrike == 0){
							NavigationBetweenScenes end = FindObjectOfType<NavigationBetweenScenes> ();
							end.SetLose ();
							end.GameOver ();
						}
                    }
					Destroy(hit.collider.gameObject);
				}
				else if (hit.collider.name.Contains("White"))
				{
					whitePillsClicked++;
					if (pillsToClick.Contains(hit.collider.gameObject))
					{
						pillsToClick.Remove(hit.collider.gameObject);
					}
					else
					{
						sceneCamera.GetComponent<strikeScript> ().nbstrike--;
						if (sceneCamera.GetComponent<strikeScript> ().nbstrike == 0){
							NavigationBetweenScenes end = FindObjectOfType<NavigationBetweenScenes> ();
							end.SetLose ();
							end.GameOver ();
						}
					}
					Destroy(hit.collider.gameObject);
				}

			}

			if (pillsToClick.Count == 0)
			{
				Debug.Log ("Win");
				isCure = true;
				FindObjectOfType<InstantiateLevelObjects> ().Cured ("Valvulopathie");
                achievement.Play();
				GameObject.FindGameObjectWithTag("Heart").GetComponent<Renderer>().material.SetColor("_SpecColor", Color.green);
				NavigationBetweenScenes end = FindObjectOfType<NavigationBetweenScenes> ();
				end.ModuleCured ();
				HideDisease ();
            }
		}
	}
}
