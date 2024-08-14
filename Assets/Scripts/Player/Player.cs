using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static Player instance;
    public static UnityAction OnNewCoin;
    [SerializeField] private int _coin;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Debug.Log(BestCoin.GetBestCoin());
    }

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
