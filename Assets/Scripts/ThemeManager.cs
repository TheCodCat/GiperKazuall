using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThemeManager : MonoBehaviour
{
    public static ThemeManager Instance;
    [SerializeField] private BDTheme _BDTheme;
    [SerializeField] private MeshRenderer _playerMat;
    [SerializeField] private Camera _camera;

    private void Awake()
    {
        Instance = this;
    }

    public void SetNewTheme(int index)
    {
        _playerMat.material.color = _BDTheme.Themes[index].PlayerColor;
        _camera.backgroundColor = _BDTheme.Themes[index].BGColor;
    }
}
