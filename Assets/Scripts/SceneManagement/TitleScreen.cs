using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void OnButtonPressed(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("Screen1");
    }
}
