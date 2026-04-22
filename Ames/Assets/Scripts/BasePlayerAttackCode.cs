using UnityEngine;
using UnityEngine.InputSystem;

public class BasePlayerAttackCode : MonoBehaviour
{
    public bool SpellMode = false;
    public bool BowMode = false;
    public bool SwordMode = true;
    public GameObject SwordPrefab;
    public float SwingSpeed = 0.1f;
    public float SwingLifetime = 2f;
    public GameObject SpellcastPrefab;
    public float SpellTravelSpeed = 10f;
    public float SpellLifetime = 2f;
    public GameObject ArrowPrefab;
    public float shootSpeed = 10f;
    public float ArrowLifetime = 2f;

    public bool projectileShoot = true;
    public GameObject prefab;
    public Transform spawnPosition;
    public float bulletLifetime = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void OnToggle1(InputValue value)
    {
        //this function will run whenever the 1 key is presseed
        SpellMode = false;
        BowMode = false;
        SwordMode = true;

    }

    public void OnShoot(InputValue value)
    {
        //add your 3D shooting code here
        if (value.isPressed)
        {
            if (SpellMode == true)
            {
                //first cast the ray out from the camera, in the way it is looking
                //this variable will store info of what we hit, if anything
                RaycastHit hit;
                Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                //if we hit something, tell me what we hit
                if (Physics.Raycast(ray, out hit, 10) && !projectileShoot)
                {
                    if (hit.collider != null)
                    {
                        Debug.Log(hit.collider.gameObject.name);
                        if (hit.collider.gameObject.GetComponent<EnemyHealth>() != null)
                        {
                            hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
                        }
                    }
                }
                else
                {
                    //this is where we want to spawn the projectile
                    //our preferred destination will be the point where our raycast hits
                    Vector3 dest = hit.point;
                    if (hit.collider == null)
                    {
                        dest = Camera.main.transform.position + Camera.main.transform.forward * SpellTravelSpeed;
                    }
                    GameObject SpellcastPrefab = Instantiate(prefab, spawnPosition.position, Quaternion.identity);
                    Vector3 velocity = dest - spawnPosition.position;
                    velocity.Normalize();
                    SpellcastPrefab.GetComponent<Rigidbody>().linearVelocity = velocity * SpellTravelSpeed;
                    Destroy(SpellcastPrefab, SpellLifetime);
                }

                if (SwordMode == true)
                {
                    //first cast the ray out from the camera, in the way it is looking
                    //this variable will store info of what we hit, if anything
                    RaycastHit hit2;
                    Ray ray2 = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                    //if we hit something, tell me what we hit
                    if (Physics.Raycast(ray2, out hit2, 10) && !projectileShoot)
                    {
                        if (hit2.collider != null)
                        {
                            Debug.Log(hit2.collider.gameObject.name);
                            if (hit2.collider.gameObject.GetComponent<EnemyHealth>() != null)
                            {
                                hit2.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
                            }
                        }
                    }
                    else
                    {
                        //this is where we want to spawn the projectile
                        //our preferred destination will be the point where our raycast hits
                        Vector3 dest = hit.point;
                        if (hit.collider == null)
                        {
                            dest = Camera.main.transform.position + Camera.main.transform.forward * SwingSpeed;
                        }
                        GameObject SwordPrefab = Instantiate(prefab, spawnPosition.position, Quaternion.identity);
                        Vector3 velocity = dest - spawnPosition.position;
                        velocity.Normalize();
                        SwordPrefab.GetComponent<Rigidbody>().linearVelocity = velocity * SwingSpeed;
                        Destroy(SwordPrefab, SwingLifetime);
                    }
                    if (BowMode == true)
                    {
                        //first cast the ray out from the camera, in the way it is looking
                        //this variable will store info of what we hit, if anything
                        RaycastHit hit1;
                        Ray ray1 = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                        //if we hit something, tell me what we hit
                        if (Physics.Raycast(ray1, out hit1, 10) && !projectileShoot)
                        {
                            if (hit1.collider != null)
                            {
                                Debug.Log(hit1.collider.gameObject.name);
                                if (hit1.collider.gameObject.GetComponent<EnemyHealth>() != null)
                                {
                                    hit1.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
                                }
                            }
                        }
                        else
                        {
                            //this is where we want to spawn the projectile
                            //our preferred destination will be the point where our raycast hits
                            Vector3 dest = hit.point;
                            if (hit.collider == null)
                            {
                                dest = Camera.main.transform.position + Camera.main.transform.forward * shootSpeed;
                            }
                            GameObject ArrowPrefab = Instantiate(prefab, spawnPosition.position, Quaternion.identity);
                            Vector3 velocity = dest - spawnPosition.position;
                            velocity.Normalize();
                            ArrowPrefab.GetComponent<Rigidbody>().linearVelocity = velocity * shootSpeed;
                            Destroy(ArrowPrefab, ArrowLifetime);
                        }
                    }
                }
            }
        }
    }
                
            
        
    

            
    public void OnToggle2(InputValue value)
    {
        //this function will run whenever the 1 key is presseed
        SpellMode = false;
        BowMode = true;
        SwordMode = false;
    }
    public void OnToggle3(InputValue value)
    {
        //this function will run whenever the 1 key is presseed
        SpellMode = true;
        BowMode = false;
        SwordMode = false;
    }
    // Update is called once per frame
    void Update()
    {
        
        
        }
    }

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             