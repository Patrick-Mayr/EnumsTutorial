using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Bullet;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 moveDirection;

    Rigidbody2D rb;
    [SerializeField] public float jumpAmount = 2;
    public GameObject ground;
    float offset;
    [SerializeField] public Rigidbody2D projectile;
    [SerializeField] public float force;

   
    // Start is called before the first frame update
    void Start()
    {
        Manager.Init(this);
        Manager.SetGameControls();
        rb = GetComponent<Rigidbody2D>();
        offset = (transform.position.y - ground.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * moveDirection;
    }

    public void SetMovementDirection(Vector2 currentDirection)
    {
        moveDirection = currentDirection;
    }

    public void Jump()
    {
        if (transform.position.y - ground.transform.position.y < offset)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse); //adds upward force to the block to allow a physics based jump
        }
    }

    public void Shoot()
    {
        Rigidbody2D bullet = Instantiate(projectile, transform.position, Quaternion.identity);
        
        if (moveDirection != Vector3.zero)
        {
            bullet.AddForce(moveDirection * force, ForceMode2D.Impulse);
        } else
        {
            Vector2 direction = new Vector2 (1, 0);
            bullet.AddForce(direction * force, ForceMode2D.Impulse);
        }

        Destroy(bullet,5);
    }

    

}
