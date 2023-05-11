using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwitchButton : MonoBehaviour
{
    [SerializeField] private string character;
    private Sonic sonic;
    private Jumper jumper;
    private Feesh feesh;
    private Button button;
    private void Awake()
    {
        sonic = GameObject.FindWithTag("Sonic").GetComponent<Sonic>();
        jumper = GameObject.FindWithTag("Jumper").GetComponent<Jumper>();
        feesh = GameObject.FindWithTag("Feesh").GetComponent<Feesh>();
        button = GetComponent<Button>();
        button.onClick.AddListener(ActivateCharacter);
    }

    private void ActivateCharacter()
    {
        sonic.IsActive = sonic.CompareTag(character);
        jumper.IsActive = jumper.CompareTag(character);
        feesh.IsActive = feesh.CompareTag(character);
    }

    private void Update()
    {
        button.interactable = character switch
        {
            "Sonic" => !sonic.IsActive,
            "Jumper" => !jumper.IsActive,
            "Feesh" => !feesh.IsActive,
            _ => throw new ArgumentOutOfRangeException("Incorrect character name")
        };
        button.interactable = !sonic.IsMoving;
    }
}
