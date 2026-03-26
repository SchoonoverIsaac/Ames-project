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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void OnToggle1(InputValue value)
    {
        //this function will run whenever the 1 key is presseed
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Spell Attack");
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log(mousePos);
            mousePos.z = 0;
            //spawn a bullet
            GameObject bullet = Instantiate(SpellcastPrefab, transform.position, Quaternion.identity);
            //push the bullet in the direction of the mouse
            //destination (mousePosition) - starting position (transform.position)
            Vector3 mouseDir = mousePos - transform.position;
            mouseDir.Normalize();
            bullet.GetComponent<Rigidbody>().linearVelocity = mouseDir * SpellTravelSpeed;
            Destroy(bullet, SpellLifetime);
        }
    }

            
    public void OnToggle2(InputValue value)
    {
        //this function will run whenever the 1 key is presseed
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log(mousePos);
            mousePos.z = 0;
            //spawn a bullet
            GameObject bullet = Instantiate(ArrowPrefab, transform.position, Quaternion.identity);
            //push the bullet in the direction of the mouse
            //destination (mousePosition) - starting position (transform.position)
            Vector3 mouseDir = mousePos - transform.position;
            mouseDir.Normalize();
            bullet.GetComponent<Rigidbody>().linearVelocity = mouseDir * shootSpeed;
            Destroy(bullet, ArrowLifetime);
        }
    }
    public void OnToggle3(InputValue value)
    {
        //this function will run whenever the 1 key is presseed
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Sword Attack");
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log(mousePos);
            mousePos.z = 0;
            //spawn a bullet
            GameObject bullet = Instantiate(SwordPrefab, transform.position, Quaternion.identity);
            //push the bullet in the direction of the mouse
            //destination (mousePosition) - starting position (transform.position)
            Vector3 mouseDir = mousePos - transform.position;
            mouseDir.Normalize();
            bullet.GetComponent<Rigidbody>().linearVelocity = mouseDir * SwingSpeed;
            Destroy(bullet, SwingLifetime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        
        }
    }

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             