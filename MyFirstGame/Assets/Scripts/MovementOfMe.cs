using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//скрипт МОЕГО движения
public class MovementOfMe : text
{
    [SerializeField]
    private GameObject bullet;
    public float speed = 1.3f;
    public float timeBetweenAtacks=0.5f;
    private bool hit;
    private float timing = 0f, coolDown = 0f;
    [SerializeField]
    private Text Score, HP, maxScore;



    private void Start()
    {
        //загрузка из созранения МОЕГО цвета
        if (PlayerPrefs.HasKey("myColor"))
        {
            if (PlayerPrefs.GetString("myColor") == "r")
                GetComponent<Renderer>().material.color = Color.red;
            if (PlayerPrefs.GetString("myColor") == "g")
                GetComponent<Renderer>().material.color = Color.green;
            if (PlayerPrefs.GetString("myColor") == "b")
                GetComponent<Renderer>().material.color = Color.blue;
            if (PlayerPrefs.GetString("myColor") == "p")
                GetComponent<Renderer>().material.color = Color.magenta;
            if (PlayerPrefs.GetString("myColor") == "o")
                GetComponent<Renderer>().material.color = new Color(255, 134, 0);
            if (PlayerPrefs.GetString("myColor") == "y")
                GetComponent<Renderer>().material.color = Color.yellow;
            if (PlayerPrefs.GetString("myColor") == "bk")
                GetComponent<Renderer>().material.color = Color.black;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.green;
        }

    }
    void Update()
    {

            Score.text = "Score " + score.ToString();
            HP.text = "HP " + healPoints.ToString();
            maxScore.text = "Max Score " + maxScroe.ToString();

        coolDown += Time.deltaTime;
        //МОЕ движение
        if (Input.GetKey(KeyCode.A)&&transform.position.x>-7.7)
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);           
        }
        if (Input.GetKey(KeyCode.D)&&transform.position.x<7.7f)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);            
        }
        if (Input.GetKeyDown(KeyCode.Space)&&coolDown>timeBetweenAtacks)
        {
            coolDown = 0f;
            Instantiate(bullet, transform.position, Quaternion.identity);           
        }
        ////////
        if (hit)
            //отключение хит-бокса при подании в МЕНЯ
        {
            timing += Time.deltaTime;
            GetComponent<BoxCollider>().enabled = false;
        }
        if (timing > 3f)
        {
            timing = 0f;
            GetComponent<BoxCollider>().enabled = true;
            hit = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "myBullet")
        {
            Destroy(other.gameObject);
            healPoints--;
            if (healPoints == 0)
            {
                SceneManager.LoadScene(0);
            }
            hit = true;
        }

    }
}    
