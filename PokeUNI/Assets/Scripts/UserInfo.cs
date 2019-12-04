using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PokeInfo
{
    private string name;
    private int quantity;
    public PokeInfo(string name, int quantity)
    {
        this.name = name;
        this.quantity = quantity;
    }
    public string GetName() { return name; }
    public int GetQty() { return quantity; }
}

public class QuestionInfo
{
    private string question;
    private int quantity;
    private string lastSeen;
    public QuestionInfo(string q, int quantity,string last)
    {
        this.question = q;
        this.quantity = quantity;
        lastSeen = last;
    }
    public string GetQuestion() { return question; }
    public int GetQty() { return quantity; }
    public string GetSeen() { return lastSeen; }
}

public class UserInfo
{
    private string name;
    private int points;
    PokeInfo[] pokeArray;
    QuestionInfo[] questionArray;
    // Start is called before the first frame update
    public UserInfo(string n, int p)
    {
        name = n;
        points = p;
    }
    public void setPokedex(PokeInfo[] pk)
    {
        pokeArray = pk;
    }
    public void setQuestions(QuestionInfo[] q)
    {
        questionArray = q;
    }
    public string getName() { return name; }
    public int getPoints() { return points; }
    public PokeInfo[] getPokedex() { return pokeArray; }
    public QuestionInfo[] getQuestiondex() { return questionArray; }
}