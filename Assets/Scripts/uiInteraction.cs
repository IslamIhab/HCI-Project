using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class uiInteraction : MonoBehaviour
{
    public void interact()
    {

        Button x = gameObject.GetComponent<Button>();
        x.Select();
        x.onClick.Invoke();
    }
}
