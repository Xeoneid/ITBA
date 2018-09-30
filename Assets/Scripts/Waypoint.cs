using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Waypoint : MonoBehaviour {

    public bool rotateCamera;
    private Player player;
    [Tooltip("Can the player get back here?")]
    /// <summary>
    /// Can the player get back here?
    /// </summary>
    public bool returnable = true;
    public UnityEvent onTravelling = new UnityEvent();

    private void Start()
    {
        player = Player.instance;
    }

    public void TravelTo(BaseEventData eventData)
    {
        player.MoveTo(this);
        onTravelling.Invoke();
    }
}
