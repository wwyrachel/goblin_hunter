using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_test : MonoBehaviour {

    public float speed = 6.0f;
    public float runspeed = 8.0f;
    public float jumpSpeed = 0f;
    public float gravity = 10.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    static Animator animate;

    public Inventory inventory;

    public Key key;

    public string SceneToLoad;

    public GameObject Hand;

    public GameObject bulletPrefab;

    public Transform bulletSpawn;

    public int health = 100;

    private HealthPoint mHealthPoint;

    public float bulletSpeed = 30;

    public float lifeTime = 3;

    public HUD Hud;

    

    void Start()
    {
        animate = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        inventory.ItemUsed += Inventory_ItemUsed;
        inventory.ItemRemoved += Inventory_ItemRemoved;
        mHealthPoint = Hud.transform.Find("HealthPoint").GetComponent<HealthPoint>();
        mHealthPoint.Min = 0;
        mHealthPoint.Max = health;

        // let the gameObject fall down
        //gameObject.transform.position = new Vector3(404, 1, 180);

        
    }

    public void TakeDamage(int amount) {
        health -= amount;
        if (health < 0)
        {
            health = 0;

        }
        mHealthPoint.SetHealth(health);


    }

    void Update()
    {

        //Short cut keys for demo

        if (Input.GetKeyDown(KeyCode.T))
        {
            transform.position = new Vector3(400f, 1f, 162f);
        }

        if (Input.GetKeyDown(KeyCode.Y)) {
            transform.position = new Vector3(-543f, 10f, 934f);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            transform.position = new Vector3(660f, 0f, 172f);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            transform.position = new Vector3(812f, 1f, 693f);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            transform.position = new Vector3(860f, 61f, 762f);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.position = new Vector3(995f, 61f, 839f);
        }

        //above are shortcut keys for demo



        if (Input.GetKeyDown(KeyCode.G)){

            speed = 3.0f;
            animate.SetBool("kick", false);
            animate.SetBool("jumping", false);
            animate.SetBool("idle", false);
            animate.SetBool("walking", false);
            animate.SetBool("running", false);
            animate.SetBool("pose", true);
            animate.SetBool("attack", false);

            fire();

        }
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes



            //print("yes");
                speed = 3.0f;
                
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection = moveDirection * speed;


                animate.SetBool("jumping", false);
                animate.SetBool("idle", false);
                animate.SetBool("walking", true);
                animate.SetBool("kick", false);
                animate.SetBool("running", false);
                animate.SetBool("pose", false);
                animate.SetBool("attack", false);

            if (Input.GetKey("up") && Input.GetKey(KeyCode.RightShift)) {
                speed = 15.0f;
                animate.SetBool("jumping", false);
                animate.SetBool("idle", false);
                animate.SetBool("walking", false);
                animate.SetBool("kick", false);
                animate.SetBool("running", true);
                animate.SetBool("pose", false);
                animate.SetBool("attack", false);

            }
            
       

    

            if (Input.GetKeyDown(KeyCode.K))
                {
                    
                    speed = 3.0f;
                    animate.SetBool("kick", true);
                    animate.SetBool("jumping", false);
                    animate.SetBool("idle", false);
                    animate.SetBool("walking", false);
                    animate.SetBool("running", false);
                    animate.SetBool("pose", false);
                    animate.SetBool("attack", false);

            }

            if (Input.GetKeyDown(KeyCode.L))
            {

                speed = 3.0f;
                animate.SetBool("kick", false);
                animate.SetBool("jumping", false);
                animate.SetBool("idle", false);
                animate.SetBool("walking", false);
                animate.SetBool("running", false);
                animate.SetBool("pose", false);
                animate.SetBool("attack", true);

            }



            if (Input.GetButton("Jump"))
                {
                    speed = 3.0f;
                    print("speed: " + speed);
                    moveDirection.y = jumpSpeed;
                    animate.SetBool("jumping", true);
                    animate.SetBool("idle", false);
                    animate.SetBool("walking", false);
                    animate.SetBool("running", false);
                    animate.SetBool("pose", false);
                    animate.SetBool("kick", false);
                    animate.SetBool("attack", false);
            }
            
        }

            speed = 3.0f;
            // Apply gravity
            
            moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

                // Move the controller
                controller.Move(moveDirection * Time.deltaTime);
                transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
            
        
    }
    private void fire() {
        print("fire");
        GameObject bullet = Instantiate(bulletPrefab);

        Physics.IgnoreCollision(bullet.GetComponent<Collider>(),
            bulletSpawn.parent.GetComponent<Collider>());

        bullet.transform.position = bulletSpawn.position;

        Vector3 rotation = bullet.transform.rotation.eulerAngles;

        bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);

        StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay) {
        yield return new WaitForSeconds(delay);

        Destroy(bullet);
    }

    private void OnCollisionEnter(Collision hit) {
        //print("yes");

        IKeyItem kitem = hit.collider.GetComponent<IKeyItem>();
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();

        if (item != null) {
            print("no");
            inventory.AddItem(item);
            
        }

        if (kitem != null) {
            key.AddItem(kitem);
        }

    }


    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e) {

        IInventoryItem item = e.Item;

        GameObject goItem = (item as MonoBehaviour).gameObject;
        goItem.SetActive(true);

        goItem.transform.parent = null;

    }

    private void Inventory_ItemUsed(object sender, InventoryEventArgs e) {
        IInventoryItem item = e.Item;

        GameObject goItem = (item as MonoBehaviour).gameObject;

        goItem.SetActive(true);

       // Hand.transform.child= goItem.transform;

        goItem.transform.parent = Hand.transform;
        //goItem.transform.position = Hand.transform.position;
        goItem.transform.localPosition = (item as InventoryItemBase).PickPosition;
        goItem.transform.localEulerAngles = (item as InventoryItemBase).PickRotation;
    }
}
