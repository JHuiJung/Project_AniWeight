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
        // ��ġ �Է��� �ִ��� Ȯ��
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // ��ġ ���� �� Raycast�� ������Ʈ�� �浹 Ȯ��
                    RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

                    if (hit.collider != null)
                    {
                        // ��ġ�� ������Ʈ�� AniBall ��ũ��Ʈ�� ���� ��츸 �巡�� ����
                        selectedAniBall = hit.collider.GetComponent<AniBall>();
                        if (selectedAniBall != null)
                        {
                            isDragging = true;
                            
                            offset = (Vector2)selectedAniBall.transform.position - touchPosition;
                        }
                    }
                    break;

                case TouchPhase.Moved:
                    // �巡�� ���� �� AniBall ������Ʈ�� �̵�
                    if (isDragging && selectedAniBall != null)
                    {
                        selectedAniBall.transform.position = touchPosition + offset;
                    }
                    break;

                case TouchPhase.Ended:
                    // ��ġ�� ������ �巡�� ���� ����
                    isDragging = false;
                    selectedAniBall = null;
                    break;
            }
        }
    }

    void HandleMouseInput()
    {
        // ���콺 Ŭ�� �� Raycast�� ������Ʈ�� �浹 Ȯ��
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                // Ŭ���� ������Ʈ�� AniBall ��ũ��Ʈ�� ���� ��츸 �巡�� ����
                selectedAniBall = hit.collider.GetComponent<AniBall>();
                if (selectedAniBall != null)
                {
                    isDragging = true;
                    selectedAniBall.img_Transform.DOScale(new Vector3(1.5f,1.5f,1f),0.25f);
                    offset = (Vector2)selectedAniBall.transform.position - mousePosition;
                }
            }
        }

        // ���콺�� �����̴� ���� AniBall ������Ʈ �̵�
        if (Input.GetMouseButton(0) && isDragging && selectedAniBall != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedAniBall.transform.position = mousePosition + offset;
        }

        // ���콺 ��ư�� ���� �巡�� ���� ����
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
