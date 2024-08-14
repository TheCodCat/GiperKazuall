using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestView : MonoBehaviour
{
    [SerializeField] private Text _bestText;

    private void OnEnable()
    {
        _bestText.text = $"BEST SCORE:{BestCoin.GetBestCoin()}";
    }
}
