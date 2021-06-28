using UnityEngine;

public class Cheking : MonoBehaviour
{
    private int Count;
    private float checkTime = 0f;
    private int EnemyCount = 46;
    private float Timing = 0f;
    [SerializeField]
    private GameObject[] ReadyEnemies;
    [SerializeField]
    private GameObject Enmy;
    [SerializeField]
    private GameObject[] Enemies;
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
        id = new int[EnemyCount];
        Enemies = new GameObject[EnemyCount];
        ReadyEnemies = new GameObject[EnemyCount];

        for (int i = 0; i < EnemyCount; i++)
        {
            Enemies[i] = Instantiate(Enmy, new Vector3(Poss[i].position.x, Poss[i].position.y, Poss[i].position.z), Quaternion.identity);
            Enemies[i].name = Poss[i].name;
            if (Enemies[i].transform.position.y > 13 && Enemies[i].transform.position.y < 14)
            {
                Enemies[i].GetComponent<Renderer>().material.color = new Color(0, 0, 255);
            }
           else if (Enemies[i].transform.position.y > 14 && Enemies[i].transform.position.y < 15)
            {
                Enemies[i].GetComponent<Renderer>().material.color = new Color(255, 0, 0);
            }
            else if (Enemies[i].transform.position.y > 15 && Enemies[i].transform.position.y < 16)
            {
                Enemies[i].GetComponent<Renderer>().material.color = new Color(0, 0, 0);
            }
            else
            {
                Enemies[i].GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            }

        }
    }
    private void Update()
    {
        if (ps.isPause)
        {       
            for(int i=0; i<EnemyCount; i++)
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








