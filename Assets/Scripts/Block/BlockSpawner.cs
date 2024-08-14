using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class BlockSpawner : MonoBehaviour
{
    public static UnityAction OnSpawn;
    public static UnityAction<Block> OnRelease;
    [SerializeField] private Block _prefab;
    [SerializeField] private Vector3[] _versPosition;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private int _startCount;
    [Header("настройки для пула")]
    [SerializeField] private int _defaultCount;
    [SerializeField] private int _maxCount;

    private ObjectPool<Block> _objectPool;
    private Vector3 _newPosition;

    private void Start()
    {
        OnRelease += Replace;
        OnSpawn += Spawn;
        _objectPool = new ObjectPool<Block>(CreateBlock, EnableBlock, DisableBlock, DestroyBlock,false, _defaultCount,_maxCount);
        _newPosition = _startPosition.position;

        for (int i = 0; i < _startCount; i++)
        {
            Spawn();
        }
    }
    private void Spawn()
    {
        Block _myBlock = _objectPool.Get();
        _myBlock.transform.position = _newPosition;

        int _indexR = Random.Range(0, _versPosition.Length);
        _newPosition += _versPosition[_indexR];
    }

    private void Replace(Block block)
    {
        _objectPool.Release(block);
    }

    #region Pool
    private Block CreateBlock()
    {
        return Instantiate(_prefab, _startPosition);
    }
    private void EnableBlock(Block block)
    {
        block.gameObject.SetActive(true);
    }
    private void DisableBlock(Block block)
    {
        block.gameObject.SetActive(false);
    }
    private void DestroyBlock(Block block)
    {
        Destroy(block.gameObject);
    }
    #endregion
}
