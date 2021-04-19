using UnityEngine;

public class StarterScript : MonoBehaviour
{
    public GameObject player;
    public GameObject tabtostart;
    void Awake()
    {

        player.GetComponent<SizeChanger>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            player.GetComponent<AnimationController>().Walk();
            GameManager.Instance.IsPlaying = true;
            player.GetComponent<SizeChanger>().enabled = true;
            tabtostart.SetActive(false);
            this.enabled = false;
        }
    }
}
