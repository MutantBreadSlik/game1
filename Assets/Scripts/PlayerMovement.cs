using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 mousePos;
    public Camera cam;
    public Transform shootPoint;
    public GameObject bulletPrefab;
    public float offset; 

    private bool canShoot = true; 

    List<GameObject> bulletsOnScreen = new List<GameObject>();

    [Header("Shooting")]
    public float bulletForce = 4.0f;
    public bool limitBullet = false;
     

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    { 
        // Get Input 
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Reset if player presses R
        if(Input.GetKeyDown(KeyCode.R)){
            transform.position = Vector3.zero;
            canShoot = true;

            
            
        }

        // Clear all bullets
        if(Input.GetKeyDown(KeyCode.C)) {
            for(int i = 0; i < bulletsOnScreen.Count; i++) {
                Destroy(bulletsOnScreen[i].gameObject);
                canShoot = true;
            }
        }

        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);

        // Get direction of mouse cursor
        Vector2 lookDir = mousePos - rb.position;
        lookDir.Normalize();

        // Get the angle towards the direction of the mouse
        float angle = Mathf.Atan2(lookDir.x , lookDir.y) * Mathf.Rad2Deg - offset;

        // Rotate the bullet origin point by the angle.
        shootPoint.Rotate(new Vector3(0f , 0f , angle));

        if(!limitBullet) { canShoot = true; }

        // Shoot if player has clicked and can shoot.
        if(Input.GetButtonDown("Fire1") && canShoot){
           
           StartCoroutine(Shoot(lookDir));
            canShoot = false;
        }

        GameObject bulletObject = bulletsOnScreen[0];
        
        if(bulletObject.transform.position.x >= transform.position.x -3 && bulletObject.transform.position.y >= transform.position.y -3) {
            if(bulletObject.transform.position.x <= transform.position.x +3 && bulletObject.transform.position.y <= transform.position.y +3) {

                if(Input.GetButtonDown("Fire2")) {
                    for(int i = 0; i < bulletsOnScreen.Count; i++) {
                        Destroy(bulletsOnScreen[i].gameObject);
                        bulletsOnScreen.Remove(bulletsOnScreen[i].gameObject);
                        canShoot = true;
                    }
                }
           }
          

       }
    }

    
    
       
    IEnumerator Shoot(Vector2 angle){
        // Spawn a bullet, and get the rigidbody attached.
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        bulletsOnScreen.Add(bullet);

        //bullet.GetComponent<CircleCollider2D>().enabled = false;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Add force to the bullet
        rb.AddForce((bulletForce * 100) * angle);

        
        //yield return new WaitForSeconds(0.12f);
        bullet.transform.position = new Vector3(bullet.transform.position.x, bullet.transform.position.y, -1f);

      

        yield return null;

        
        
    }


    
}
