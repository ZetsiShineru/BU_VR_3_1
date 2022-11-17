using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PretoAnimationController : MonoBehaviour
{
    public Animation anim;
    public AnimationClip[] clips;//0 = idel 1 = walk 2 = run
    private int numClipPlaying = 0;
    [Range (0,2)]public int numClip = 0;
    public float speed = 1;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }
    private void Update()
    {
        AnimPlay(numClip);
    }
    private void AnimPlay(int num)//0 = idel 1 = walk 2 = run
    {
        if (numClipPlaying != num)
        {
            Debug.Log(num);
            anim.clip = clips[num];
            anim["Running"].speed = speed;
            anim.Play();
            numClipPlaying = num;
            return;
        }
        return;
    }
}
