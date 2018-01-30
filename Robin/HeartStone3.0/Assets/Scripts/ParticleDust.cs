using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDust : MonoBehaviour
{

    public ParticleSystem particle;

    public void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "floor")
        {
            particle.gameObject.GetComponent<ParticleSystem>().Play();
        }
    }

}
