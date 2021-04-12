using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
            Instance = this;
        
    }

    public Canvas StartCavnas;
    public Canvas GameCanvas;

    public bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        GameCanvas.gameObject.SetActive(false);
        if (SkillSystem.Instance.Playing)
        {
            GameCanvas.gameObject.SetActive(true);
            StartCavnas.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space"))
        {
            GameCanvas.gameObject.SetActive(true);
            StartCavnas.gameObject.SetActive(false);
            isPlaying = true;
            SkillSystem.Instance.Playing = true;
        }
    }
}
