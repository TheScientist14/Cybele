using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Text", menuName = "Text")]
public class Text : ScriptableObject
{
    public string text;
    public GameObject speaker;
    public Text nextText;
}
