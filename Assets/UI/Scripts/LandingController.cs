using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LandingController : MonoBehaviour
{
    
    [SerializeField] private InputField inputUsername;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Button button;
    
    public void OnChangeInputUsername()
    {

    }

    public void OnEndEditInputUsername()
    {
        ProfileManager.instance.SetPlayerName(inputUsername.text);
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene(1);
    }

    //public void OnClickButtonChange()
    //{
    //    //button.
    //}
}
