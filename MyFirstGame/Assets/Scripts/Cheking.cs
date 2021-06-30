using UnityEngine;
using UnityEngine.SceneManagement;


public class Cheking : MonoBehaviour
{
    private float checkTime = 0f;
    private int EnemyCount = 46, Count, y, b, bk, r,iterator=0;
    private float Timing = 0f;
    private GameObject[] ReadyEnemies, Enemies;
    [SerializeField]
    private GameObject Enmy;
    [SerializeField]
    private Transform[] Poss;
    [SerializeField]
    private LeftRight leftRight;
    [SerializeField]
    private Pause ps;
    private bool hereWasPause;
    private int[] id;




    private void Awake()
    {
        EnemyCount = PlayerPrefs.GetInt("yCount") + PlayerPrefs.GetInt("bCount") + PlayerPrefs.GetInt("rCount") + PlayerPrefs.GetInt("bkCount");
        y = PlayerPrefs.GetInt("yCount");
        b = PlayerPrefs.GetInt("bCount");
        r = PlayerPrefs.GetInt("rCount");
        bk = PlayerPrefs.GetInt("bkCount");
        id = new int[EnemyCount];
        Enemies = new GameObject[EnemyCount];
        ReadyEnemies = new GameObject[EnemyCount];

        for (int i = 0; i < 46; i++)
        {
            if (Poss[i].position.y > 13 && Poss[i].position.y < 14 && b > 0)
            {
                Enemies[iterator] = Instantiate(Enmy, Poss[i].position, Quaternion.identity);
                Enemies[iterator].name = Poss[i].name;
                b--;
                Enemies[iterator].GetComponent<Renderer>().material.color = new Color(0, 0, 255);
                iterator++;
            }
          else  if (Poss[i].position.y > 14 && Poss[i].position.y < 15 && r > 0)
            {
                Debug.Log("Red");
                Enemies[iterator] = Instantiate(Enmy, Poss[i].position, Quaternion.identity);
                Enemies[iterator].name = Poss[i].name;
                r--;
                Enemies[iterator].GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                iterator++;
            }
            else  if (Poss[i].position.y > 15 && Poss[i].position.y < 16 && bk > 0)
            {
                Debug.Log("Black");
                Enemies[iterator] = Instantiate(Enmy,Poss[i].position, Quaternion.identity);
                Enemies[iterator].name = Poss[i].name;
                bk--;
                Enemies[iterator].GetComponent<Renderer>().material.color = new Color(0, 0, 0);
                iterator++;
            }
            else if (Poss[i].position.y > 10 && Poss[i].position.y < 13 && y > 0)
            {
                Enemies[iterator] = Instantiate(Enmy, Poss[i].position, Quaternion.identity);
                Enemies[iterator].name = Poss[i].name;
                y--;
                Enemies[iterator].GetComponent<Renderer>().material.color = new Color(255, 255, 0);
                iterator++;
            }
        }

    }

    private void Update()
    {

        if (ps.isPause)
        {
            for (int i = 0; i < EnemyCount; i++)
            {
                if (Enemies[i] == null)
                {
                    Enemies[i] = Enemies[EnemyCount - 1];
                    EnemyCount--;
                }
            }
            for (int i=0; i<EnemyCount; i++)
            {                           
               
                if (Enemies[i].GetComponent<EnemyScript>().enabled)
                {
                    id[i] = i;
                }
                Enemies[i].GetComponent<EnemyScript>().enabled = false;
                Enemies[i].GetComponent<LeftRight>().enabled = false;
            }
            hereWasPause = true;
        }
        if (!ps.isPause&& hereWasPause)
        {
            for(int i=0; i<EnemyCount; i++)
            {
                if (i == id[i])
                {
                    Enemies[i].GetComponent<EnemyScript>().enabled = true;
                    id[i] = -1;
                }
                Enemies[i].GetComponent<LeftRight>().enabled = true;
            }
            hereWasPause = false;


        }
        Timing += Time.deltaTime;

        if (Timing > 4f&& !leftRight.goHome)
        {

            Timing = 0f;

            ReadyEnemies[UnityEngine.Random.Range(0,Count - 1)].GetComponent<EnemyScript>().enabled = true;
            
        }

        checkTime += Time.deltaTime;

        if (checkTime > 0.5f)
        {
            checkTime = 0f;

            for(int i = 0; i < EnemyCount; i++)
            {
                if (Enemies[i] == null)
                {
                    Enemies[i] = Enemies[EnemyCount - 1];
                    EnemyCount--;
                    if (EnemyCount == 0)
                    {
                        SceneManager.LoadScene(1);
                    }
                }
            }

            Count = 0;
            //Debug.Log("if");
            //Debug.Log(EnemyCount);
            for (int i = 0; i < EnemyCount; i++)
            {
                //Debug.Log("for");
                if (Enemies[i].transform.position.x > 0f)
                {
                    //Debug.Log(">");
                    if (!Physics.Raycast(Enemies[i].transform.position, Vector3.right, 4f)&& !Physics.Raycast(Enemies[i].transform.position, Vector3.up, 4f))
                    {

                        //Debug.Log("YES");
                        ReadyEnemies[Count] = Enemies[i];
                        Count++;

                    }
                    //else Debug.Log("NO");
                }
                else
                {
                    if (!Physics.Raycast(Enemies[i].transform.position, -Vector3.right, 4f)&&!Physics.Raycast(Enemies[i].transform.position, Vector3.up, 4f))
                    {

                        ReadyEnemies[Count] = Enemies[i];
                        Count++;

                    }

                    //else Debug.Log("NO");
                }

            }

        }

    }

}








