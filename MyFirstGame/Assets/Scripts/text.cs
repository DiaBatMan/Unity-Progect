using UnityEngine;
using UnityEngine.UI;

public class text : Stats
{
    public Text Score,HP;
    void Start()
    {
        
    }

    void Update()
    {
        Score.text = "Score "+score.ToString();
        HP.text = "HP " + healPoints.ToString();

    }
}
