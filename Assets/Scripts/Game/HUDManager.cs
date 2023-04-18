using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _eggCountTMPText;

    public void UpdateEggCount(int newEggCount)
    {
        _eggCountTMPText.text = newEggCount.ToString();
    }
}
