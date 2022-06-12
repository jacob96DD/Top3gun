using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class magazineScore : MonoBehaviour
{
    public TextMeshProUGUI magazineSize;

    public TextMeshProUGUI shots;

    public Revolversound rs;

    // Start is called before the first frame update
    void Start()
    {
        magazineSize.text = "Magazine Size: " + rs.magasin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (rs.shotsFired == rs.magasin)
        {
            shots.text = "Reloading...";
        }
        else
        {
            shots.text = "Shots Fired: " + rs.shotsFired.ToString();
        }
    }
}
