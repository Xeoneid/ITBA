using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Megazord : MonoBehaviour {

    public Renderer _renderer;
    public Transform startPosition;
    public Transform endPosition;
    [Range(0.5f,3f)]
    public float movingTime;

    // Use this for initialization
    void Start () {
        PullUp();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PullUp()
    {
        transform.DOMove(endPosition.position, movingTime);
    }
}
