using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PanelController : MonoBehaviour
{
    [SerializeField] private GameObject[] panelsToOpen;
    [SerializeField] private GameObject[] panelsToClose;
    private Button myButton;

    private void Awake()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(() =>
        {
            OpenPanels();
            ClosePanels();
        });
    }

    private void OpenPanels()
    {
        foreach (GameObject panel in panelsToOpen)
        {
            panel.SetActive(true);
        }
    }

    private void ClosePanels()
    {
        foreach(GameObject panel in panelsToClose)
        {
            panel.SetActive(false);
        }
    }
}
