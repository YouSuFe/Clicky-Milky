using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionParticals;

    public int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(),ForceMode.Impulse);

        transform.position = RandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(12, 16);
    }

    float RandomTorque()
    {
        return Random.Range(-10, 10);
    }

    Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-4, 4), -2);
    }
    /*
    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
            Instantiate(explosionParticals, transform.position, explosionParticals.transform.rotation);
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }

    }
    */
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad") && gameManager.isGameActive)
        {
            gameManager.LiveUpdate(-1);
        }
    }

    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Instantiate(explosionParticals, transform.position, explosionParticals.transform.rotation);
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }
    }
}
