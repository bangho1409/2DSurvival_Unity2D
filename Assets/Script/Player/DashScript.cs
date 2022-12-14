using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    public float dashDistance = 2f;
    public bool Dashing;
    [SerializeField] LayerMask dashLayer;
    playermove playermove;
    Rigidbody2D rb;
    public GameObject dashEffect;
    float cooldownTime;
    

    private void Awake()
    {
        playermove = GetComponent<playermove>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    
    void Update()
    {
        if (playermove.MoveVector.x != 0)
        {
            playermove.LastHorizontal = playermove.MoveVector.x;
        }
        if (playermove.MoveVector.y != 0)
        {
            playermove.LastVertical = playermove.MoveVector.y;
        }


        // When Player hit Space keyboard, character will dash base on where it Facing and it will have a cooldown time to dash again.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playermove.LastHorizontal < 0 && cooldownTime <= Time.time )
            {
                
                StartCoroutine(Dash());

                Debug.Log("You dashed left");
            }
            if (playermove.LastHorizontal > 0 && cooldownTime <= Time.time)
            {
                
                StartCoroutine(Dash());
                Debug.Log("You dashed right");
            }
        }
    }

    IEnumerator Dash()
    {     
        cooldownTime = Time.time + 1;
        Dashing = true;
        Vector3 dashPosition = transform.position + playermove.MoveVector * dashDistance;
        RaycastHit2D raycast2D = Physics2D.Raycast(transform.position, playermove.MoveVector, dashDistance, dashLayer);
        if (raycast2D.collider != null)
        {
            dashPosition = raycast2D.point;
        }
        rb.MovePosition(dashPosition);

        dashEffect.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        dashEffect.SetActive(false);

        Dashing = false;
    }

}
