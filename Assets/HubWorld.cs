using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubWorld : MonoBehaviour
{
    // Start is called before the first frame update
    public void Mt ()
    {
        SceneManager.LoadScene(1);
    }
    public void Water ()
    {
        SceneManager.LoadScene(2);
    }

    public void Yeet ()
    {
        Debug.Log("VAMOOSE");
        Application.Quit();
    }
}
