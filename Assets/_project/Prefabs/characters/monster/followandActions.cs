using UnityEngine;

public class follow : MonoBehaviour
{


    [SerializeField] private GameObject Player;
    [SerializeField] private float Speed = 1.5f;

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
    }


}
