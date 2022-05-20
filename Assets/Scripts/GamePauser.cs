using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePauser : MonoBehaviour
{

    public GameObject Menu;

    private bool pauseOn;

    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(pauseOn);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseOn)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseOn)
        {
            Pause();
        }
    }

    public void Pause()
    {
        Menu.SetActive(!pauseOn);
        pauseOn = !pauseOn;
        if(pauseOn)
            Time.timeScale = 0;
        if (!pauseOn)
            Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Return()
    {
        Pause();
    }

}
