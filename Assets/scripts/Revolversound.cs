using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolversound : MonoBehaviour
{
    public AudioSource RevolverSound;
    public AudioSource ReloadSound;
    double counter = 0;
    public bool IsAvailable = true;
    public float CooldownDuration = 3.0f;

    bool shoot = false;
    bool reload = false;

    // Update is called once per frame
     void Update()
     {
         // if not available to use (still cooling down) just exit
         if (IsAvailable == false)
         {
             return;
         }
         
         // if no cooldown shoot again

         else if (Input.GetKey(KeyCode.Space))
        {
            counter = counter + 1;
            Debug.Log("shots fired");

            //play sounds
            if ( !shoot) {
                RevolverSound.Play();
                shoot = true;
              
            }
            if ( shoot ) {
                ReloadSound.Play();
                shoot = false;
            }
           


            //        playSound();
            // start the cooldown timer
            StartCoroutine(StartCooldown());
        }
         
         
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

