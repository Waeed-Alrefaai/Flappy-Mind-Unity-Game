using UnityEngine;

/*
public class CharacterManager
{
    
}
using UnityEngine;
*/

public class CharacterManager : MonoBehaviour
{
    public static int selectedCharacter = 0;

    public void SelectCharacter(int index)
    {
        selectedCharacter = index;
    }
}
