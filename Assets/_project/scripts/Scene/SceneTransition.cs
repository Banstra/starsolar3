using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    protected static string _sceneName;
    protected static Vector3 _position;
    protected static Vector3 _rotation;
    private const string _transitSceneName = "TransitScene";

    [SerializeField] private GameObject _crossFade;
    [SerializeField] private LoadScreen _loadScreen;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == _transitSceneName)
        {
            _crossFade.SetActive(false);
            _loadScreen.Loading(_sceneName);
            _loadScreen.gameObject.SetActive(true);
        }
        else
        {
            _crossFade.SetActive(true);
            if (_position != Vector3.zero)
                SceneChanger.Instance.SetStartPosition(_position, _rotation);
        }
    }

    public void Transit(string sceneName, Vector3 position, Vector3 rotation)
    {
        _sceneName = sceneName;
        _position = position;
        _rotation = rotation;

        SceneManager.LoadScene(_transitSceneName);
    }
}
