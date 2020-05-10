using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetEffect : MonoBehaviour
{
    private ParticleSystem m_System; // The particle system that is being controlled
    // Start is called before the first frame update
    void Start()
    {
        // get the particle system ( it will be on the object as we have a require component set up
        m_System = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        ParticleSystem.MainModule mainModule = m_System.main;
    }
}
