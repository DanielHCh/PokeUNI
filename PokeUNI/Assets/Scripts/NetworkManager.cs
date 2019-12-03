using System;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{

    public void CrearUsuario(string user, string email, string pass, Action<Response> response)
    {
        //StartCoroutine(CO_CrearUsuario(user, email, pass, response));
    }
    /*
    private IEnumerator CO_CrearUsuario(string user, string email, string pass, Action<Response> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("userName", user);
        form.AddField("email", email);
        form.AddField("pass", pass);

        //WWW w = new WWW("http://localhost/juego/crearUsuario.php",form);

        //yield return w;

        //response(JsonUtility.FromJson<Response>(w.test));
    }*/
}

[Serializable]
public class Response {

    public bool hecho = false;
    public string mensaje = "";

}