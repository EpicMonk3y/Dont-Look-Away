using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class SeeEnemy : MonoBehaviour
{
    public GameObject playerCam;
    public GameObject enemyCam;
    public Animator enemyAnimator;
    public AudioController audioController;

    public GameObject currentHitObject;
    public Blinking blinking;
    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;
    private Vector3 origin;
    private Vector3 direction;

    private float currentHitDistance;

    public NavMeshAgent ai;
    public GameObject enemy;
    Vector3 dest;
    public float aiSpeed;

    public Flashlight flashlight;
    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.activeInHierarchy)
        {
            origin = transform.position;
            direction = transform.forward;

            RaycastHit hit;

            if (blinking.isPlaying == false && Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
            {
                currentHitObject = hit.transform.gameObject;
                currentHitDistance = hit.distance;
                ai.speed = 0;
                ai.SetDestination(enemy.transform.position);
                ai.transform.LookAt(transform.position);
            }
            else if(blinking.isPlaying || !Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
            {
                ai.speed = aiSpeed;
                dest = transform.position;
                ai.destination = dest;
                currentHitObject = null;
            }
        }

        if (Vector3.Distance(transform.position, enemy.transform.position) <= 2){
            playerCam.SetActive(false);
            enemyCam.SetActive(true);
            enemyAnimator.SetTrigger("jumpscare");
            ai.speed = 0;
            audioController.PlayJumpScareFinalSFX();
            flashlight.lifetime = 10;
            flashlight._light.enabled = true;
            ui.SetActive(false);
            StartCoroutine(waitForAnimFinish());
        }
        
    }

    IEnumerator waitForAnimFinish()
    {
        yield return new WaitForSeconds(4);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);
    }
}
