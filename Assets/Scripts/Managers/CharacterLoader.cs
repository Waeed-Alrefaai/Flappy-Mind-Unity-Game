
using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    public GameObject[] characters;

    void Start()
    {
        int index = CharacterManager.selectedCharacter;
        characters[index].SetActive(true);
    }
}
