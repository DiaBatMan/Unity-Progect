using UnityEngine;
//скрипт движения врага
public class EnemyScript : MonoBehaviour
{
    public float bulletSpeed=20f;
    public float timeBeetwenAtacks=0.2f;
    [SerializeField]
    private GameObject bullet;
    public float Timing = 0f, Force = 1f, secondForce = 1.3f,secondTiming=0f;
    private GameObject movementOfMe;
    [HideInInspector]
    public bool readyToFire=false,first=true,second=false,stop=false;
    private float y;

    private void Start()
    {
        Timing = 0f;
        movementOfMe = GameObject.Find("ME");
        y = transform.position.y;
    }

    private void FixedUpdate()
    {

            Timing += Time.fixedDeltaTime;
            if (Timing < y / 10)
            {
            //движение оп направление х
                 if (transform.position.x > 0f)
                {
                    transform.LookAt(new Vector3(10, transform.position.y, transform.position.z));
                    GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Force);
                }
                else
                {
                    transform.LookAt(new Vector3(-10, transform.position.y, transform.position.z));
                    GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Force);
                }
            stop = true;
            }
            else
            {
            //движение в направлении МЕНЯ
            if (stop)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                stop = false;
            }
            transform.LookAt(new Vector3(movementOfMe.transform.position.x, movementOfMe.transform.position.y, movementOfMe.transform.position.z));
                GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * secondForce);

                if (transform.position.y < 10f)
                {
                    readyToFire = true;
                    secondTiming += Time.fixedDeltaTime;
                }

            }
            if (readyToFire)
            {
            //стрельба по МНЕ
            if (first)
                {
                    Instantiate(bullet, transform.position, Quaternion.identity);
                    first = false;
                    second = true;
                }


                if (secondTiming > timeBeetwenAtacks && second)
                {
                    Instantiate(bullet, transform.position, Quaternion.identity);
                    readyToFire = false;
                    second = false;
                    secondTiming = 0f;
                }

            }

        
    }

}
