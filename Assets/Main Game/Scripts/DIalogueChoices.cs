using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Choice
{
  [TextArea(3, 10)]
  public string text;
  public Dialogue dialogue;
}

[CreateAssetMenu(fileName = "New Choices", menuName = "Choices")]
public class DialogueChoices : ScriptableObject
{
   [TextArea(3, 10)]
   public string text;
   public Choice[] choicetext;
}
