﻿using System;
using System.Collections;
using System.Collections.Generic;
using Economy;
using UnityEngine;

public class Egg : MonoBehaviour, IInteractable
{

	[Header("VFX")]
	[SerializeField] private GameObject _eggLayEffect;

	[Header("SFX")]
	[SerializeField] private SfxReference _eggLaySound;

	public void Hatch(float time)
	{
		StartCoroutine(HatchRoutine(time));
	}
	
	private IEnumerator HatchRoutine(float time)
	{
		float mult = 1f / time;
		for (float delta = 0; delta < 1; delta += time * Time.deltaTime)
		{
			transform.localScale = Vector3.one * delta;
			yield return null;
		}
		transform.localScale = Vector3.one;
	}
	
	public void Interact()
	{
		EconomyManager.Instance.AddEggs(1);
		Instantiate(_eggLayEffect, transform.position, Quaternion.identity);
		_eggLaySound.Play();
		Destroy(gameObject);
	}
}
