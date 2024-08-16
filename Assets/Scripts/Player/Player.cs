using UnityEngine;
using UnityEngine.Events;
using LootLocker.Requests;
using System.Collections;

public class Player : MonoBehaviour
{
    public static Player instance;
    public static UnityAction OnNewCoin;
    [SerializeField] private int _coin;
    [SerializeField] private TypeGame _typeGame;
    [SerializeField] private LeaderBoard _board;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(LootLockerSetup());
    }
    #region Lootlocket
    private IEnumerator LootLockerSetup()
    {
        yield return LoginPlayer();
        yield return _board.GetLeaderBoard();
    }
    IEnumerator LoginPlayer()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((responce) =>
        {
            if (responce.success)
            {
                Debug.Log($"Мы ввошли в игру: {responce.player_id}");
                PlayerPrefs.SetString("PlayerID", responce.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log($"Мы не смогли ввойти в игру {responce.errorData}");

                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    public void SetNewNamePlayer(string name)
    {
        LootLockerSDKManager.SetPlayerName(name,(responce) =>
        {
            if (responce.success)
            {
                Debug.Log("Смена ника");
            }
            else { Debug.Log("ОШибка смены ника"); }
        });
    }
    #endregion
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
