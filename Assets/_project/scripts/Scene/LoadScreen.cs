using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{
    private AsyncOperation _async;

    [SerializeField] private Image _processBar;
    [SerializeField] private GameObject _interactionText;

    [SerializeField] private TMP_Text _prompt;
    [SerializeField] private string[] _texts;
    [SerializeField] private Sprite[] _progressSprites;
    [SerializeField] private Sprite[] _mainSprites;
    [SerializeField] private Image _mainImage;

    private void Start()
    {
        var _ = Random.Range(0, 100);
        _processBar.sprite = _progressSprites[Random.Range(0, _progressSprites.Length)];
        _processBar.fillAmount = 0;

        _prompt.text = _texts[Random.Range(0, _texts.Length)];

        _mainImage.sprite = _mainSprites[Random.Range(0, _mainSprites.Length)];
    }

    private void Update()
    {
        _processBar.fillAmount = _async.progress;
        if (_async.progress != 0.9f) return;

        _processBar.fillAmount = 1;
        _interactionText.SetActive(true);

        if (Input.GetAxis(InputStrings.InteractionAxis) == 1)
            _async.allowSceneActivation = true;
    }

    public void Loading(string sceneName)
    {
        _async = SceneManager.LoadSceneAsync(sceneName);
        _async.allowSceneActivation = false;
    }
}
