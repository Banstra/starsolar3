using UnityEngine;

public class SavedObject : MonoBehaviour
{
    public ObjectData GetData() =>
        new()
        {
            Position = transform.position,
            Rotation = transform.rotation.eulerAngles,
            Scale = transform.localScale,
            IsActive = gameObject.activeSelf
        };

    public void LoadData(ObjectData data)
    {
        transform.SetPositionAndRotation(data.Position, Quaternion.Euler(data.Rotation));
        transform.localScale = data.Scale;
        gameObject.SetActive(data.IsActive);
    }
}
