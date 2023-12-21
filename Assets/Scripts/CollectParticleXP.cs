using System.Collections.Generic;
using UnityEngine;

public class CollectParticleXP : MonoBehaviour
{
    ParticleSystem ps;
    List<ParticleSystem.Particle> particles;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        particles = new List<ParticleSystem.Particle>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update logic, if needed
    }

    private void OnParticleTrigger()
    {
        SoundEffects.AudioManager.particlesMusic();

        int triggeredParticles = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, particles);
        for (int i = 0; i < triggeredParticles; i++)
        {
            ParticleSystem.Particle p = particles[i];
            p.remainingLifetime = 0;
            particles[i] = p;
        }
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, particles);
    }
}
