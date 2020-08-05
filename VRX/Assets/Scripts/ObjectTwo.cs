﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectTwo : MonoBehaviour, IInteractable
{
    #region Properties

    [SerializeField] public string ObjectName;
    [SerializeField] public GameObject InteractMenu;

    public List<GameObject> InteractMenuOptionButtons;
    public GameObject ButtonPreFab;

    #endregion

    #region Start

    void Start()
    {
        GameObject objectOneButton = Instantiate(ButtonPreFab);
        objectOneButton.transform.GetChild(0).GetComponent<Text>().text = "Click Object Two";
        InteractMenuOptionButtons.Add(objectOneButton);

        GameObject objectOneButtonTwo = Instantiate(ButtonPreFab);
        objectOneButtonTwo.transform.GetChild(0).GetComponent<Text>().text = "Click Object Two Two";
        InteractMenuOptionButtons.Add(objectOneButtonTwo);

        GameObject exitButton = Instantiate(ButtonPreFab);
        exitButton.transform.GetChild(0).GetComponent<Text>().text = "Exit";
        exitButton.GetComponent<Button>().onClick.AddListener(OnExitButtonClick);
        InteractMenuOptionButtons.Add(exitButton);

        foreach (GameObject button in InteractMenuOptionButtons)
        {
            button.transform.SetParent(InteractMenu.transform);
        }
    }

    #endregion

    #region On Hover

    public HoverOutput Hover()
    {
        return new HoverOutput
        {
            ObjectName = ObjectName
        };
    }

    #endregion

    #region On Interact

    public InteractionOutput Interact()
    {
        InteractMenu.SetActive(true);

        foreach (GameObject button in InteractMenuOptionButtons)
        {
            button.SetActive(true);
        }

        InteractMenuOptionButtons[0].GetComponent<Button>().Select();

        return new InteractionOutput
        {
            ObjectName = ObjectName,
        };
    }

    #endregion

    #region On Button Click

    void OnExitButtonClick()
    {
        foreach (GameObject button in InteractMenuOptionButtons)
        {
            button.SetActive(false);
        }

        InteractMenu.SetActive(false);
    }

    #endregion
}
