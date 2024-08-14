using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private Player _player;
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Block block))
        {
            BlockSpawner.OnRelease?.Invoke(block);
            BlockSpawner.OnSpawn?.Invoke();
            _player.AddCoin();
        }
    }
}
