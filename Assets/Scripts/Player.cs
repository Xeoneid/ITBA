using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// SingletonClass
/// </summary>
public class Player : MonoBehaviour {

    [HideInInspector]
    public static Player instance { get; private set; }

    [Range(0.01f,10f)]
    [Tooltip("The speed of the player expresed in m/s (meters per second)")]
    public float speed;
    private bool isTravelling = false;
    public bool canMove = true;
    /// <summary>
    /// The waypoint that the player is in
    /// </summary>
    private Waypoint currentWaypoint;
    [Range(1f, 2f)]
    public float floorDistance = 1.6f;
    public List<Card> cardsHand;
    public List<Transform> handPosition;

    private void Awake()
    {
        // Check if another instance exists
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is another instance of " + this.GetType());
            DestroyImmediate(this);
        }
    }

    public bool MoveTo(Waypoint waypoint)
    {
        if (canMove)
        {
            if (isTravelling)
                transform.DOKill();
            isTravelling = true;
            Vector3 newPosition = waypoint.transform.position + (Vector3.up * floorDistance);
            transform.DOMove(newPosition, GetTravelTime(newPosition)).OnComplete(() => { isTravelling = false; });

            waypoint.gameObject.SetActive(false);
            if (currentWaypoint && currentWaypoint.returnable)
                currentWaypoint.gameObject.SetActive(true);
            currentWaypoint = waypoint;

            return true;
        }
        else
            return false;
    }

    private float GetTravelTime(Vector3 position)
    {
        float distance = Vector3.Distance(transform.position, position);
        return distance / speed;
    }
}
