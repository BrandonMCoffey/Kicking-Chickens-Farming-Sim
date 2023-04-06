using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;

public class ARManagerSwitcher : MonoBehaviour
{
    [SerializeField] private bool _vuforiaWebcamTesting;
    
    [Header("References")]
    [SerializeField] private GameObject _arFoundation;
    [SerializeField] private GameObject _arVuforia;
    [SerializeField] private GameObject _desktop;

    private void Awake()
    {
        _arFoundation.gameObject.SetActive(false);
        _arVuforia.gameObject.SetActive(false);
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
        }
    }

    private void StartDesktopAr()
    {
        if (_vuforiaWebcamTesting)
        {
            _arVuforia.gameObject.SetActive(true);
        }
        else
        {
            _desktop.gameObject.SetActive(true);
        }
    }
}
