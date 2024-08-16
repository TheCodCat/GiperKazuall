using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class LeaderBoard : MonoBehaviour
{
    private const int _leaderBoardID = 24128;
    [SerializeField] private Transform _parent;
    [SerializeField] private LeaderItem _leaderItem;

    public IEnumerator GetLeaderBoard()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreList(_leaderBoardID.ToString(),5,(responce) =>
        {
            if (responce.success)
            {
                Debug.Log("Таблица есть");
                LootLockerLeaderboardMember[] items = responce.items;
                for (int i = 0; i < items.Length; i++)
                {
                    LeaderItem _myItem = Instantiate(_leaderItem,_parent);
                    string name;
                    if (items[i].player.name == "")
                    {
                        name = items[i].player.id.ToString();
                    }
                    else name = items[i].player.name;
                    _myItem.SetupLeader($"{items[i].rank}.{name}", items[i].score.ToString());
                    if(items[i].player.id.ToString() == PlayerPrefs.GetString("PlayerID"))
                    {
                        _myItem.MySelect();
                    }
                }
            }
        });
        yield return new WaitWhile(()=> done == false);
    }
    public IEnumerator SetScoreLeaderBoard(int Score)
    {
        bool done = false;
        string _playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(_playerID,Score,_leaderBoardID.ToString(),(responce) =>
        {
            if (responce.success)
            {
                Debug.Log("Счет обнавлен");
                done = true;
            }
            else
            {
                Debug.Log("Счет не обнавлен");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}
