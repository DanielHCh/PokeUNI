using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour
{
    public ScrollRect scrollView;
    public GameObject scrollContent;
    public GameObject scrollItemPrefab;
    private bool loadedInfo = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FillPokedex(PokeInfo[] lst)
    {
        ClearScroll();
        //pokedex
        foreach (var elem in lst)
        {
            GeneratePokeItem(elem.GetName(), elem.GetQty());
        }
        scrollView.verticalNormalizedPosition = 1;
        loadedInfo = true;

    }

    public void FillQuestiondex(QuestionInfo[] lst)
    {
        ClearScroll();
        //Retodex
        foreach (var elem in lst)
        {
            GenerateQuestionItem(elem.GetQuestion(), elem.GetQty(), elem.GetSeen(), 2);
        }
        scrollView.verticalNormalizedPosition = 1;
        loadedInfo = true;
    }

    /* Borra la lista de items del prefab, aunque tiene un bug :'v */
    public void ClearScroll()
    {
        var objectB = scrollContent;
        for (var i = scrollContent.transform.childCount - 1; i >= 0; i--)
        {
            // objectA is not the attached GameObject, so you can do all your checks with it.
            var objectA = objectB.transform.GetChild(i);
            objectA.transform.parent = null;
            // Optionally destroy the objectA if not longer needed
            //Destroy(objectA);
        }
    }

    private void GeneratePokeItem(string name, int q)
    {
        GameObject scrollItemObj = Instantiate(scrollItemPrefab);
        scrollItemObj.transform.SetParent(scrollContent.transform, false);
        var nameText = scrollItemObj.transform.Find("pokeName").gameObject.GetComponent<Text>();
        nameText.fontSize = 28;
        nameText.text = FirstLetterToUpperCaseOrConvertNullToEmptyString(name);
        scrollItemObj.transform.Find("pokeQty").gameObject.GetComponent<Text>().text = "Cantidad: " + q.ToString();
        scrollItemObj.transform.Find("pokeType").gameObject.GetComponent<Text>().text = "Tipo: " + "Rocon";

        Texture2D tex = new Texture2D(2, 2);
        var img = Resources.Load("Sprites/" + name) as Texture2D;
        //Debug.Log(img);
        scrollItemObj.transform.Find("pokeSprite").gameObject.GetComponent<Image>().sprite = Sprite.Create(img, new Rect(0, 0, 256, 256), new Vector2());
    }
    private void GenerateQuestionItem(string name, int q,string last, int t)
    {
        GameObject scrollItemObj = Instantiate(scrollItemPrefab);
        scrollItemObj.transform.SetParent(scrollContent.transform, false);

        var nameText = scrollItemObj.transform.Find("pokeName").gameObject.GetComponent<Text>();
        nameText.fontSize = 22;
        nameText.text = FirstLetterToUpperCaseOrConvertNullToEmptyString(name);
        scrollItemObj.transform.Find("pokeQty").gameObject.GetComponent<Text>().text = "Cantidad: " + q.ToString();
        scrollItemObj.transform.Find("pokeType").gameObject.GetComponent<Text>().text = "Visto: " + last;

        Texture2D tex = new Texture2D(2, 2);
        var img = Resources.Load("Sprites/question" + t.ToString()) as Texture2D;
        //Debug.Log(img);
        scrollItemObj.transform.Find("pokeSprite").gameObject.GetComponent<Image>().sprite = Sprite.Create(img, new Rect(0, 0, 256, 256), new Vector2());
    }

    private string FirstLetterToUpperCaseOrConvertNullToEmptyString(string s)
    {
        if (string.IsNullOrEmpty(s))
            return string.Empty;

        char[] a = s.ToCharArray();
        a[0] = char.ToUpper(a[0]);
        return new string(a);
    }
}