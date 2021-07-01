using UnityEngine;
//ñêðèïò ÌÎÈÕ ïóëü
public class Bullet : text
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
            if(colider.gameObject.GetComponent<Renderer>().material.color== new Color(0, 0, 255))
                score += 2;
            if (colider.gameObject.GetComponent<Renderer>().material.color == new Color(255, 0, 0))
                score += 3;
            if (colider.gameObject.GetComponent<Renderer>().material.color == new Color(0, 0, 0))
                score += 4;
            if (colider.gameObject.GetComponent<Renderer>().material.color == new Color(255, 255, 0))
                score += 1;
            if (score > maxScroe)
            {
                PlayerPrefs.SetInt("maxScore",score);
            }
            Destroy(colider.gameObject);
            Destroy(gameObject);
        }
            
        
    }

}
