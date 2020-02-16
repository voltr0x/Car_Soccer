using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VARSensor : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Instantiate(explosionParticle, other.transform.position, explosionParticle.transform.rotation);
            explosionParticle.Play();
            Destroy(other.gameObject);

            gameManager.UpdateGoals(1);
            gameManager.Respawn();
        }
    }
}
