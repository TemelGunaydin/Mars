using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCtrl : MonoBehaviour
{
    public string level_name;

    public void Game()
    {
        SceneManager.LoadScene(level_name);
    }




}
