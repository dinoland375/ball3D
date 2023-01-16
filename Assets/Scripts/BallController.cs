using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController = null;
    [SerializeField] private GameObject ballPrefab = null;
    [SerializeField] private Animator animator;
    
    private Vector3 _cachePosition;
    private float _speedSlow = 1.5f;
    private bool _stopSpeed;

    private void Start()
    {
        _cachePosition = ballPrefab.transform.position;
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            if (playerController.speedMove > 0)
            {
                _stopSpeed = true;
            }
            if (playerController.speedMove <= 0)
            {
                _stopSpeed = false;
                playerController.speedMove = 0;
            }
        }
    }

    private void Update()
    {
        if (_stopSpeed)
        {
            playerController.speedMove  =  playerController.speedMove - (_speedSlow * Time.deltaTime);
            
        }
    }

    private void UpdateBall()
    {
        ballPrefab.transform.position = _cachePosition;
        ballPrefab.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        
        playerController.move = false;
        playerController.tap = true;
        
        animator.SetBool("UpdateBall", false);
    }
}
