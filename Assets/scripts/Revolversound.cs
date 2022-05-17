using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolversound : MonoBehaviour
{
    public AudioSource RevolverSound;
    public AudioSource ReloadSound;
    double counter = 0;
    public bool IsAvailable = true;
    public float CooldownDuration = 1.0f;


    private Vector3 lastAcceleration;


    bool shoot = false;
    bool reload = false;

<<<<<<< HEAD
    public Animator fireAnim;
=======
    void start()
    {
        lastAcceleration = Input.acceleration;

    }
>>>>>>> main

    // Update is called once per frame
     void Update()
     {
        // g kraften fra før til nu er == accelerationen
         Vector3 currentAcceleration = Input.acceleration;
         Vector3 deltaAcceleration = lastAcceleration;
         lastAcceleration = currentAcceleration;

         float force = deltaAcceleration.magnitude; 

         // if not available to use (still cooling down) just exit
         if (IsAvailable == false)
         {
             return;
         }
         
         // if no cooldown shoot again
<<<<<<< HEAD
         else if (Input.GetKey(KeyCode.Space))
=======

         else if (Input.GetKey(KeyCode.Space) || force > 1.0f)
>>>>>>> main
        {


            counter = counter + 1;
            Debug.Log("shots fired");

            //play sounds
            if ( !shoot) {
                RevolverSound.Play();
                shoot = true;
                fireAnim.SetTrigger("fireAnim");
              
            }
            if ( shoot ) {
                ReloadSound.Play();
                shoot = false;
            }
           


            //        playSound();
            // start the cooldown timer
            StartCoroutine(StartCooldown());
        }
         
    //accelerator
        
         
     }

      //  public IEnumerator playSound()
    //      {
    //          audio.clip = RevolverSound;
    //          RevolverSound.Play();
    //          yield return new WaitForSeconds(audio.clip.length);
    //          ReloadSound.Play();
    //      }
     
     public IEnumerator StartCooldown()
     {
         IsAvailable = false;
         yield return new WaitForSeconds(CooldownDuration);
         IsAvailable = true;
     }



}

