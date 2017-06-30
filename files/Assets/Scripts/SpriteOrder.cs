using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOrder : MonoBehaviour {

	[SerializeField] private SpriteRenderer sprite;

	void Update () {
		sprite.sortingOrder = (int)gameObject.transform.position.y * -1;
	}
}
