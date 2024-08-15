using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static Player instance;
    public static UnityAction OnNewCoin;
    [SerializeField] private int _coin;
    [SerializeField] private TypeGame _typeGame;
    private void Awake()
    {
        instance = this;
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

    public void MenuToGame()
    {
        _typeGame = TypeGame.Game;
    }

    public TypeGame GetTypeGame()
    {
        return _typeGame;
    }

}
public enum TypeGame
{
    Pause,Game
}
