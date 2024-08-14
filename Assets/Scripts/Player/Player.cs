using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static Player instance;
    public static UnityAction OnNewCoin;
    [SerializeField] private int _coin;
    [SerializeField] private MeshRenderer _meshRenderer;

    public void AddCoin()
    {
        _coin++;
        OnNewCoin?.Invoke();
    }

    public int GetCoin()
    {
        return _coin;
    }

}
