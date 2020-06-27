using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gui_Controller : MonoBehaviour
{

    public GameObject ballPrefabs;
    public InputField passwordField;
    public Text errorText;



    private Dictionary<string, int> passwordsLevel = new Dictionary<string, int>();
    private static int balls = 0;

    private void Start()
    {
        passwordsLevel.Add("Ax56gt789Ux", 1);
        passwordsLevel.Add("Gv78ik903Hc", 2);

        passwordField.onEndEdit.AddListener(delegate { EnterPasswordLevel(); });

        
    }

    public void SpawnBall()
    {
        if(balls < 5)
        {
            Instantiate(ballPrefabs);
            balls++;

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("UI");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void EnterPasswordLevel()
    {
        string password = passwordField.text;

        if (passwordsLevel.ContainsKey(password))
        {
            SceneManager.LoadScene(passwordsLevel[password]);
        }
        else
        {
            errorText.GetComponent<Text>().enabled = true;
        }
    } 
    
}
