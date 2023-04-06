using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchGroundPlane : MonoBehaviour
{
    private void Update()
    {
        GameManager.SetGroundPlane(transform.position, transform.rotation);
    }
}
