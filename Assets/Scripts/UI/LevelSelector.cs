using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public GameObject levelPanel;

    public void OpenLevelMenu()
    {
        levelPanel.SetActive(true);
    }

    public void SelectEasy()
    {
        GameSettings.SetLevel(1);
        levelPanel.SetActive(false);
    }

    public void SelectHard()
    {
        GameSettings.SetLevel(2);
        levelPanel.SetActive(false);
    }
    /*
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
