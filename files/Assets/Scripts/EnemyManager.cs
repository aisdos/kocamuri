using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour {

	[SerializeField] private Text killedText;
	[SerializeField] private Text waveText;
	[SerializeField] private int maxWave = 5;
	[SerializeField] private int wave = 1;
	[SerializeField] private Transform[] spawns;
	[SerializeField] private GameObject enemy;
	public static int killedEnemys = 0;

	void Start() {
		killedEnemys = 0;
		StartCoroutine (Wave ());
	}

	void Update() {
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length < 2 + wave) {
			Instantiate(enemy,spawns[Random.Range(0, spawns.Length)].position, Quaternion.identity);
		}
		killedText.text = "Megállított emberek: " + killedEnemys;
		waveText.text = "Kör: " + wave;
	}


	IEnumerator Wave() {
		yield return new WaitForSeconds (60);
		if (!(wave + 1 >= maxWave)) {
			wave++;
			StartCoroutine (Wave ());
		}
	}
}
