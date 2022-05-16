using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource playSound;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            playSound.gameObject.SetActive(true);
        }else if (playSound.gameObject.activeInHierarchy) {
                 playSound.gameObject.SetActive(false);
             }
        
    }

}
