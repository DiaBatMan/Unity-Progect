using UnityEngine;


public class Bullet : Stats
{
    public float BulledSpeed=1.5f;

    void Update()
    {
        transform.Translate(Vector3.up * BulledSpeed * Time.deltaTime);
       
        if (transform.position.y > 18 )
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider colider)
    {
        if (colider.gameObject.name != "ME")
        {
            Destroy(colider.gameObject);
            Destroy(gameObject);
            score++;
        }
            
        
    }

}
