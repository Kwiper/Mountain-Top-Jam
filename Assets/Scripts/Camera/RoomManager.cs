using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class RoomManager : MonoBehaviour
{

    public GameObject virtualCam;
    [SerializeField]
    string[] scenesToLoad;
    [SerializeField]
    string[] scenesToUnload;

    [SerializeField]
    string audioSourceTarget;

    AudioSource audioSource;

    bool musicTrigger;

    private void Start()
    {
        musicTrigger = false;
    }

    private void Update()
    {
        if (musicTrigger)
        {
            if(audioSource.volume < 0.5f)
            {
                audioSource.volume += 0.01f;
            }

            if(audioSource.volume > 0.5f)
            {
                audioSource.volume = 0.5f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            if (audioSourceTarget != "")
            {
                audioSource = GameObject.Find(audioSourceTarget).GetComponent<AudioSource>();
                musicTrigger = true;
            }

            virtualCam.SetActive(true);

            virtualCam.GetComponent<CinemachineVirtualCamera>().Follow = collision.transform;

            for (int i = 0; i < scenesToUnload.Length; i++)
            {
                if (SceneManager.GetSceneByName(scenesToUnload[i]).IsValid())
                {
                    SceneManager.UnloadSceneAsync(scenesToUnload[i]);
                }
            }

            for (int i = 0; i < scenesToLoad.Length; i++)
            {

                if (!SceneManager.GetSceneByName(scenesToLoad[i]).IsValid()){
                    SceneManager.LoadSceneAsync(scenesToLoad[i], LoadSceneMode.Additive);
                }
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            virtualCam.SetActive(false);

        }
    }
}
