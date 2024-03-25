using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public struct Members
{
    public string name;
    public int year;
    public string color;

    public Members(string name, int year, string color)
    {
        this.name = name;
        this.year = year;  
        this.color = color;
    }

    [Serializable]
    public class MemberList 
    { 
        public List<Members> list; 
    }
}
