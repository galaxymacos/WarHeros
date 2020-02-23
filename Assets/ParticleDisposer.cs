using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDisposer : MonoBehaviour
{
    void Start()
    {
        if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).loop)
        {
            Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
    }
}
