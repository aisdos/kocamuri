using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] private float speed = 3;
	[SerializeField] private Rigidbody2D rig;
	[SerializeField] private GameObject sprite;
	[SerializeField] private Animator anim;
	[SerializeField] private RuntimeAnimatorController[] controllers;
	[SerializeField] private GameObject smoke;

	void Start() {
		anim.runtimeAnimatorController = controllers [Random.Range (0, controllers.Length)];
	}

	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		Vector2 target = (player.transform.position - gameObject.transform.position).normalized;

		if (gameObject.transform.position.x < player.transform.position.x)
			sprite.transform.rotation = Quaternion.Euler (0, 0, 0);
		else if (gameObject.transform.position.x > player.transform.position.x)
			sprite.transform.rotation = Quaternion.Euler (0, 180, 0);

		rig.velocity = target * speed;
	}

	public void Die() {
		EnemyManager.killedEnemys++;
		Instantiate (smoke, gameObject.transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
