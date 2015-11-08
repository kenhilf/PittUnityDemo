using UnityEngine;
using System.Collections;

public class AstroidManager : MonoBehaviour
{
	public GameObject AstroidPrefab;
    public float TimeToSpawn = 1f;
    private float _elapsedTime = 0f;

	void Start()
	{
	    
	}
	
	void Update()
	{
		_elapsedTime += Time.deltaTime;
		if (_elapsedTime > TimeToSpawn)
		{
			Vector3 spawnPos = new Vector3(Random.Range(-7.5f, 7.5f),
			                               1.53f,
			                               Random.Range(-4f, 4f));

			Instantiate(AstroidPrefab, spawnPos, Quaternion.identity);

			_elapsedTime -= TimeToSpawn;
		}
	}
}
