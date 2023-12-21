using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateParticles : MonoBehaviour
{
    public ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {   
        if (particles != null) {
            particles.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTrigger()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the player (replace "Player" with your actual player tag or layer)
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            if (particles != null)
            {
                particles.Play();
            }
        }
    }
}
