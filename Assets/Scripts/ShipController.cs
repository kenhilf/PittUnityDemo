using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour
{
    public PlayerData Player;

    public float Speed = 1f;
    public float TurningSpeed = 30f;

    public GameObject BulletPrefab;
    public Transform BulletSpawnPoint;

    private Rigidbody _rigidbody;
    private Vector3 _velocity = Vector3.zero;
    private Vector3 _outsideForces = Vector3.zero;

    private void Start()
	{
        _rigidbody = GetComponent<Rigidbody>();
        Renderer[] r = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < r.Length; i++)
        {
            r[i].material.color = Player.PlayerColor;
        }
	}

    private void Update()
	{
        if (Input.GetKeyDown(Player.KeyFire))
        {
            GameObject bullet = (GameObject)Instantiate(BulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
            bullet.GetComponent<Bullet>().IgnoreObjects.Add(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(Player.KeyForward))
        {
            _velocity = transform.forward * Speed * Time.deltaTime;
        }
        else
        {
            _velocity *= 0.95f;
        }

        if (Input.GetKey(Player.KeyLeft))
        {
            transform.Rotate(transform.up, -TurningSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(Player.KeyRight))
        {
            transform.Rotate(transform.up, TurningSpeed * Time.deltaTime);
        }

        _rigidbody.velocity = _velocity + _outsideForces;

        _outsideForces *= 0.95f;
        _rigidbody.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision col)
    {
        Vector3 pushback = Vector3.zero;
        for (int i = 0; i < col.contacts.Length; i++)
        {
            pushback += col.contacts[i].normal;
        }
        pushback.Normalize();

        _outsideForces += (pushback * 5f);
    }
}
