using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_EggData", menuName = "FarmScriptableObjects/Egg", order = 2)]
public class SO_EggData : ScriptableObject
{
	[SerializeField] private float _hatchTime = 1;
	[SerializeField] private float _lifeSpan = 10;
	[SerializeField] private int _eggValue = 1;
		
	public float HatchTime => _hatchTime;
	public float LifeSpan => _lifeSpan;
	public int EggValue => _eggValue;
}
