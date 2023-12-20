using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance { get; private set; }

    [SerializeField] private SceneTransition _transit;

    private void Start() =>
        Instance = this;

    public void ChangeScene(string sceneName, Vector3 position, Vector3 rotation) =>
        _transit.Transit(sceneName, position, rotation);

    public void SetStartPosition(Vector3 position, Vector3 rotation)
    {
        transform.position = position;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
