using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnscaledTimeParticle : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
            GetComponent<ParticleSystem>().Simulate(Time.unscaledDeltaTime, true, false);
        
    }
}
