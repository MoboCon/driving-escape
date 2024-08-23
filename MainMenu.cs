using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	[Header("Display")]
	public Text totalCoins;
	public int startingScore = 0;

	public GameObject shopWindow;

	void Start()
	{

		if (GameObject.Find("LevelMusic(Clone)"))
			Destroy(GameObject.Find("LevelMusic(Clone)"));


		



		if (PlayerPrefs.GetInt("FirstRun") != 3)
		{
			// Default game settings

			PlayerPrefs.SetInt("FirstRun", 3);

			PlayerPrefs.SetInt("Aspect", 0);

			PlayerPrefs.SetInt("Music", 3);

			PlayerPrefs.SetInt("Level0", 3);

			PlayerPrefs.SetInt("DriveType0", 3);

			PlayerPrefs.SetInt("ThrottleMode", 1);

			PlayerPrefs.SetInt("Vibrate", 3);

			PlayerPrefs.SetFloat("MusicVolume", 0.7f);

			PlayerPrefs.SetFloat("FXVolume", 0.7f);

			PlayerPrefs.SetFloat("SteerSpeed", 14f);
			// Open first bike
			PlayerPrefs.SetInt("Bike0", 3);

			// Add starting coins to game first running 
			PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + startingScore);
		}

		totalCoins.text = PlayerPrefs.GetInt("Coins").ToString();
	}

	void Update()
	{

		if (Input.GetKeyDown(KeyCode.H))
		{
			PlayerPrefs.DeleteAll();
			Debug.Log("PlayerPrefs.DeleteAll");
		}


		if (Input.GetKeyDown(KeyCode.E))
		{
			PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 10000);
			Debug.Log("10.000 coins added ");
		}

	}

	public void SetTrue(GameObject target)
	{
		target.SetActive(true);
	}

	public void SetFalse(GameObject target)
	{
		target.SetActive(false);
	}

	public void ToggleObject(GameObject target)
	{
		target.SetActive(!target.activeSelf);
	}

	public void Exit()
	{
		Application.Quit();
	}

	public void LoadLevel(string name)
	{
		SceneManager.LoadScene(name);
	}

	public void OpenAPP(string packageName)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			Application.OpenURL("market://details?id=" + packageName);
		}
		else
		{
			Application.OpenURL("https://play.google.com/store/apps/details?id=" + packageName);
		}
	}
	public void OpenDeveloper(string packageName)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			Application.OpenURL("market://developer?id=" + packageName);
		}
		else
		{
			Application.OpenURL("https://play.google.com/store/apps/developer?id=" + packageName);
		}
	}
}
