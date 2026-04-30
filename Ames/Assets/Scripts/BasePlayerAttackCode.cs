using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BasePlayerAttackCode : MonoBehaviour
{

    public GameObject SwordPrefab;
    public GameObject SpellcastPrefab;
    public GameObject ArrowPrefab;
    public GameObject prefab;

    public bool SpellMode = false;
    public bool BowMode = false;
    public bool SwordMode = true;
    
    public float SwingSpeed = 0.1f;
    public float SwingLifetime = 2f;

    public float SpellTravelSpeed = 10f;
    public float SpellLifetime = 2f;
    
    public float shootSpeed = 10f;
    public float ArrowLifetime = 2f;


    public bool SpellShoot = true;
    public bool SwordShoot = true;
    public bool BowShoot = true;
    public bool projectileShoot = true;

   
    public Transform spawnPosition;
    public float bulletLifetime = 10;
    public float maxStamina = 100f;
    public float staminaDrainRate = 10f;
    public float staminaRechargeRate = 5f;
    public float maxMana = 100f;
    public float manaDrainRate = 10f;
    public float manaRechargeRate = 5f;
    private float currentStamina;
    private float currentMana;
    public Image StaminaBar;
    public Image ManaBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentStamina = maxStamina;
        StaminaBar.fillAmount = currentStamina / maxStamina;
        currentMana = maxMana;
        ManaBar.fillAmount = currentMana / maxMana;
    }
    public void OnToggle1(InputValue value)
    {
        Debug.Log("Sword Mode Activated");
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
                Debug.Log("currentMana: " + currentMana);
                Debug.Log("currentStamina: " + currentStamina);
                currentMana -= 25;
                currentStamina -= 5;
                Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                //if we hit something, tell me what we hit
                if (Physics.Raycast(ray, out hit, 10) && !SpellShoot)
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
                    GameObject pf = Instantiate(SpellcastPrefab, spawnPosition.position, Quaternion.identity);
                    Vector3 velocity = dest - spawnPosition.position;
                    velocity.Normalize();
                    pf.GetComponent<Rigidbody>().linearVelocity = velocity * SpellTravelSpeed;
                    Destroy(pf, SpellLifetime);
                }

                if (SwordMode == true)
                {
                    //first cast the ray out from the camera, in the way it is looking
                    //this variable will store info of what we hit, if anything
                    RaycastHit hit2;
                    currentStamina -= 20;
                    Ray ray2 = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                    //if we hit something, tell me what we hit
                    if (Physics.Raycast(ray2, out hit2, 10) && !SwordShoot)
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
                        Vector3 dest = hit2.point;
                        if (hit2.collider == null)
                        {
                            dest = Camera.main.transform.position + Camera.main.transform.forward * SwingSpeed;
                        }
                        GameObject swp = Instantiate(SwordPrefab, spawnPosition.position, Quaternion.identity);
                        Vector3 velocity = dest - spawnPosition.position;
                        velocity.Normalize();
                        swp.GetComponent<Rigidbody>().linearVelocity = velocity * SwingSpeed;
                        Destroy(swp, SwingLifetime);
                    }
                    if (BowMode == true)
                    {
                        //first cast the ray out from the camera, in the way it is looking
                        //this variable will store info of what we hit, if anything
                        RaycastHit hit1;
                        currentStamina -= 15;
                        Ray ray1 = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                        //if we hit something, tell me what we hit
                        if (Physics.Raycast(ray1, out hit1, 10) && !BowShoot)
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
                            Vector3 dest = hit1.point;
                            if (hit1.collider == null)
                            {
                                dest = Camera.main.transform.position + Camera.main.transform.forward * shootSpeed;
                            }
                            GameObject ap = Instantiate(ArrowPrefab, spawnPosition.position, Quaternion.identity);
                            Vector3 velocity = dest - spawnPosition.position;
                            velocity.Normalize();
                            ap.GetComponent<Rigidbody>().linearVelocity = velocity * shootSpeed;
                            Destroy(ap, ArrowLifetime);
                        }
                    }
                }
            }
        }
    }
                
            
        
    

            
    public void OnToggle2(InputValue value)
    {
        //this function will run whenever the 2 key is presseed
        Debug.Log("Bow Mode Activated");
        SpellMode = false;
        BowMode = true;
        SwordMode = false;
    }
    public void OnToggle3(InputValue value)
    {
        Debug.Log("Spell Mode Activated");
        //this function will run whenever the 3 key is presseed
        SpellMode = true;
        BowMode = false;
        SwordMode = false;
    }
    // Update is called once per frame
    void Update()
    {
        
        
        }
    }

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             