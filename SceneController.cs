using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadSceneName(string screneName)
    {
        SceneManager.LoadScene(screneName);
    }
}
