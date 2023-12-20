using UnityEngine;

public class spriteBillboard : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool freezeXZAxis = true;

    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (freezeXZAxis)
        {
            transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
        }
        else
        {
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}
