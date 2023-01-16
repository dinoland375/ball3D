using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    [SerializeField] private Material newMaterial = null;
    [SerializeField] private Animator animator = null;

    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            animator.SetBool("PlayAnim", true);
            
            GetComponent<MeshRenderer>().material = newMaterial;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            _playerController.moveToFinish = true;
        }
    }

    private void BallAnimation()
    {
        GameObject.Find("Ball").GetComponent<Animator>().SetBool("UpdateBall", true);
        Destroy(gameObject);
    }
}
