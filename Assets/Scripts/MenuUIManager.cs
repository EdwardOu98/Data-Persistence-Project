using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIManager : MonoBehaviour
{
    [SerializeField] Text highScoreText;

    [SerializeField] InputField usernameEntry;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "Best Score: " + ScoreManager.Instance.recordKeeper + ": " + ScoreManager.Instance.highScore.ToString();
        usernameEntry.text = ScoreManager.Instance.recordKeeper;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonClicked()
    {
        ScoreManager.Instance.SetUsername(usernameEntry.text);
        SceneManager.LoadScene(1);
    }

    public void ExitButtonClicked()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
