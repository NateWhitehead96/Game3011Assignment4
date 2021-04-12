using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    public static SkillSystem Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
            Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public int Level = 0;
    public bool Playing = false;
    
    // Start is called before the first frame update
    private void Start()
    {
        print(Level);
    }
}
