using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static int level = 1;

    public static float birdSpeed = 9f;
    public static float pipeGap = 5f;

    public static void ApplySelectedMode()
    {
        if (GameModeManager.SelectedMode == GameMode.Easy)
        {
            level = 1;
            birdSpeed = 15f;
            pipeGap = 3f;
        }
        else if (GameModeManager.SelectedMode == GameMode.Hard)
        {
            level = 2;
            birdSpeed = 15f;
            pipeGap = 1f;
        }
        else if (GameModeManager.SelectedMode == GameMode.Mission)
        {
            level = 3;
            birdSpeed = 10f;
            pipeGap = 4f;
        }
    }

    public static void SetLevel(int selectedLevel)
    {
        level = selectedLevel;

        if (level == 1)
        {
            GameModeManager.SelectedMode = GameMode.Easy;
        }
        else if (level == 2)
        {
            GameModeManager.SelectedMode = GameMode.Hard;
        }

        ApplySelectedMode();
    }
}
/*using UnityEngine;

public class GameSettings : MonoBehaviour
{

    public static int level = 1;

    public static float birdSpeed;
    public static float pipeGap;

    public static void SetLevel(int selectedLevel)
    {
        level = selectedLevel;

        if(level == 1)
        {
            
            birdSpeed = 18f;
            pipeGap = 8f;
        }
        else if(level == 2)
        {
            birdSpeed = 22f;
            pipeGap = 1f;
        }
    }

}*/
