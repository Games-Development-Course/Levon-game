using UnityEngine;

[System.Serializable]
public class QuizStep
{
    public Sprite image;
    public string[] answers = new string[4];
    public int correctIndex;
}
