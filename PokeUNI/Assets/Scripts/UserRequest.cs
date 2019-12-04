using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class UserRequest : MonoBehaviour
{
    // Define path to call the api ... fixed github for testing
    private readonly string baseURL = "https://raw.githubusercontent.com/lArkl/gamify-uni-admin/master/requests/userrequest.json";
    public UserInfo user;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetTextFromRequest());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetTextFromRequest()
    {

        UnityWebRequest request = UnityWebRequest.Get(baseURL);
        yield return request.SendWebRequest();

        if (request.isNetworkError  || request.isHttpError)
        {
            Debug.Log(request.error);
            yield break;
        }

        JSONNode userRequest = JSON.Parse(request.downloadHandler.text);
        user = new UserInfo(userRequest["username"], userRequest["totalPoints"]);

        var pokedex = userRequest["pokedex"];
        // Declare array for pokemon storage
        var pokedexList = new List<PokeInfo>();
        foreach (var elem in pokedex) {
            PokeInfo p = new PokeInfo(elem.Value["name"], elem.Value["quantity"]);
            pokedexList.Add(p);
        }
        //pokeArray = pokedexList.ToArray();
        user.setPokedex(pokedexList.ToArray());

        var questions = userRequest["retodex"];
        // Declare array for pokemon storage
        var questionList = new List<QuestionInfo>();
        foreach (var elem in questions)
        {
            QuestionInfo q = new QuestionInfo(elem.Value["question"], elem.Value["quantity"], elem.Value["last_seen"]);
            questionList.Add(q);
        }
        //questionArray = questionList.ToArray();
        user.setQuestions(questionList.ToArray());



        
    }
}