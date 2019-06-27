using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Control : MonoBehaviour
{
    [SerializeField] Animator anim;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float dashSpeed;
    [SerializeField] public bool inDialogue;
    float yRot;
    float mouseX;
    float mouseY;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private Vector3 camPos;
    [SerializeField] private CharacterController cc;
    public bool isDiguise = false;
    [SerializeField] GameObject Diguise;

    [SerializeField] GameObject inventoryUI;

    [Space(10)]
    [Header("Weapon")]
    [SerializeField] bool melee;
    [SerializeField] private GameObject ObjectPool;
    [SerializeField] private GameObject weaponSpawn;
    [SerializeField] private GameObject[] weaponList;
    [SerializeField] private float rotSp;
    public bool hasGun;
    [SerializeField] private int ammo;
    [SerializeField] private int maxAmmo;
    [SerializeField] private float health;
    [SerializeField] private GameObject equppedWeapon;
    [SerializeField] GameObject unarmedObject;
    public bool unarmedReady;
    [Header("throwing")]
    [SerializeField] int throwableCount;
    public enum throwableType
    {
        none, explosive, knife
    }

    [SerializeField] GameObject EtoInteract;
    [SerializeField] GameObject QtoExplode;
    [SerializeField] GameObject targetCursor;

    public int explosiveJelly;

    private enum WeaponType
    {
        Unarmed, Shotgun, Handgun, autoMat, Spear
    }
    [SerializeField] private WeaponType weapon;

    [Space(10)]
    [Header("Health")]
    [SerializeField] private float hp;

    // Start is called before the first frame update
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Confined;
        ObjectPool = GameObject.Find("ObjectPool");
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        EquipGun(weapon);
        targetCursor = GameObject.Find("CrossHair");
    }


    // Update is called once per frame
    void Update()
    {
      
        //    Cursor.lockState = CursorLockMode.Confined;
        Moving();
        Dash();
        cameraMovement();

        //     Cursor.visible = false;
        //  targetCursor.SetActive(true);
        if (Input.GetKeyDown("i"))
        {
            inventoryUI.SetActive(true);

        }
        if (Input.GetKeyUp("i"))
        {
            inventoryUI.SetActive(false);
        }
    }


    private void Moving()
    {
        cc.transform.Translate(new Vector3((Input.GetAxis("Horizontal") * -speed * Time.deltaTime), (Input.GetAxis("Vertical") * -speed * Time.deltaTime), 0));

    }
    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            //Dashleft
            cc.transform.Translate (-dashSpeed*Time.deltaTime,0,0);
                }
        if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            //Dashright
            cc.transform.Translate(dashSpeed * Time.deltaTime, 0, 0);
        }
    }
    private void cameraMovement()
    {
        playerCamera.transform.position = this.transform.position + camPos;
    }
    float AnglebetweenTwopoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

  
    private void EquipGun(WeaponType weaponSelected)
    {
        Debug.Log("Pickup Gun");
        weapon = weaponSelected;
        if (weapon == WeaponType.Shotgun)
        {
            Instantiate(weaponList[0], weaponSpawn.transform.position, Quaternion.identity, weaponSpawn.transform);
            equppedWeapon = GameObject.FindGameObjectWithTag("PlayersGun");
            equppedWeapon.transform.localEulerAngles = weaponSpawn.transform.localEulerAngles;
            hasGun = true;
            unarmedObject.SetActive(false);
        }
        if (weapon == WeaponType.Spear)
        {
            Instantiate(weaponList[3], weaponSpawn.transform.position, Quaternion.identity, weaponSpawn.transform);
            equppedWeapon = GameObject.FindGameObjectWithTag("PlayersGun");
            equppedWeapon.transform.localEulerAngles = weaponSpawn.transform.localEulerAngles;
            hasGun = true;
            unarmedObject.SetActive(false);
        }
        if (weapon == WeaponType.Handgun)
        {
            Instantiate(weaponList[1], weaponSpawn.transform.position, Quaternion.identity, weaponSpawn.transform);
            equppedWeapon = GameObject.FindGameObjectWithTag("PlayersGun");
            equppedWeapon.transform.localEulerAngles = weaponSpawn.transform.localEulerAngles;
            hasGun = true;
            unarmedObject.SetActive(false);
        }
        if (weapon == WeaponType.autoMat)
        {
            Instantiate(weaponList[2], weaponSpawn.transform.position, Quaternion.identity, weaponSpawn.transform);
            equppedWeapon = GameObject.FindGameObjectWithTag("PlayersGun");
            equppedWeapon.transform.localEulerAngles = weaponSpawn.transform.localEulerAngles;
            hasGun = true;
            unarmedObject.SetActive(false);
        }
       /* if (weapon == WeaponType.Unarmed)
        {
            unarmedObject.SetActive(true);
            hasGun = false;

        }*/


    }

    /*void TakeDamage(float dam)
    {
        hp -= dam;
        if (hp<=0)
        {
            Debug.Log("I diagnose you as dead");
        }
    }*/
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Explodable")
        {
            if (Input.GetKeyDown("q"))
            {

            }
        }
        if (other.tag == "Chest")
        {
            
            if (Input.GetKeyDown("e"))
            {
               
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Chest")
        {
            EtoInteract.SetActive(false);
        }
    }
   
        }
    
  

