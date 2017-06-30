using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	[SerializeField] private SpriteRenderer sprite;
	[SerializeField] private Animator anim;
	[SerializeField] private RuntimeAnimatorController[] controllers;
	[SerializeField] private AudioClip sound;
	[SerializeField] private bool unusable;

	void Start() {
		anim.runtimeAnimatorController = controllers [Random.Range (0, controllers.Length)];
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (!unusable) {
			if (col.GetComponent<Enemy> () != null) {
				col.GetComponent<Enemy> ().Die ();
				anim.SetBool ("unusable", true);
				AudioSource.PlayClipAtPoint (sound, gameObject.transform.position, 1);
				unusable = true;
				StartCoroutine (Reparo ());
			}
		}
	}

	IEnumerator Reparo() {
		yield return new WaitForSeconds (15);
		unusable = false;
		anim.SetBool ("unusable", false);
	}
}
