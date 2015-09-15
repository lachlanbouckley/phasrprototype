﻿using UnityEngine;
using System.Collections;

public class PlayerHurtOnContact : MonoBehaviour
{
	public int damageToGive;
	
	
	void Start ()
	{
		
	}
	
	void Update ()
	{
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Player" && other.gameObject.layer == 11)
		{
			PlayerHealthManager.HurtPlayer(damageToGive);
			
			var player = other.GetComponent<PlayerController>();
			player.knockbackCount = player.knockbackLength;
			
			if(other.transform.position.x <= transform.position.x)
			{
				player.knockFromRight = true;
			}
			else
			{
				player.knockFromRight = false;
			}
		}
	}
}
