using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{

    Rigidbody2D rb;

    Player player;

    Vector2 startingPos;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        startingPos = transform.position;
    }

    private void Update()
    {
        if(player.StateMachine.CurrentState == player.DeathState)
        {
            player.transform.SetParent(null);
            rb.bodyType = RigidbodyType2D.Static;
            StartCoroutine(Reset());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
            collision.gameObject.GetComponent<Player>().WallGrabState.isHoldingFallingBlock = true;
            StartCoroutine(Fall());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().WallGrabState.isHoldingFallingBlock = false;
            collision.transform.SetParent(null);
        }
    }

    IEnumerator Fall()
    {
        Debug.Log("Coroutine Started");
        yield return new WaitForSeconds(0.5f);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.5f);
        transform.position = startingPos;
    }
}
