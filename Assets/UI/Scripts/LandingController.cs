using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LandingController : MonoBehaviour
{
    
    [SerializeField] private InputField inputUsername;
    
    public void OnChangeInputUsername()
    {

    }

    public void OnEndEditInputUsername()
    {
        ProfileManager.instance.SetPlayerName(inputUsername.text);
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene("PreEntrega");
    }
}
