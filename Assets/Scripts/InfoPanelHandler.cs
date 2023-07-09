using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoPanelHandler : MonoBehaviour
{
    [SerializeField]
    public CharacterInfo[] characters;

    public TextMeshProUGUI NameText;
    public TextMeshProUGUI GenderText;
    public TextMeshProUGUI OriginText;
    public TextMeshProUGUI HeightText;
    public TextMeshProUGUI WeightText;
    public TextMeshProUGUI StoryText;

    void SetCharactedInfo(string Name)
    {
        foreach (CharacterInfo character in characters)
        {
            if(character.Name == Name)
            {
                NameText.text = Name;
                GenderText.text = character.Gender;
                OriginText.text = character.Origin;
                HeightText.text = character.Height;
                WeightText.text = character.Weight;
                StoryText.text = character.Story;
            }
        }

    }
}
