using UnityEngine;
using UnityEngine.SceneManagement;

//скрипт выбора врага для атаки
public class Cheking : MonoBehaviour
{
    private float checkTime = 0f, timeBetweenAttacks;
    private int EnemyCount = 46, Count, y, b, bk, r,iterator=0,ID=0;
    private float Timing = 0f;
    private GameObject[] ReadyEnemies, Enemies,lGroup,rGroup;
    [SerializeField]
    private GameObject Enmy;
    [SerializeField]
    private Transform[] Poss;
    [SerializeField]
    private LeftRight leftRight;
    [SerializeField]
    private Pause ps;
    [SerializeField]
    private text scr;
    private bool hereWasPause;
    private int[] id;

    private void Awake()
    {
        EnemyCount = PlayerPrefs.GetInt("yCount") + PlayerPrefs.GetInt("bCount") + PlayerPrefs.GetInt("rCount") + PlayerPrefs.GetInt("bkCount");
        y = PlayerPrefs.GetInt("yCount");
        b = PlayerPrefs.GetInt("bCount");
        r = PlayerPrefs.GetInt("rCount");
        bk = PlayerPrefs.GetInt("bkCount");
        scr.Begin();
        //////враги, которые нападают групами(черные и крастные)
        lGroup = new GameObject[3];
        rGroup = new GameObject[3];
        //////
        id = new int[EnemyCount];
        Enemies = new GameObject[EnemyCount];
        ReadyEnemies = new GameObject[EnemyCount];
        timeBetweenAttacks = EnemyCount / 10;
        //установка врагом по позициям из массива Poss
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
                Enemies[iterator] = Instantiate(Enmy, Poss[i].position, Quaternion.identity);
                Enemies[iterator].name = Poss[i].name;
                r--;
                Enemies[iterator].GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                iterator++;
            }
            else  if (Poss[i].position.y > 15 && Poss[i].position.y < 16 && bk > 0)
            {
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
        iterator = 0;
        for(int i=0; i < EnemyCount; i++)
        {
            if (Enemies[i].name == "39" || Enemies[i].name == "35" || Enemies[i].name == "33")
            {
                lGroup[iterator] = Enemies[i];
                iterator++;
            }
            if (Enemies[i].name == "34" || Enemies[i].name == "40" || Enemies[i].name == "38")
            {
                rGroup[ID] = Enemies[i];
                ID++;
            }
        }
        ID = -1;
        iterator = 0;
    }

    private void Update()
    {

        if (ps.isPause)//проверка паузы
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
        if (!ps.isPause&& hereWasPause)//возобновление после паузы
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

        if (Timing > timeBetweenAttacks&& !leftRight.goHome) //выбор случайного врага для атаки из массива ReadyEnemies(массива врагов, готовых к атаке)
        {
            Timing = 0f;
        retry:
            ID = UnityEngine.Random.Range(0, Count - 1);
            if (ReadyEnemies[ID].name == "39" && EnemyCount > 26 || ReadyEnemies[ID].name == "35" && EnemyCount > 26 || ReadyEnemies[ID].name == "33" && EnemyCount > 26 || ReadyEnemies[ID].name == "34" && EnemyCount > 26
                || ReadyEnemies[ID].name == "40" && EnemyCount > 26 || ReadyEnemies[ID].name == "38" && EnemyCount > 26) 
                goto retry;

            if (ReadyEnemies[ID].name == "39" || ReadyEnemies[ID].name == "35" || ReadyEnemies[ID].name == "33")
            {
               for(int i = 0; i < 3; i++)
               {
                    if (lGroup[i] != null)
                        lGroup[i].GetComponent<EnemyScript>().enabled = true;
               }
            }
            if (ReadyEnemies[ID].name=="34" || ReadyEnemies[ID].name == "40"|| ReadyEnemies[ID].name == "38")
            {
                for (int i = 0; i < 3; i++)
                {
                    if(rGroup[i]!=null)
                    rGroup[i].GetComponent<EnemyScript>().enabled = true;
                }
            }
            ReadyEnemies[ID].GetComponent<EnemyScript>().enabled = true;            
        }

        checkTime += Time.deltaTime;

        if (checkTime > 0.5f)//проверка на наличие свобдных для атаки варагов
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
                    timeBetweenAttacks = EnemyCount / 10;
                }
            }

            Count = 0;
            for (int i = 0; i < EnemyCount; i++)
            {
                if (Enemies[i].transform.position.x > 0f)
                {
                    if (!Physics.Raycast(Enemies[i].transform.position, Vector3.right, 4f)&& !Physics.Raycast(Enemies[i].transform.position, Vector3.up, 4f))
                    {

                        ReadyEnemies[Count] = Enemies[i];
                        Count++;

                    }
                }
                else
                {
                    if (!Physics.Raycast(Enemies[i].transform.position, -Vector3.right, 4f)&&!Physics.Raycast(Enemies[i].transform.position, Vector3.up, 4f))
                    {

                        ReadyEnemies[Count] = Enemies[i];
                        Count++;

                    }
                }

            }

        }

    }

}








