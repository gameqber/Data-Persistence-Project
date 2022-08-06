using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public static string playerName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartNew()
    {
        
        SceneManager.LoadScene(1);
    }

    public void SetPlayerName(string s)
    {
        ScoreManager.Instance.playerName = s;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
