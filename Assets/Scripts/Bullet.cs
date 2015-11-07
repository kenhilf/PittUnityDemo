﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    public float Speed = 300f;
    public List<GameObject> IgnoreObjects = new List<GameObject>();
    private Rigidbody _rigidbody;

	private void Start()
	{
        _rigidbody = GetComponent<Rigidbody>();
	}
	
	private void FixedUpdate()
	{
        _rigidbody.velocity = transform.forward * Speed * Time.deltaTime;
	}

    private void OnCollisionEnter(Collision col)
    {
        Rigidbody rb = col.collider.attachedRigidbody;
        if (rb != null)
        {
            if (IgnoreObjects.Contains(rb.gameObject))
            {
                return;
            }
        }

        Debug.Log("Destroyed by hitting " + col.gameObject.name);
        Destroy(gameObject);
    }
}
