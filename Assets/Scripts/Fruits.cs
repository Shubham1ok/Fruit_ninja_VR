using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public GameObject explosion;
    public AudioSource audioSlice;

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Sword")
        {
            if (audioSlice != null)
            {
                audioSlice.Play();
                audioSlice.transform.SetParent(null); // Detach AudioSource
            }
            
            ScoreManager.instance.score += 10;
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(audioSlice.gameObject, 3f);
            Destroy(this.gameObject);
        }
    }

    void Start()
    {

       
        Destroy(gameObject, 3);
    }

   
}
