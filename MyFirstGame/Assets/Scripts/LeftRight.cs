using UnityEngine;
//Скрипт движения влево и вправо
public class LeftRight : MonoBehaviour
{   
    public float speed = 0.5f;
    private bool switcher=true;
    public bool goHome=false;
    private float Right,Left;
    private float x, y,Y;
    public EnemyScript enemyScript;


    private void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        Right = x + 1.5f;
        Left = x - 1.5f;
    }
    void Update()
    {
        //сдвиг по координате x
        if (x < Right && switcher)
                x += speed;

            if (x > Right)
                switcher = false;

            if (x > Left && !switcher)
                x -= speed;

            if (x < Left)
                switcher = true;

            if (!GetComponent<EnemyScript>().enabled && !goHome)//перемещение на эту координату
        {
                transform.position = new Vector3(x, y, -9);
            }
            if (transform.position.y < 6)//проверка на то,что враг пропал из воля видимости и возвращение его на свою точку
        {
                enemyScript.secondTiming = 0f;
                enemyScript.Timing = 0f;
                enemyScript.first = true;
                enemyScript.readyToFire = false;
                GetComponent<EnemyScript>().enabled = false;
                goHome = true;

                GetComponent<Rigidbody>().velocity = Vector3.zero;

                transform.position = new Vector3(x, 20, -9);
                Y = 20;

            }

            if (goHome)//возвращение врага на точку
        {

                transform.LookAt(new Vector3(x, y, -9));
                Y -= 0.01f;
                transform.position = new Vector3(x, Y, -9);


                if (Y >= y - 0.1 && Y <= y + 0.1)
                {
                    transform.position = new Vector3(x, y, -9);
                    transform.LookAt(new Vector3(transform.position.x, -10, transform.position.z));
                    goHome = false;
                }


            }
        
    }
        
}
