using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameObject prefabMessage = default!;
    [SerializeField] GameObject gameObjectCanvas = default!;
    [SerializeField] PlayDirector playDirector = default!;
    GameObject _message = null;

    //画面に出る演出メッセージの表示
    void CreateMessage(string message)
    {
        Debug.Assert(message == null);
        _message = Instantiate(prefabMessage, Vector3.zero, Quaternion.identity,
            gameObjectCanvas.transform);
        _message.transform.localPosition = new Vector3(0, 0, 0);//画面中心に配置

        _message.GetComponent<TextMeshProUGUI>().text = message;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GameFlow");
    }
    
    private IEnumerator GameFlow()
    {
        CreateMessage("Ready?");

        yield return new WaitForSeconds(1.0f);
        Destroy(_message); _message = null;

        playDirector.EnableSpawn(true);//プレイ開始

        while (!playDirector.IsGameOver())
        {
            yield return null;
        }

        CreateMessage("Game Over");

        while (!Input.anyKey)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("TitleScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
