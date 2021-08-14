using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }
}
