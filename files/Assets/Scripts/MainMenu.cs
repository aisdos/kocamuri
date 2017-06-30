using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	[SerializeField] private Button player;
	[SerializeField] private Text highScore;
	[SerializeField] private GameObject loading;

	void Start () {
		player.onClick.AddListener(() => {
			loading.SetActive(true);
			SceneManager.LoadScene(1);
		});
		GetHighScore ();
	}
	
	void GetHighScore() {
		/*try {
			StreamReader sr = new StreamReader (Application.persistentDataPath+"/score.txt");
			while (!sr.EndOfStream) {
				string[] s = sr.ReadLine ().Split (':');
				if (s[0] == "score")
					highScore.text = "Legynagyobb pontszám: " + s[1];
			}
			sr.Close ();
		}
		catch {

		}*/
		highScore.text = "Legnagyobb pontszám: "+PlayerPrefs.GetInt ("score");
	}
}
