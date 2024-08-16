using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderItem : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private Text _score;
    [SerializeField] private Image _image;
    [SerializeField] private Color _selectColor;

    public void SetupLeader(string name,string score)
    {
        _name.text = name;
        _score.text = score;
    }
    public void MySelect()
    {
        _image.color = _selectColor;
    }
}
