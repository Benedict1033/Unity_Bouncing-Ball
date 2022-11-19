using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject [] characters;
    int selectedCharacter =0;

    private void Start ( )
    {
        foreach(GameObject ch in characters )
        {
            ch. SetActive ( false );
        }

        characters [ selectedCharacter ]. SetActive ( true );
    }

    public void changeCharacter(int newCharacter )
    {
        characters [ selectedCharacter ]. SetActive ( false );
        characters [ newCharacter ]. SetActive ( true );
        selectedCharacter=newCharacter;
    }
}
