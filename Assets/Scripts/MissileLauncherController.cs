using UnityEngine;
using System.Collections;

public class MissileLauncherController : MonoBehaviour
{
	public Transform firePoint;
	public GameObject missile;

	void Start ()
	{
		
	}
	
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.C))
		{
			Instantiate(missile, firePoint.position, transform.rotation);
		}
		
		/*
		if(Input.GetKey(KeyCode.C))
		{
			shotDelayCounter -= Time.deltaTime;
			
			if(shotDelayCounter <= 0)
			{
				shotDelayCounter = shotDelay;
				Instantiate(missile, firePoint.position, firePoint.rotation);
			}
		}
		*/
	}
}
