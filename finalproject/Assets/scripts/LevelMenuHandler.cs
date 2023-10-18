using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuHandler : MonoBehaviour
{
  public void Level1(){
        SceneManager.LoadScene("Level1");
    }
    public void MainMenu(){
        SceneManager.LoadScene("title");
    }
    public void level2(){
        SceneManager.LoadScene("");
    }
    public void level3(){
        SceneManager.LoadScene("");
    }
}
