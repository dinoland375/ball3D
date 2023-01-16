using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController: MonoBehaviour
{
    [SerializeField] private Transform waterVolume;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject loseMenu;
    [SerializeField] private Transform finish;
    [SerializeField] private Image loadBarImage;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private Vector3 max;
    [SerializeField] private Vector3 min;
    [SerializeField] private Animator animatorFinish;

    public GameObject touchPanel;
    public float speedMove = 3f;
    public bool move;
    public bool tap = true;
    public bool moveToFinish;
    
    private bool _created;
    private RaycastHit _hit;
    private RaycastHit[] _hits;

    private void Update()
    {
        if (Input.touchCount == 1) //TOUCH
        {
            Touch touch0 = Input.GetTouch(0);

            if (touch0.phase == TouchPhase.Began)
            {
                PointerEventData clickData = new PointerEventData (EventSystem.current);
                clickData.position = Input.mousePosition;
                List<RaycastResult> results = new List<RaycastResult> ();
                EventSystem.current.RaycastAll (clickData, results);
                if (results.Count != 0)
                    return;
                
                Ray ray = Camera.main.ScreenPointToRay(touch0.position);
                
                
                _hits = Physics.RaycastAll(ray, 10000.0f);

                if (_hits[0].transform.CompareTag("Player"))
                {
                    if (tap)
                    {
                        move = false;
                        _created = true;
                    }
                }
            }

            if (touch0.phase == TouchPhase.Ended)
            {
                if (_hits[0].transform.CompareTag("Player"))
                {
                    if (tap)
                    {
                        _created = false;
            
                        speedMove = 3f;
                        move = true;
            
                        tap = false;
                    }
                }
            }
        }
    }
    
    private void FixedUpdate()
    {
        loadBarImage.fillAmount = Mathf.Clamp(waterVolume.transform.localScale.y / max.y, 0f, 100f);
        
        if (_created)
        {
            ball.transform.localScale = Vector3.Lerp(ball.transform.localScale, max, speed * Time.deltaTime);
            waterVolume.localScale = Vector3.Lerp(waterVolume.localScale, min, speed * Time.deltaTime);
        }
        
        if (move)
        {
            ball.transform.position = 
                Vector3.MoveTowards(ball.transform.position, finish.position, speedMove * Time.deltaTime);
        }

        if (waterVolume.localScale.y < 1.2f)
        {
            loseMenu.SetActive(true);
            loseMenu.GetComponent<Animator>().SetBool("Lose", true);
            move = false;
            tap = false;
            moveToFinish = false;
            _created = false;
        }
        
        Ray checkRay = new Ray(transform.position, Vector3.forward);
        
        if (Physics.Raycast(checkRay, out _hit, 10000))
        {
            if (Vector3.Distance(transform.position, finish.position) < 9)
            {
                moveToFinish = false;
                tap = false;
                animatorFinish.SetBool("Finish", true);
            }
            else
            {
                if (_hit.collider.CompareTag("Finish") && _hit.collider.CompareTag("Obstacle") == false)
                    moveToFinish = true;
            }
        }
        
        if (moveToFinish)
        {
            transform.position = Vector3.MoveTowards(transform.position, finish.position, 3 * Time.deltaTime);
        }
    }
    
    private void OnMouseDown()
    {
        if (tap)
        {
            move = false;
            _created = true;
        }
    }
    
    private void OnMouseUp()
    {
        if (tap)
        {
            _created = false;
            
            speedMove = 3f;
            move = true;
            
            tap = false;
        }
    }
}
