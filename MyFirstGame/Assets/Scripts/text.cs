using UnityEngine;
using UnityEngine.UI;
//скрипт текста очков
public class text : MonoBehaviour
{
    public static int healPoints, score, maxScroe;
    public Text Score,HP,maxScore;

    private void Start()
    {
        maxScroe = PlayerPrefs.GetInt("maxScore");
    }

    void Update()
    {
        Score.text = "Score "+score.ToString();
        HP.text = "HP " + healPoints.ToString();
        maxScore.text = "Max Score " + maxScroe.ToString();
    }
   public void Begin()
    {
        score = 0;
        healPoints = 3;
    }
}
