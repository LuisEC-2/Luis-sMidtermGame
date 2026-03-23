using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenChanger : MonoBehaviour
{

    public string StartScene;

    private int playersInPathway = 0;
    public int PathwayWin = 3;


    void OnTriggerEnter2D(Collider2D other)
    {   //Esc scene to last scene via gate trigger, pathway hold the script for communication
        if (other.gameObject.CompareTag("PlayerS") || other.gameObject.CompareTag("PlayerT") ||
            other.gameObject.CompareTag("PlayerC"))
        {
            playersInPathway++;
            if (playersInPathway >= PathwayWin)
            {
                SceneManager.LoadScene("To Be Continued");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerS") || other.gameObject.CompareTag("PlayerT") ||
            other.gameObject.CompareTag("PlayerC"))
        {
            playersInPathway--;
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   //From 1st scene to Esc scene
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            LoadGameScene();
        }
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(StartScene);
    }
}
