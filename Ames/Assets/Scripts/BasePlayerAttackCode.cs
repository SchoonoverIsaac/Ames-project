using UnityEngine;

public class BasePlayerAttackCode : MonoBehaviour
public bool SpellMode = false;
public bool BowMode = false;
public bool SwordMode = true;
public GameObject SwordSwing;
public float SwingSpeed = 0.1f;
public float SwingLifetime = 2f;
public GameObject Spellcast;
public float SpellTravelSpeed = 10f;
public float SpellLifetime = 2f;
public GameObject Arrow;
public float shootSpeed = 10f;
public float ArrowLifetime = 2f;
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("1"))
        {
            SpellMode = false;
            BowMode = false;
            SwordMode = true;
        }
        if (Input.GetButtonDown("2"))
        {
            SpellMode = false;
            BowMode = true;
            SwordMode = false;
        }
        if (Input.GetButtonDown("3"))
        {
            SpellMode = true;
            BowMode = false;
            SwordMode = false;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (SpellMode)
            {

                Debug.Log("Spell Attack");
                Vector3 mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                Debug.Log(mousePos);
                mousePos.z = 0;
                //spawn a bullet
                GameObject Spellcast = Instantiate(prefab, transform.position, Quaternion.identity);
                //push the bullet in the direction of the mouse
                //destination (mousePosition) - starting position (transform.position)
                Vector3 mouseDir = mousePos - transform.position;
                mouseDir.Normalize();
                Spellcast.GetComponent<Rigidbody2D>().velocity = mouseDir * SpellTravelSpeed;
                Destroy(Spellcast, SpellLifetime);

            }
            else if (BowMode)
            {
                Debug.Log("Bow Attack");
                Vector3 mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                Debug.Log(mousePos);
                mousePos.z = 0;
                //spawn a bullet
                GameObject Arrow = Instantiate(prefab, transform.position, Quaternion.identity);
                //push the bullet in the direction of the mouse
                //destination (mousePosition) - starting position (transform.position)
                Vector3 mouseDir = mousePos - transform.position;
                mouseDir.Normalize();
                Arrow.GetComponent<Rigidbody2D>().velocity = mouseDir * shootSpeed;
                Destroy(Arrow, ArrowLifetime);
            }
            else if (SwordMode)
            {
                Debug.Log("Sword Attack");
                Vector3 mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                Debug.Log(mousePos);
                mousePos.z = 0;
                //spawn a bullet
                GameObject SwordSwing = Instantiate(prefab, transform.position, Quaternion.identity);
                //push the bullet in the direction of the mouse
                //destination (mousePosition) - starting position (transform.position)
                Vector3 mouseDir = mousePos - transform.position;
                mouseDir.Normalize();
                SwordSwing.GetComponent<Rigidbody2D>().velocity = mouseDir * SwingSpeed;
                Destroy(SwordSwing, SwingLifetime);
            }
        }
    }
}
