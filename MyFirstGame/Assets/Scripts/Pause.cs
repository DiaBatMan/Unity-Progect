using UnityEngine;
using UnityEngine.SceneManagement;
//скрипт паузы

public class Pause : MonoBehaviour
{
    [HideInInspector]
    public bool isPause;
    public GameObject pause;


    void Start()
    {
        pause.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0;
            isPause = true;
        }
    }
    public void PauseOff()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
        isPause = false;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
