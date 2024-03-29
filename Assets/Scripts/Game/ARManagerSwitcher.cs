﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Management;

public class ARManagerSwitcher : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _arFoundation;
	[SerializeField] private GameObject _desktop;
	
	public static Action OnArInitialized = delegate { };

    private void Awake()
    {
        _arFoundation.gameObject.SetActive(false);
        _desktop.gameObject.SetActive(false);
    }

    private void Start()
    {
#if UNITY_EDITOR
        StartDesktopAr();
#else
        StartCoroutine(StartAr());
#endif
    }

    private IEnumerator StartAr()
    {
        _arFoundation.gameObject.SetActive(true);
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();
        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed. Switching to Default Mode.");
            _arFoundation.gameObject.SetActive(false);
            StartDesktopAr();
        }
        else
        {
            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.StartSubsystems();
	        yield return null;
	        OnArInitialized?.Invoke();
        }
    }

    private void StartDesktopAr()
	{
		_desktop.gameObject.SetActive(true);
	    OnArInitialized?.Invoke();
    }
}
