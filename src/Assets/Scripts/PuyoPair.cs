using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuyoPair : MonoBehaviour
{
    [SerializeField] PuyoController[] puyos = { default!, default! };

    public void SetPuyoType(PuyoType axis, PuyoType child)
    {
        puyos[0].SetPuyoType(axis);
        puyos[1].SetPuyoType(child);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
