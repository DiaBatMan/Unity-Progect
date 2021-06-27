using UnityEngine;

public class MovementOfMe : MonoBehaviour
{
    public GameObject bullet;
    public float speed = 1.3f;
    private bool hit;
    private float timing = 0f;
    

    private void Start()
    {
        GetComponent<Renderer>().material.color = new Color(0,255,0);
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);           
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);           
        }
        if (hit)
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
        hit = true;
    }
}    
