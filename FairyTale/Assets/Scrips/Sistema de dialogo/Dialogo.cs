using UnityEngine;

[System.Serializable]
public class Dialogo
{
    public string name;
    [TextArea(3, 25)]
    public string[] sentences;
}
