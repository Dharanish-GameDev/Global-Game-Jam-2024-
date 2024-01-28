using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition
{
    public Condition(bool value, string name)
    {
        this.value = value;
        this.name = name;
    }
    public bool value;
    public string name;
}
