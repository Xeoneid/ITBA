using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer))]
public class Card : MonoBehaviour {

    public CardAsset asset;
    public Vector2 pickUpSize = Vector2.one * 0.5f;
    public Vector2 bigSize = Vector2.one * 1f;
    public bool isBig = false;
    private SpriteRenderer _renderer;
    private bool pickedUp = false;

    [Header("Animation")]
    public bool animate = true;
    [Range(0.05f,0.5f)]
    public float offsetFloating;
    [Range(0.05f, 1f)]
    public float speeningSpeed = 0.3f;
    [Range(0.05f, 1f)]
    public float pickUpSpeed= 0.8f;

    private void OnValidate()
    {
        Awake();
        RenderCard();
    }

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void RenderCard()
    {
        gameObject.name = !asset ? "BlankCard" : asset.cardValue.ToString() + "Of" + asset.cardType.ToString();
        if (asset)
        {
            _renderer.enabled = true;
            _renderer.sprite = asset.sprite;
            _renderer.gameObject.transform.localScale = isBig ? bigSize : pickUpSize;
        }
        else
            _renderer.enabled = false;
    }

    // Use this for initialization
    void Start () {
        RenderCard();
	}

    public void PickUp(BaseEventData eventData)
    {
        if (!pickedUp)
        {
            Player.instance.cardsHand.Add(this);
            transform.DOMove(Player.instance.transform.position, pickUpSpeed);
            _renderer.DOFade(0, pickUpSpeed);
            //transform.DOScale(0, pickUpSpeed);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(animate)
            Animate();
	}

    void Animate()
    {
        transform.Rotate(Vector3.up * speeningSpeed);
        //transform.Translate(Vector3.up * Mathf.Sin(Time.deltaTime));
    }
}
