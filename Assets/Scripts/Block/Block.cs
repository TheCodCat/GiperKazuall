using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public void Release()
    {
        BlockSpawner.OnSpawn?.Invoke();
        BlockSpawner.OnRelease?.Invoke(this);
    }
}
