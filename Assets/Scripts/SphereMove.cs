using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class SphereMove : MonoBehaviour
{
    private Camera camera;
    private Joystick joystick;
    public float speed;
    public float health=100f;
    public Slider healthBar;
    
    private void Start()
    {
        joystick = FindObjectOfType<Joystick>(true);
        camera = FindObjectOfType<Camera>();
        
    }
    void FixedUpdate()
    {
        Catch();
        Swipe();
        healthBar.value = health;
    }

    private void Catch()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, 0, 100));
        if (GameManager.Instance.state == State.selecting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;
                    if (hit.collider.tag == "salvageable" || hit.collider.tag == "unsalvageable")
                    {
                        transform.DOJump(hit.point, 15f, 1, 1).OnComplete(() =>
                        {
                            hit.transform.SetParent(transform);
                            GameManager.Instance.state = State.savior;
                            if (hit.transform.childCount != 0)
                            {
                                Debug.Log(hit.collider.name);
                                IsRag.Instance.noRag.SetActive(false);
                                IsRag.Instance.rag.SetActive(true);
                            }
                        });

                    }
                    
                }
            }
        }

    }
    private void Swipe()
    {
        if (GameManager.Instance.state == State.savior)
        {
            if (joystick.Vertical < 0)
            {
                transform.position += Vector3.forward * joystick.Vertical * Time.deltaTime * speed*2;
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("safeZone"))
        {
            if (transform.GetChild(0).CompareTag("salvageable"))
            {
                GameManager.Instance.salvageableObjects.Add(transform.GetChild(0).gameObject);
            }
            if (transform.GetChild(0).CompareTag("unsalvageable"))
            {
                health-=33.4f;
                if (health < 0)
                {
                    StartCoroutine(DelayLevelFailPanel());
                    GameManager.Instance.state = State.finish;
                }
                
            }  
            GameManager.Instance.state = State.selecting;
            transform.GetChild(0).SetParent(null);
            transform.localScale = Vector3.zero;
            transform.DOScale(Vector3.one * 2, .5f).OnStart(() => transform.position = new Vector3(0f, 18f, 6f));


            
        }
        
        
    }
    IEnumerator DelayLevelFailPanel()
    {
        yield return new WaitForSeconds(2.0f);
        UIManager.Instance.Levelfail();
    }
}
