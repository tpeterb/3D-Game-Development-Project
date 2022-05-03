using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlimeAttackController : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Animator animator;
    public TextMeshProUGUI hp;
    public Animator playerAnimator;

    public GameController gameController;
    public static Transform startTransform;

    public Vector3 originalPosition;
    public Quaternion originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        startTransform = transform;
        gameController = GameObject.FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToOriginalPosition()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.LookAt(player.transform);
            animator.SetTrigger("Attack_trig");
            PlayerController.hp -= 10;
            hp.SetText("HP: " + PlayerController.hp);
        }
        if (gameController.IsGameOver())
        {
            GameController.isGameOver = true;
            playerAnimator.SetBool("Death", true);
            gameController.GameOver();
        }
    }
}
