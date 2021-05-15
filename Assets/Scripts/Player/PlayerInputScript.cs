using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{
    //Store a reference to main player script
    [Header("Main Script")]
    [SerializeField] internal PlayerScript PlayerScript;

    // Start is called before the first frame update
    private void Start() => PlayerScript = GetComponent<PlayerScript>();

    // Update is called once per frame
    private void Update() => Inputs();

    private void Inputs() => PlayerScript.Direction = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
    
}
