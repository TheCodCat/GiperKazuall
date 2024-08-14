using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void LoadScene(string name)
    {
        StartCoroutine(Loader());

        IEnumerator Loader()
        {
            SceneManager.LoadSceneAsync(name);
            yield return null;
        }
    }
}
