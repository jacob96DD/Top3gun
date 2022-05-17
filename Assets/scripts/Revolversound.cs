using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolversound : MonoBehaviour
{
    public AudioSource RevolverSound;

    public AudioSource ReloadSound;

    public AudioSource Changemag;

    int counter = 0;

    public bool IsAvailable = true;

    public float CooldownDuration = 1.0f;

    public float CooldownReload = 5.0f;

    private bool isTriggered = false;

    private Vector3 lastAcceleration;

    bool reload = false;

    public Animator fireAnim;

    public float magasin = 6;

    

    void start()
    {
        lastAcceleration = Input.acceleration;
    }

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

        } // if no cooldown and space og gravity is triggered shoot again
        else if (force > 2.1f && isTriggered == false || Input.GetKey("space") && magasin > counter)
        {
            isTriggered = true;
            counter = counter + 1;
            Debug.Log(counter);

            //play sounds
          
                RevolverSound.Play();
               
                fireAnim.SetTrigger("fireAnim");
          
                ReloadSound.Play();
       

            //        playSound();
            // start the cooldown timer
            StartCoroutine(StartCooldown());
        }

        if (counter == magasin)
            {
                Debug.Log("reload");
                Changemag.Play();
                
                StartCoroutine(StartReload());
                
            }

        if (force < 1.0f)
        {
            isTriggered = false;
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

    public IEnumerator StartReload()
    {
        IsAvailable = false;
        yield return new WaitForSeconds(CooldownReload);
        counter = 0;
        IsAvailable = true;
    }
}
