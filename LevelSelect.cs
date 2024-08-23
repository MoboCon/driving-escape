// Used to manage an control level selection    

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

	public GameObject[] selectionIcons;

	public GameObject[] locks;

	MainMenu mainMenu;

	int currentID;

	public int[] levelPrices;

	public Text[] levelPriceTexts;

	public GameObject buyButton;

	public GameObject Loading;

	void Start()
	{

		// Read last selected level
		currentID = PlayerPrefs.GetInt("CurrentLevel");

		// Find mainMenu script to activated shop offer if needed
		mainMenu = GameObject.FindObjectOfType<MainMenu>();

		// Check each level unlocked or not 
		for (int a = 0; a < locks.Length; a++)
		{
			if (PlayerPrefs.GetInt("Level" + a.ToString()) == 3)
				locks[a].SetActive(false);
			else
				locks[a].SetActive(true);

			levelPriceTexts[a].text = levelPrices[a].ToString();

		}

		UpdateSelection(currentID);

		if (PlayerPrefs.GetInt("Level" + currentID.ToString()) == 3) // 3=>true , 0=>false	
			buyButton.SetActive(false);
	}

	public void SelectLevel(int id)
	{

		currentID = id;

		UpdateSelection(currentID);

		if (PlayerPrefs.GetInt("Level" + currentID.ToString()) == 3) // 3=>true , 0=>false	
		{
			PlayerPrefs.SetInt("CurrentLevel", currentID);
			buyButton.SetActive(false);
		}
		else
		{
			buyButton.SetActive(true);
		}
	}

	public void UpdateSelection(int id)
	{
		for (int a = 0; a < selectionIcons.Length; a++)
		{
			selectionIcons[a].SetActive(false);

		}
		selectionIcons[id].SetActive(true);
	}

	public void BuySelectedLevel()
	{
		if (PlayerPrefs.GetInt("Level" + currentID.ToString()) != 3)
		{
			if (PlayerPrefs.GetInt("Coins") >= levelPrices[currentID])
			{
				locks[currentID].SetActive(false);
				PlayerPrefs.SetInt("Level" + currentID.ToString(), 3);
				PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - levelPrices[currentID]);
				mainMenu.totalCoins.text = PlayerPrefs.GetInt("Coins").ToString();
				PlayerPrefs.SetInt("CurrentLevel", currentID);
				buyButton.SetActive(false);
			}
			else
				mainMenu.shopWindow.SetActive(true);
		}
	}


	public void StartLevel()
	{
		if (PlayerPrefs.GetInt("Level" + currentID.ToString()) == 3)
		{
			Loading.SetActive(true);
			StartCoroutine(LevelCoroutine("Level" + (PlayerPrefs.GetInt("CurrentLevel") + 1).ToString()));
		}

	}


	public GameObject LoadingScene;
	public Slider LoadingBar;

	IEnumerator LevelCoroutine(string levelName)
	{

		LoadingScene.SetActive(true);
		AsyncOperation async = SceneManager.LoadSceneAsync(levelName);
		async.allowSceneActivation = true;

		while (!async.isDone)
		{
			LoadingBar.value = (async.progress) * 100;

			yield return null;
		}
		LoadingScene.SetActive(false);
	}



}