using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public Animator fireAnim;

    public float magasin = 6;

    public TextMeshProUGUI roundsLeft;
    
    private float Rounds = 0;

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
        else if (force > 2.1f && isTriggered == false || Input.GetKey("space"))
        {
           Shoot();
           
        }

        if (counter == magasin)
            {
                Debug.Log("reload");
                Changemag.Play();
                roundsLeft.text = "Reloading: " + Rounds.ToString();
                
                StartCoroutine(StartReload());
                
            }

            foreach(Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Stationary && magasin > counter)
                 

            {

                Shoot();
            }}
        if (force < 1.0f)
        {
            isTriggered = false;
        }

    }

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
        roundsLeft.text = "bullets left: " + magasin.ToString();
    }

    public void Shoot()
    {
        if(magasin -1 > counter){
        
        isTriggered = true;
        counter = counter + 1;
        Debug.Log(counter);

        Rounds = magasin;
        Rounds -= counter;
                        
        Debug.Log(Rounds);
        roundsLeft.text = "bullets left: " + Rounds.ToString();
       
                RevolverSound.Play();
               
                fireAnim.SetTrigger("fireAnim");
          
                ReloadSound.Play();


            StartCoroutine(StartCooldown());
        }

        else if(magasin -1 == counter){
        
        isTriggered = true;
        counter = counter + 1;
        Debug.Log(counter);

        Rounds = magasin;
        Rounds -= counter;
        roundsLeft.text = "bullets left: " + Rounds.ToString();

            //play sounds
          
                RevolverSound.Play();
               
                fireAnim.SetTrigger("fireAnim");
    
       

        
        }
    }
}
