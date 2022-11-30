using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ***
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton Pattern

    // instance variable
    static GameManager instance;
    [SerializeField] int coinsCollected;

    private void Awake() // Awake() happens once
    {
        // see if it's null
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            // destroy self if not null
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadScene("SE Second Scene");
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
