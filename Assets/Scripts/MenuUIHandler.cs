using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
   public InputField playerName;
   public Text BestScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        BestScoreText.text = $"Best Score : {GameManager.Instance.bestPlayerName} : {GameManager.Instance.bestPlayerScore}";
        
        GameManager.Instance.LoadPlayerData();
        SetLastPlayerName(GameManager.Instance.lastPlayerName); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        GetInputName();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
     public void SetLastPlayerName(string name)
    {
      if(name == null || name == "")
      {
        return;
      }
      
      playerName.text = name;
    }

    public void GetInputName()
    {
      GameManager.Instance.lastPlayerName = playerName.text;
      GameManager.Instance.SavePlayerData();
    }
}
