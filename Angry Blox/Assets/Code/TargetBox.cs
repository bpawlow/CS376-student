using UnityEngine;

public class TargetBox : MonoBehaviour
{
    /// <summary>
    /// Targets that move past this point score automatically.
    /// </summary>
    public static float OffScreen;

    /// <summary>
    /// Shows whether the target is already accounted for in the score
    /// </summary>
    public bool alreadyScored = false; 

    internal void Start()
    {
        OffScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 100, 0, 0)).x;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Scored();
        }
    }

    internal void Update()
    {
        if (transform.position.x > OffScreen)
            Scored();
    }

    private void Scored()
    {
        var objSprRend = GetComponent<SpriteRenderer>();
        var objRB2D = GetComponent<Rigidbody2D>();
        objSprRend.color = Color.green;
        if (!alreadyScored)
        {
            ScoreKeeper.AddToScore((float)objRB2D.mass);
            alreadyScored = true;
        }
    }
}
