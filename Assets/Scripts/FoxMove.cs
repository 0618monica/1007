using UnityEngine;

public class FoxMove : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度
    public float jumpForce = 10f; // 跳躍力
    private Rigidbody2D rb; // 2D 剛體
    private bool isGrounded; // 是否在地面上
    private bool facingRight = true; // 記錄角色當前的面向
    private int jumpCount = 0; // 記錄跳躍次數
    public int maxJumpCount = 2; // 最大跳躍次數
    private Animator animator; // 動畫控制器

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 獲取剛體組件
        animator = GetComponent<Animator>(); // 獲取動畫控制器
    }

    void Update()
    {
        // 水平移動
        float moveX = Input.GetAxisRaw("Horizontal"); // 獲取水平輸入 (A 和 D)
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // 改變角色面向
        if (moveX > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveX < 0 && facingRight)
        {
            Flip();
        }

        // 動畫控制
        animator.SetBool("AD", moveX != 0);

        // 跳躍
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // 設置跳躍速度
            jumpCount++; // 增加跳躍次數
            isGrounded = false; // 離開地面後設置為不在地面上
            Debug.Log("跳躍：" + jumpCount + " 次");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("碰觸地面");
            isGrounded = true; // 當接觸地面時設置為在地面上
            Debug.Log("跳躍次數歸零");
            jumpCount = 0; // 重置跳躍次數
        }
    }

    // 翻轉角色的方法
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1; // 翻轉角色的X軸縮放比例
        transform.localScale = scale;
    }
}
