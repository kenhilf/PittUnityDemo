using UnityEngine;
using System.Collections;

public class Astroid : MonoBehaviour
{
	public GameObject ExplosionPrefab;

	void Start()
	{
	    
	}
	
	void Update()
	{
	    
	}

	public void OnCollisionEnter(Collision col)
	{
		GameObject destroyFX = (GameObject)Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(destroyFX, 3f);
		Destroy(gameObject);
	}
}
