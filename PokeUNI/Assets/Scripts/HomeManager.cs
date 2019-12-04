using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class HomeManager : MonoBehaviour
{
    /*
    [SerializeField] private InputField m_userInput = null;
    [SerializeField] private InputField m_emailInput = null;
    [SerializeField] private InputField m_pass1Input = null;
    [SerializeField] private InputField m_pass2Input = null;
    [SerializeField] private Text m_textoError = null;
    [SerializeField] private GameObject m_logBG = null;
    [SerializeField] private GameObject m_gameBG = null;
    [SerializeField] private InputField m_userLog = null;
    [SerializeField] private InputField m_passLog = null;
    */
    //[SerializeField] private GameObject m_retodexUI = null;
    [SerializeField] private GameObject m_homeUI = null;
    [SerializeField] private GameObject m_prdexUI = null;

    [SerializeField]
    private GameObject _refButtonLogin;

    [SerializeField]
    private AudioSource[] _refButtonSounds;

    private AudioSource soundLoginAccept;
    private AudioSource soundLoginDeny;

    private UserInfo user;
    private ScrollManager sc;

    private bool loadedInfo = false;

    private void Start()
    {
        sc = GetComponent("ScrollManager").GetComponent<ScrollManager>();
        //soundLoginAccept = _refButtonLogin.GetComponent<AudioSource>();

        //soundLoginAccept = _refButtonSounds[0];
        //soundLoginDeny = _refButtonSounds[1];
    }
    private void Update()
    {
        if (!loadedInfo)
        {
            user = GetComponent("UserRequest").GetComponent<UserRequest>().user;
            if (user != null) loadedInfo = true;
        }
    }

    private void Awake()
    {
        //m_networkManager = GameObject.findObjectOfType<NetworkManager>();
    }

    public void ShowHome()
    {
        m_prdexUI.SetActive(false);
        if (loadedInfo)
        {
            //m_homeUI.GetComponent("TextUsername").GetComponent<Text>().text = user.getName();
            //m_homeUI.GetComponent("TextPuntos").GetComponent<Text>().text = user.getPoints().ToString();
            //Debug.Log(m_homeUI.GetComponent("TextPuntos").GetComponent<Text>().text);
            m_homeUI.SetActive(true);
        }
    }

    public void ShowPokedex()
    {
        m_homeUI.SetActive(false);
        if (loadedInfo) {
            sc.FillPokedex(user.getPokedex());
            m_prdexUI.SetActive(true);
        }
    }
    public void ShowRetodex()
    {
        m_homeUI.SetActive(false);
        if (loadedInfo)
        {
            sc.FillQuestiondex(user.getQuestiondex());
            m_prdexUI.SetActive(true);
        }
    }

    /*
    public void ShowJuego()
    {
        soundLoginAccept.Play();

        if (m_userLog.text == "pokeUNI" && m_passLog.text == "p0k3m0n")
        {
            //soundLoginAccept.Play();
            StartCoroutine(SmoothChangeScene());
        }
        else
        {
            //soundLoginDeny.Play();
        }
    }*/


    private IEnumerator SmoothChangeScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("World");
    }
}
