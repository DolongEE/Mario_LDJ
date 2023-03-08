using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CtrlPlayer : MonoBehaviour
{
    public bool isDie;

    private AudioSource audioSource;    
    private Animator anim;
    private Rigidbody2D rigid;
    private bool dieCount;
    private Renderer rend;
    private float playerPos;

    [HideInInspector]
    public bool dirRight = true;

    [HideInInspector]
    public bool jump = false;
    public float jumpForce = 1500f;
    public AudioClip jumpSound;

    public float moveForce = 300f;
    public float maxSpeed = 5f;
    public float maxSpeed2 = 10f;

    public AudioClip dieSound;

    public int gameLife;
    public Image marioLife;
    public Text mariolife;
    public Image endGame;
    public GameObject restart;
    public TimeManage timecount;

    public bool end;
    bool check = true;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        gameLife = 3;
    }
    private void Start()
    {
        end = false;
        isDie = false;
        marioLife.gameObject.SetActive(false);
        endGame.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (!isDie)
        {
            float h = Input.GetAxis("Horizontal");
            anim.SetFloat("Speed", Mathf.Abs(h));

            if (Input.GetKey(KeyCode.X))
            {
                if (h * rigid.velocity.x < maxSpeed2)
                    rigid.AddForce(Vector2.right * h * moveForce);

                if (Mathf.Abs(rigid.velocity.x) > maxSpeed2)
                    rigid.velocity = new Vector2(Mathf.Sign(rigid.velocity.x) * maxSpeed2, rigid.velocity.y);
            }
            else
            {
                if (h * rigid.velocity.x < maxSpeed)
                    rigid.AddForce(Vector2.right * h * moveForce);

                if (Mathf.Abs(rigid.velocity.x) > maxSpeed)
                    rigid.velocity = new Vector2(Mathf.Sign(rigid.velocity.x) * maxSpeed, rigid.velocity.y);
            }

            if (h > 0 && !dirRight && anim.GetBool("Jump") == false)
                Flip();
            else if (h < 0 && dirRight && anim.GetBool("Jump") == false)
                Flip();

            if (Input.GetButtonDown("Jump"))
            {
                if (!jump)
                {
                    jump = true;
                    anim.SetBool("Jump", true);
                    audioSource.clip = jumpSound;
                    audioSource.Play();

                    rigid.AddForce(new Vector2(0f, jumpForce));
                }
            }
        }

        if (anim.GetBool("Die"))
        {
            isDie = true;
            if (!dieCount)
            {
                if (transform.position.y > playerPos + 1f)
                {
                    audioSource.clip = dieSound;
                    audioSource.Play();
                    dieCount = true;
                }
                rigid.velocity = new Vector2(0f, transform.localScale.y * 10f);
                this.gameObject.layer = LayerMask.NameToLayer("PlayerDie");
            }
            else
            {
                rigid.AddForce(new Vector2(0f, transform.localScale.y * -10f));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tile" || collision.gameObject.tag == "Stair")
        {
            jump = false;
            anim.SetBool("Jump", false);
        }
        if(anim.GetBool("KillEverything"))
        {
            this.gameObject.layer = LayerMask.NameToLayer("NoTouch");
            if (collision.gameObject.tag == "Monster")
            {
                Destroy(collision.gameObject);
            }
            Invoke("NoTouchTime", 9f);
        }

        if (collision.gameObject.tag == "Monster" || collision.gameObject.name == "DeadZone")
        {
            if (anim.GetInteger("countLife") == 2 || anim.GetInteger("countLife") == 3)
            {
                this.gameObject.layer = LayerMask.NameToLayer("NoTouch");
                anim.SetTrigger("Damage");
                anim.SetInteger("countLife", 1);
                StartCoroutine(NoTouchState());
            }
            else
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        anim.SetBool("Die", true);
        isDie = true;
        playerPos = transform.position.y;
        if(check)
        {
            check = false;
            gameLife -= 1;
        }

        if (gameLife <= 0)
        {
            StartCoroutine(EndGame());
        }
        else
        {
            StartCoroutine(ContinueGame());
        }
    }

    void NoTouchTime()
    {
        anim.SetBool("KillEverything", false);
        this.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    void Flip()
    {
        dirRight = !dirRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    IEnumerator NoTouchState()
    {
        rend.material.color = new Color(1, 1, 1, 0.5f);
        for (int i = 0; i < 15; i++)
        {
            yield return new WaitForSeconds(0.1f);
            rend.material.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.1f);
            rend.material.color = new Color(1, 1, 1, 0.5f);
        }
        rend.material.color = new Color(1, 1, 1, 1);
        this.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    IEnumerator ContinueGame()
    {
        yield return new WaitForSeconds(3.0f);
        rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        anim.SetBool("Die", false);
        anim.SetTrigger("Restart");
        this.gameObject.layer = LayerMask.NameToLayer("Player");
        marioLife.gameObject.SetActive(true);
        mariolife.text = gameLife.ToString();
        yield return new WaitForSeconds(3.0f);
        marioLife.gameObject.SetActive(false);
        gameObject.transform.position = restart.transform.position;
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
        dieCount = false;
        isDie = false;
        timecount.timeCount.text = timecount.MaxTime.ToString();
        timecount.countDown = timecount.MaxTime;
        check = true;

        yield return null;
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3.0f);
        endGame.gameObject.SetActive(true);
        end = true;

        yield return null;
    }
}
