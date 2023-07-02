using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawnPoint : MonoBehaviour
{
    [SerializeField]
    PlayerData playerData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerData.respawnPoint = new Vector2(transform.position.x, transform.position.y);
        }
    }

}
