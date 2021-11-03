using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject nameField;

    private string playerName;


    public void Start()
    {
        
    }

    public void SaveUserName()
    {
        playerName = nameField.GetComponent<TMP_InputField>().text;
        Debug.Log(playerName);
        GameManager.Instance.SetPlayerName(playerName);
        ChangeScene();

    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);

    }

}
