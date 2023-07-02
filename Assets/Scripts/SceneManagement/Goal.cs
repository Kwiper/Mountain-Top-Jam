using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    GameObject text2;
    [SerializeField]
    GameObject text3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Cutscene());
        }
    }

    IEnumerator Cutscene()
    {
        yield return new WaitForSeconds(0.5f);
        text2.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        text3.gameObject.SetActive(true);
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        Debug.Log("Quitting");
        Application.Quit();
    }
}
