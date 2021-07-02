using UnityEngine;

//скрипт текста очков
public class text : MonoBehaviour
{
    public static int healPoints, score, maxScroe;


    private void Start()
    {
        maxScroe = PlayerPrefs.GetInt("maxScore");
    }

 
   public void Begin()
    {
        score = 0;
        healPoints = 3;
    }
}
