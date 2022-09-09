using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public string name;

    public bool[] piezas;

    public Vector3 position;
    public Player(string name)
    {
        this.name = name;
        piezas = new bool[5];
    }
}
