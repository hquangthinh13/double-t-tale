using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character 
{
    public string name;
    public Sprite characterSprites;
}
[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public Character[] character;
    public int characterCount
    {
        get
        {
            return character.Length;
        }
    }
    public Character GetCharacter(int i)
    {
        return character[i];
    }

}
