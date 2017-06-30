using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float speed = 4;
	[SerializeField] private Rigidbody2D rig;
	[SerializeField] private Animator anim;
	[SerializeField] private GameObject gameOver;
	[SerializeField] private Button back;
	[SerializeField] private Button retry;
	private Vector3 target;
	//[SerializeField] private Shader shader;
	[SerializeField] private AudioClip deadSound;
	private bool dead;

	void Start() {
		back.onClick.AddListener (() => {
			SceneManager.LoadScene(0);
		});
		retry.onClick.AddListener (() => {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		});
	}

	void Update () {
		if (!dead) {
			if (Input.touchCount > 0) {
				if (Input.GetTouch (0).phase != TouchPhase.Canceled || Input.GetTouch (0).phase != TouchPhase.Ended) {
					target = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
				}
			} else if (Input.GetButton ("Fire1")) {
				target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			} else {
				target = gameObject.transform.position;
			}

			Vector2 velocity = (target - gameObject.transform.position).normalized * speed;
			rig.velocity = velocity;
			//print (rig.velocity);

			float move = velocity.x + velocity.y;
			if (move < 0)
				move *= -1;
			anim.SetFloat ("move", move);

			if (target.x < gameObject.transform.position.x)
				anim.gameObject.transform.transform.rotation = Quaternion.Euler (0, 180, 0);
			else if (target.x > gameObject.transform.position.x) {
				anim.gameObject.transform.transform.rotation = Quaternion.Euler (0, 0, 0);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.GetComponent<Enemy> () != null) {
			gameOver.SetActive (true);
			anim.SetBool ("dead", true);
			dead = true;

			AudioSource.PlayClipAtPoint (deadSound, gameObject.transform.position, 0.5f);

			PlayerPrefs.SetInt ("score", EnemyManager.killedEnemys);
			/*StreamWriter sw = new StreamWriter (Application.persistentDataPath + "/score.txt", false);
			sw.WriteLine ("score:"+EnemyManager.killedEnemys);
			sw.Close ();*/
		}
	}
}
