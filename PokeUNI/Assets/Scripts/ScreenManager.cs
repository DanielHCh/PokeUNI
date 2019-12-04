using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private InputField m_userInput = null;
    [SerializeField] private InputField m_emailInput = null;
    [SerializeField] private InputField m_pass1Input = null;
    [SerializeField] private InputField m_pass2Input = null;
    [SerializeField] private Text m_textoError = null;
    [SerializeField] private GameObject m_registerUI = null;
    [SerializeField] private GameObject m_loginUI = null;
    [SerializeField] private GameObject m_optUI = null;
    [SerializeField] private GameObject m_logBG = null;
    [SerializeField] private GameObject m_gameBG = null;
    [SerializeField] private InputField m_userLog = null;
    [SerializeField] private InputField m_passLog = null;

    [SerializeField]
    private GameObject _refButtonLogin;

    [SerializeField]
    private AudioSource[] _refButtonSounds;

    private AudioSource soundLoginAccept;
    private AudioSource soundLoginDeny;

    private NetworkManager m_networkManager = null;


    private void Start()
    {
        soundLoginAccept = _refButtonLogin.GetComponent<AudioSource>();

        //soundLoginAccept = _refButtonSounds[0];
        //soundLoginDeny = _refButtonSounds[1];
    }

    private void Awake()
    {
        //m_networkManager = GameObject.findObjectOfType<NetworkManager>();
    }

    public void SubmitLogin()
    {
        if (m_userInput.text == "" || m_emailInput.text == "" || m_pass1Input.text == "" || m_pass2Input.text == "")
        {
            m_textoError.text = "Uno o más campos están vacíos. Intente nuevamente.";
            return;
        }
        else
        {
            if (m_pass1Input.text == m_pass2Input.text)
            {
                m_textoError.text = "Procesando...";
                m_networkManager.CrearUsuario(m_userInput.text, m_emailInput.text, m_pass1Input.text, delegate(Response response)
                {
                    m_textoError.text = response.mensaje;
                });
            }
            else
            {
                m_textoError.text = "Las contraseñas no coinciden. Intente nuevamente.";
            }
        }
    }

    public void ShowLogin()
    {
        m_loginUI.SetActive(true);
        m_logBG.SetActive(true);
        m_registerUI.SetActive(false);
        m_gameBG.SetActive(false);
        m_optUI.SetActive(false);

    }

    public void ShowRegistro()
    {
        m_registerUI.SetActive(true);
        m_logBG.SetActive(true);
        m_loginUI.SetActive(false);
        m_gameBG.SetActive(false);
        m_optUI.SetActive(false);
    }

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
    }

    private IEnumerator SmoothChangeScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("UserProfile");
    }
}
