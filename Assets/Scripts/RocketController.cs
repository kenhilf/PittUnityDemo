using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour
{
	private Rigidbody _rigidbody;
	public KeyCode KeyForward;
	public KeyCode KeyRight;
	public KeyCode KeyLeft;

	public float Speed = 8f;
	public float RotationalSpeed = 45;

	private void Start()
	{
		 _rigidbody = GetComponent<Rigidbody>();
	}
	
	private void FixedUpdate()
	{
		if (Input.GetKey(KeyForward))
		{
			_rigidbody.velocity = transform.forward * Speed * Time.deltaTime;
		}
		else
		{
			_rigidbody.velocity = Vector3.zero;
		}

		if (Input.GetKey(KeyLeft))
		{
			transform.Rotate(transform.up * -RotationalSpeed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyRight))
		{
			transform.Rotate(transform.up * RotationalSpeed * Time.deltaTime);
		}

	}
}
