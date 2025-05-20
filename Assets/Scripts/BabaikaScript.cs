using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabaikaScript : GameMonoBehaviour
{
    public MeshRenderer mRenderer;
    public Material defMaterial;
    public Material newMaterial;
    // Start is called before the first frame update
    void Start()
    {
        mRenderer = this.GetComponentInChildren<MeshRenderer>();
        ChangeMat();
    }


    public void ChangeMat()
    {
        mRenderer.material = newMaterial;
        StartCoroutine(ShowBabaika());
    }
    IEnumerator ShowBabaika()
    {
        yield return new WaitForSeconds(2f);
        mRenderer.material = defMaterial;
    }

}
