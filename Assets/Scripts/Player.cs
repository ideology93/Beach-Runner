using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Score score;

    [SerializeField] private PlayerController pc;

    public GameObject coin;

    public GameObject ui;
    public GameObject img;
    private Transform currentImgPos;
    public GameManager gm;
    private GameObject obj;
    public AudioSource audioSource;
    public AudioClip clip;

    void Awake()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        string tag = hit.gameObject.tag;

        if (tag == "Obstacle")
        {
            if (pc.isGrounded && transform.position.x < 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z), 3);
                pc.isDead = true;
                GameManager.isGameEnded = true;
                pc.animate.SetBool("isDead", true);
            }
            else if (pc.isGrounded && transform.position.x > 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y - 90, transform.rotation.z), 3);
                pc.isDead = true;
                GameManager.isGameEnded = true;
                pc.animate.SetBool("isDead", true);
            }
            pc.isDead = true;
            GameManager.isGameEnded = true;
            pc.animate.SetBool("isDead", true);
            Rigidbody bodie = hit.collider.attachedRigidbody;
            Rigidbody[] body = hit.gameObject.GetComponentsInChildren<Rigidbody>();
            for (int i = 0; i < body.Length; i++)
            {
                Vector3 pushDir = new Vector3(hit.moveDirection.x, 0.2f, hit.moveDirection.z);
                body[i].constraints = RigidbodyConstraints.None;
                body[i].velocity = pushDir * 4;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            
            audioSource.PlayOneShot(clip);
            Destroy(other.gameObject); // Or whatever way you want to remove the coin.
            CreateCoinTwo();
            Vector3 pos3d = transform.position;
            Vector2 pos2d = Camera.main.WorldToScreenPoint(pos3d);
            score.IncreaseScore();
            StartCoroutine(MoveCoin(currentImgPos, pos2d));

        }
        if (other.tag == "Finish")
        {
            gm.WinLevel();
        }
    }

    public void CreateCoinTwo()
    {
        obj = Instantiate(img) as GameObject;
        obj.transform.SetParent(ui.transform, false);
        obj.transform.position = new Vector3(Screen.width / 2 + 60, Screen.height / 2 + 100, transform.position.z + 4);
        currentImgPos = obj.transform;
    }
    public IEnumerator MoveCoin(Transform startPos, Vector2 endPos)
    {
        float time = 0;
        while (time < 1)
        {
            time += 1 * Time.deltaTime;
            startPos.position = Vector3.Lerp(startPos.transform.position, img.transform.position, time);
            yield return new WaitForEndOfFrame();
        }

    }

}
