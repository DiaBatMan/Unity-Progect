using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
 public void ChangeScene (int id)
    {
        SceneManager.LoadScene(id);
    }
}
