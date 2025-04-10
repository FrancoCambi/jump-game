using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalLogic : MonoBehaviour
{
    [SerializeField]
    private IntSO dataToKeep;

    public GameObject portalText;
    public Camera mainCamera;
    public GameObject transition;
    public FruitManager fruitManager;
    public EnemiesManager enemiesManager;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D capsuleCollider2;
    public void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        fruitManager = FindObjectOfType<FruitManager>();
        enemiesManager = FindObjectOfType<EnemiesManager>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        capsuleCollider2 = gameObject.GetComponent<CapsuleCollider2D>();
    }

    public void TryOpenPortal()
    {
        Invoke(nameof(TryOpenPortalAux), 0.3f);
    }

    private void TryOpenPortalAux()
    {
        if (fruitManager.AllFruitsCollected() && enemiesManager.AllEnemiesKilled())
        {
            Instantiate(portalText, mainCamera.transform.position, Quaternion.identity, mainCamera.transform);
            spriteRenderer.enabled = true;
            capsuleCollider2.enabled = true;
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transition.SetActive(true);
            dataToKeep.respawnLife = dataToKeep.life;
            Invoke(nameof(NextScene), 1.2f);

        }
    }

    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
