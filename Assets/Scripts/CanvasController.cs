using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DarkRift.Client.Unity;
using System;
using UnityEngine.XR.Management;

public class CanvasController : MonoBehaviour
{
    public ChatDemo chatDemo;

    public Canvas ConnectionCanvas;
    public Canvas PlayerSelectCanvas;
    public Canvas ControllerCanvas;
    public Canvas PlayerCanvas;

    public TMP_InputField host;
    public TMP_InputField port;
    public UnityClient Network;

    public void Awake()
    {
        ConnectionCanvas.enabled = true;
        PlayerSelectCanvas.enabled = false;
        ControllerCanvas.enabled = false;
        PlayerCanvas.enabled = false;
    }

    public void OnConnectClick()
    {
        int.TryParse(port.text, out int PortNumber);
        Debug.Log("Connecting to " + host.text + ":" + port.text);
        try
        {
            Network.Connect(host.text, PortNumber, false);
        }
        catch(Exception e)
        {
            Debug.Log(e);
            host.Select();
            host.text = "";
        }

        if (Network.ConnectionState == DarkRift.ConnectionState.Connected)
        {
            ConnectionCanvas.enabled = false;
            PlayerSelectCanvas.enabled = true;
        }
    }

    public void OnControllerClick()
    {
        PlayerSelectCanvas.enabled = false;
        ControllerCanvas.enabled = true;
    }

    public void OnViwerClick()
    {
        PlayerSelectCanvas.enabled = false;
        StartCoroutine(VRStart());
    }
    public void OnPlayerClick()
    {
        PlayerSelectCanvas.enabled = false;
        PlayerCanvas.enabled = true;
        StartCoroutine(VRStart());
    }

    public void OnControllerTap()
    {
        chatDemo.MessageEntered("x");
    }

    public IEnumerator VRStart()
    {
        var xrManager = XRGeneralSettings.Instance.Manager;
        if (!xrManager.isInitializationComplete)
        {
            yield return xrManager.InitializeLoader();
            xrManager.StartSubsystems();
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

        }

    }
}
