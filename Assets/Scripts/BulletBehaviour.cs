using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public Vector3 direction = new Vector3(1, 0, 0);
    public float speed = 1;
    public float lifeTime = 3;
    public float damage = 1;
    private GameObject sender;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, 0);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            if (sender == null || collision.gameObject != sender)
                collision.gameObject.GetComponent<AEntity>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    public void setSender(GameObject go)
    {
        sender = go;
    }
}
