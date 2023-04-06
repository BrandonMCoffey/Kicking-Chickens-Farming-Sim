using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private Transform _groundPlane;

    public static void SetGroundPlane(Vector3 pos, Quaternion rot) => Instance._groundPlane.SetPositionAndRotation(pos, rot);

    private void Awake()
    {
        Instance = this;
    }
}
