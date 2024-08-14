using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New BD Theme")]
public class BDTheme: ScriptableObject
{
    [SerializeField] private List<Theme> _themes = new List<Theme>();

    public List<Theme> Themes => _themes;
}

[System.Serializable]
public class Theme
{
    public Color PlayerColor;
    public Color BGColor;
}