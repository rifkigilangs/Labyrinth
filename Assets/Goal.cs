using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] AudioClip winClip;
    [SerializeField] CustomEvent customEvent;

    private void OnCollisionEnter(Collision other) 
    {
        OnTriggerEnter(other.collider);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Ball"))
        {
            customEvent.OnInvoked.Invoke();
            audioManager.PlaySFX(winClip);
        }
    }
}
