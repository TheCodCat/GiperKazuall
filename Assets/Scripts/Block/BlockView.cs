using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockView : MonoBehaviour
{
    [SerializeField] private Block _parent;
    [SerializeField] private Animator _animator;
    public void Release()
    {
        BlockSpawner.OnRelease?.Invoke(_parent);
    }
    public void ResetState()
    {
        _animator.SetTrigger("Reset");
    }
}
