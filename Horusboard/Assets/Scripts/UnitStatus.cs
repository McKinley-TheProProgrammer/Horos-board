using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

[CreateAssetMenu(menuName = "Unit Status")]
public class UnitStatus : ScriptableObject
{
    public string statusName = "Unit name";
    public IntReference maxHP;
    
    public int damage = 5;
    public float defense = 20;
}
