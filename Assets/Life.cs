using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

	public Sprite sprite;

	public SpriteRenderer spriteRenderer;

	public void SwapSprites () {
		spriteRenderer.sprite = sprite;
	}
}
