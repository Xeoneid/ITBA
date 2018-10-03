using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public Rigidbody _rigidbody { get; private set; }
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public bool isActive { get; private set; }

    /// <summary>
    /// Activates/Deactivates bullet GameObject
    /// </summary>
    /// <param name="enabled"></param>
    public void SetActive(bool enabled)
    {
        isActive = enabled;
        gameObject.SetActive(enabled);
        _rigidbody.velocity = Vector3.zero;
        if (!enabled)
            BulletsManager.instance.bulletPool.Push(this);
    }

    private float timeAlive = 0;

    private void Update()
    {
        if (timeAlive >= BulletsManager.BulletsTimeAlive)
        {
            timeAlive = 0;
            SetActive(false);
        }
        else
            timeAlive += Time.deltaTime;
    }
}