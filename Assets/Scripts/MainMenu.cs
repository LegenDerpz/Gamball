using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadScene("Gamball");
    }

    public void Exit(){
        Application.Quit();
    }
}
