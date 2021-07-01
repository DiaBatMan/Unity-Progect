using UnityEngine;
using UnityEngine.SceneManagement;
//скрипт вражеских пуль
public class EnemyBullet : text
{
    public float bulletSpeed = 2f;
    [SerializeField]
    private GameObject enemyBullet;
    private GameObject Me;
    private void  Start()
    {
        Me = GameObject.Find("ME"); ;
        transform.LookAt(Me.transform);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        if (transform.position.y < 2)
        {
            Destroy(enemyBullet);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ME")
        {
            Destroy(enemyBullet);
            healPoints--;
            if (healPoints == 0)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}