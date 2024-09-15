using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AniBall : MonoBehaviour
{
    public bool isAttached = false;
    public float Weight = 1f;
    Rigidbody2D rigidBody;
    Collider2D coll2D;

    public Transform img_Transform;

    private bool isDragging = false;
    private Vector2 offset;
    private AniBall selectedAniBall;

    void Start()
    {
        img_Transform = transform.GetChild(0);

        rigidBody = GetComponent<Rigidbody2D>();
        coll2D = GetComponent<Collider2D>();

        Weight = rigidBody.mass;

        rigidBody.isKinematic = true;
        coll2D.isTrigger = true;
    }

    void Update()
    {
        // Android ---
        //HandleTouchInput();

        // PC -----
        HandleMouseInput();
    }

    void HandleTouchInput()
    {
        // 터치 입력이 있는지 확인
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // 터치 시작 시 Raycast로 오브젝트와 충돌 확인
                    RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

                    if (hit.collider != null)
                    {
                        // 터치한 오브젝트가 AniBall 스크립트를 가진 경우만 드래그 가능
                        selectedAniBall = hit.collider.GetComponent<AniBall>();
                        if (selectedAniBall != null)
                        {
                            isDragging = true;
                            
                            offset = (Vector2)selectedAniBall.transform.position - touchPosition;
                        }
                    }
                    break;

                case TouchPhase.Moved:
                    // 드래그 중일 때 AniBall 오브젝트를 이동
                    if (isDragging && selectedAniBall != null)
                    {
                        selectedAniBall.transform.position = touchPosition + offset;
                    }
                    break;

                case TouchPhase.Ended:
                    // 터치가 끝나면 드래그 상태 해제
                    isDragging = false;
                    selectedAniBall = null;
                    break;
            }
        }
    }

    void HandleMouseInput()
    {
        // 마우스 클릭 시 Raycast로 오브젝트와 충돌 확인
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                // 클릭한 오브젝트가 AniBall 스크립트를 가진 경우만 드래그 가능
                selectedAniBall = hit.collider.GetComponent<AniBall>();
                if (selectedAniBall != null)
                {
                    isDragging = true;
                    selectedAniBall.img_Transform.DOScale(new Vector3(1.5f,1.5f,1f),0.25f);
                    offset = (Vector2)selectedAniBall.transform.position - mousePosition;
                }
            }
        }

        // 마우스를 움직이는 동안 AniBall 오브젝트 이동
        if (Input.GetMouseButton(0) && isDragging && selectedAniBall != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedAniBall.transform.position = mousePosition + offset;
        }

        // 마우스 버튼을 떼면 드래그 상태 해제
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            if(selectedAniBall != null)
            {
                selectedAniBall.img_Transform.DOScale(new Vector3(1f, 1f, 1f), 0.25f);
            }
            selectedAniBall = null;
        }
    }

    public void Play()
    {
        rigidBody.isKinematic = false;
        coll2D.isTrigger = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isAttached = true;
        AniBall ab = collision.gameObject.GetComponent<AniBall>();
        if (ab != null)
        {
            ab.isAttached = true;
        }
        //Debug.Log(collision.gameObject.name);
    }
}
