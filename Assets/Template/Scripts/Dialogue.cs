using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "New Text", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    public string text;
    public string speaker;
    public Dialogue nextText;
}
