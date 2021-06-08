using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    // サンプル画像さいとのURI
    const string URI = "https://picsum.photos/200";
    MeshRenderer canvasRenderer;

    void Awake()
    {
        canvasRenderer = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        StartCoroutine("SetImage");
    }

    // canvasにダウンロードした画像をセットするコルーチン
    IEnumerator SetImage()
    {
        UnityWebRequest WWW = UnityWebRequestTexture.GetTexture(URI);

        yield return WWW.SendWebRequest();

        if (WWW.isNetworkError || WWW.isHttpError)
        {
            Debug.Log(WWW.error);
        }
        else
        {
            canvasRenderer.material.mainTexture = ((DownloadHandlerTexture)WWW.downloadHandler).texture;
        }
    }
}
