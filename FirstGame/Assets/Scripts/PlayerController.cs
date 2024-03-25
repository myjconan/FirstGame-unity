using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //[SerializeField]
    private Animator anim;
    private Rigidbody2D rb;
    [Tooltip("参数调节")]
    public float jumpforce;
    public float speed;
    [Space]
    [Tooltip("关联层")]
    public LayerMask ground;
    public LayerMask enemy;
    [Space]
    [Tooltip("身体判定")]
    public Collider2D coll_circle;
    public Collider2D coll_box;
    public Collider2D coll_enemy;
    public Transform ceilingCheck;
    [Space]
    [Tooltip("状态判定")]
    private bool IsHurt;
    private bool Isdead;
    private int jumpTime=2;
    [Space]
    [Tooltip("Joystick")]
    public bool IsJoystick;
    public VariableJoystick variableJoystick;
    public Button a;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Isdead = false;
    }

    void FixedUpdate()

    {
        if (!Isdead)
        {
            SwitchAnim();
            if (!IsHurt)
            {
                Movement();
            }

        }
    }
    private void Update()
    {
        if (!Isdead)
        {
            if (!IsHurt)
            {
                if (!IsJoystick)
                {
                    Jump();
                }
                Crouch();
            }
        }
    }

    void Movement()
    {
        float facedirection=0, horizontalmove=0f;
        //键盘控制
        if (!IsJoystick)
        {
            facedirection = Input.GetAxisRaw("Horizontal");
            horizontalmove = Input.GetAxis("Horizontal");
        }
        //虚拟摇杆
        else
        {
            if (variableJoystick.Horizontal > 0)
            {
                facedirection = 1;
            }
            if (variableJoystick.Horizontal == 0)
            {
                facedirection = 0;
            }
            if (variableJoystick.Horizontal < 0)
            {
                facedirection = -1;
            }
            horizontalmove = variableJoystick.Horizontal;
        }
        //角色站立与跑动动画切换
        anim.SetFloat("running", Mathf.Abs(facedirection));
        //角色移动
        if (horizontalmove != 0)
        {
            rb.velocity = new Vector2(horizontalmove * speed * Time.fixedDeltaTime, rb.velocity.y);
        }
        //角色朝向
        if (facedirection != 0)
        {
            transform.localScale = new Vector3(facedirection, 1, 1);

        }
        Crouch();
    }
    //角色跳跃
    public void Jump()
    {
        if (coll_circle.IsTouchingLayers(ground))
        {
            jumpTime = 0;
        }
        if (!IsJoystick)
        {
            if (Input.GetButtonDown("Jump") && jumpTime < 1)
            {
                jumpTime += 1;
                SoundManager.SoundManagerPack.JumpAudio_Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                anim.SetBool("jumping", true);
                anim.SetBool("falling", false);
                anim.SetBool("hurt", false);
            }
        }
        else
        {
            if (jumpTime < 2)
            {
                jumpTime += 1;
                SoundManager.SoundManagerPack.JumpAudio_Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                anim.SetBool("jumping", true);
                anim.SetBool("falling", false);
                anim.SetBool("hurt", false);
            }
        }
    }
    
    //下蹲
    void Crouch()
    {
        if (!Physics2D.OverlapCircle(ceilingCheck.position, 0.2f, ground))
        {
            if (!IsJoystick)
            {
                if (Input.GetButton("Crouch"))
                {
                    anim.SetBool("crouching", true);
                    coll_box.enabled = false;
                }
                else
                {
                    anim.SetBool("crouching", false);
                    coll_box.enabled = true;
                }
            }
            else
            {
                if (variableJoystick.Vertical<-0.3)
                {
                    anim.SetBool("crouching", true);
                    coll_box.enabled = false;
                }
                else
                {
                    anim.SetBool("crouching", false);
                    coll_box.enabled = true;
                }
            }
        }
    }
    void SwitchAnim()
    {
        if (!IsHurt)
        {
            if (rb.velocity.y < 0.1f && !coll_circle.IsTouchingLayers(ground))
            {
                anim.SetBool("falling", true);
                anim.SetBool("jumping", false);
            }
            else if (coll_circle.IsTouchingLayers(ground) && !anim.GetBool("crouching"))
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", false);
            }
        }
        else
        {
            anim.SetBool("hurt", true);
            anim.SetFloat("running", 0);
            if (Mathf.Abs(rb.velocity.x) < 0.1f)
            {
                anim.SetBool("hurt", false);
                IsHurt = false;
            }
        }
    }
    //进入
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //收集物品
        if (collision.CompareTag("Collection"))
        {
            Collection collection = collision.gameObject.GetComponent<Collection>();
            collection.Gotton();
        }
    }
    //碰撞器
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (coll_enemy.IsTouchingLayers(enemy))
        {
            //消灭敌人
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.Death();
                rb.velocity = new Vector2(rb.velocity.x, 0.8f * jumpforce);
            }
        }
        else
        {
            //受伤
            if (collision.gameObject.CompareTag("Enemy"))
            {
                IsHurt = true;
                if (transform.position.x < collision.gameObject.transform.position.x)
                {
                    SoundManager.SoundManagerPack.HurtAudio_Play();
                    rb.velocity = new Vector2(-4, 0.7f * jumpforce);
                }
                else if (transform.position.x > collision.gameObject.transform.position.x)
                {
                    SoundManager.SoundManagerPack.HurtAudio_Play();
                    rb.velocity = new Vector2(4, 0.7f * jumpforce);
                }
            }
        }
        //死亡重置
        if (collision.gameObject.CompareTag("Deadline"))
        {
            SoundManager.SoundManagerPack.AudioSource_BGM.enabled = false;
            SoundManager.SoundManagerPack.FallToDeathAudio_Play();
            Isdead = true;
            Invoke("GameOverAudio_Play", 2f);
            Invoke("Restart",6f);
        }
    }
    public void GameOverAudio_Play()
    {
        SoundManager.SoundManagerPack.GameOverAudio_Play();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}