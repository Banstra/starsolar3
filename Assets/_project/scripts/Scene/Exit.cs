using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private Vector3 _positionOnScene;
    [SerializeField] private Vector3 _rotationOnScene;
    public void ChangeScene() =>
        SceneChanger.Instance.ChangeScene(_sceneName, _positionOnScene, _rotationOnScene);
}
