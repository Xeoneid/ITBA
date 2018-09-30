using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Card : MonoBehaviour {

    public CardAsset asset;
    public Vector2 pickUpSize = Vector2.one * 0.5f;
    public Vector2 bigSize = Vector2.one * 1f;
    public bool isBig = false;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void RenderCard()
    {
        _renderer.sprite = asset.sprite;
        _renderer.size = isBig ? bigSize : pickUpSize;
    }

    // Use this for initialization
    void Start () {
        RenderCard();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
