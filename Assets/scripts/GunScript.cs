using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
public AudioSource GunSound;
public AudioSource ReloadSound;
public AudioSource Changemag;
private Vector3 lastAcceleration;
public Animator fireAnim;

public bool IsAvailable = true;
public float CooldownDuration = 1.0f;
public float CooldownReload = 5.0f;
public int magasin;
private int initialMag;
public GameObject bullet;
private GameObject[] bullets;
    
    void Awake(){
       initialMag = magasin;
       InitBullets();
    }
    
   

   
    void Update(){
     
        Vector3 currentAcceleration = Input.acceleration;
     

        float force = currentAcceleration.magnitude;

     
            if (IsAvailable == false){
                return;
            } else if (force > 2.1f || Input.GetKey("space")){
            Shoot();
            RemoveBullet();
            }

            foreach(Touch touch in Input.touches){
            if (touch.phase == TouchPhase.Began){
              Shoot();
              RemoveBullet();
             }
            }
            
          
    }


    private IEnumerator StartCooldown(float Cooldown)
    {
        IsAvailable = false;
        yield return new WaitForSeconds(Cooldown);
        IsAvailable = true;
    }

 

    public void RemoveBullet(){
        
        Destroy(bullets[magasin]);
        
    }

    private void InitBullets(){
       bullets = new GameObject[magasin];
       for(int i = 0; i < bullets.Length; i++){
        bullets[i] = Instantiate(bullet, new Vector3(10 - i, -4, 1), Quaternion.identity);
         
        }
    }

    private void Shoot()
    {
        if(magasin > 0){
         magasin = magasin - 1;
        
            GunSound.Play();
            fireAnim.SetTrigger("fireAnim");
            ReloadSound.Play();
            StartCoroutine(StartCooldown(CooldownDuration));
               
        }else if (magasin == 0)
            {
                Changemag.Play();
                StartCoroutine(StartCooldown(CooldownReload));
                magasin = initialMag;
                InitBullets();
            }    
    }
}

