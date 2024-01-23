using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeFallDetector : MonoBehaviour
{

    public AudioSource soundEffectSource;
    public CubeSpawner spawner;

    void Update()
    {
        if (transform.position.y < -10)
        {
            soundEffectSource.Play();
            spawner.SpawnCube(this);
            Destroy(gameObject);
        }
    }

    
}
