using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;

// Modifies a text thorough a Atom Tester
public class UIIntToTextAtomModifier : MonoBehaviour
{
    [SerializeField] private IntReference stringAtom;
    [SerializeField] private TextMeshProUGUI textDisplay;

    private void Update()
    {
        textDisplay.text = stringAtom.Value.ToString();
    }
}
