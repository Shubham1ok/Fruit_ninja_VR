using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosion;
    public AudioSource audioBombExplode;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Sword" || col.gameObject.tag == "Player")
        {
            if (audioBombExplode != null)
            {
                audioBombExplode.Play();
                audioBombExplode.transform.SetParent(null); // Detach AudioSource
            }
            HealthManager.instance.TakeDamage(20);
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(audioBombExplode.gameObject, 3f);
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
       
        Destroy(gameObject, 3);
    }

   
}
