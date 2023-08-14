using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFruits : MonoBehaviour
{

    

   

  
    public bool isFire;
    public GameObject[] fruitPrefabs;
    public GameObject firePoint;
    public GameObject enemy;
    public Transform turretBase;
    public GameObject particlePrefab;
    private float speed = 40.0f;
    private float rotSpeed = 5.0f;
    public AudioSource cannonFireAudio;
    static float delayReset = 5f;
    float delay = delayReset;

    [Header("Turret Settings")]
    public float firingAngle = 45.0f; // Default angle value
    public float minFiringAngle = 10.0f; // Minimum allowed firing angle
    public float maxFiringAngle = 80.0f; // Maximum allowed firing angle

    void Start()
    {
        ResetDelay();
    }

    void ResetDelay()
    {
        delay = Random.Range(2.0f, delayReset);
    }

    void CreateFruit()
    {
        int randomIndex = Random.Range(0, fruitPrefabs.Length);
        GameObject selectedFruitPrefab = fruitPrefabs[randomIndex];

        GameObject shell = Instantiate(selectedFruitPrefab, firePoint.transform.position, firePoint.transform.rotation);
        shell.GetComponent<Rigidbody>().velocity = speed * turretBase.forward;

        GameObject particles = Instantiate(particlePrefab, firePoint.transform.position, Quaternion.identity);
        particles.GetComponent<ParticleSystem>().Play();
        Destroy(particles, 2.0f);
        cannonFireAudio.Play();
    }

    float RotateTurret()
    {
        float angle = firingAngle;

        angle = Mathf.Clamp(angle, minFiringAngle, maxFiringAngle);

        turretBase.localEulerAngles = new Vector3(360.0f - angle, 0.0f, 0.0f);

        return angle;
    }

    float CalculateAngle(bool low)
    {
        Vector3 targetDir = enemy.transform.position - transform.position;
        float y = targetDir.y;
        targetDir.y = 0.0f;
        float x = targetDir.magnitude - 1.0f;
        float gravity = 9.8f;
        float sSqr = speed * speed;
        float underTheSqrRoot = (sSqr * sSqr) - gravity * (gravity * x * x + 2 * y * sSqr);

        if (underTheSqrRoot >= 0.0f)
        {
            float root = Mathf.Sqrt(underTheSqrRoot);
            float highAngle = sSqr + root;
            float lowAngle = sSqr - root;

            return low ? Mathf.Atan2(lowAngle, gravity * x) * Mathf.Rad2Deg : Mathf.Atan2(highAngle, gravity * x) * Mathf.Rad2Deg;
        }
        else
        {
            return float.NaN;
        }
    }

    void Update()
    {
        if (isFire)
        {
            delay -= Time.deltaTime;
            Vector3 direction = enemy.transform.position - transform.position;
            direction.y = 0.0f; // Project onto the XZ plane
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotSpeed);

            float angle = RotateTurret();

            if (!float.IsNaN(angle) && delay <= 0.0f)
            {
                CreateFruit();
                ResetDelay();
            }
        }
    }
}