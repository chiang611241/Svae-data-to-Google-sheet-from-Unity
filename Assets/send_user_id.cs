using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class send_user_id : MonoBehaviour
{
    //輸入用的物件 user_name 
    public GameObject usrename;
    //輸入用的物件 password
    public GameObject password;
    //輸出訊息的文字 ret
    public GameObject ret;
    private string name;
    private string pw;
    [SerializeField]
    private string BAES_URL = "https://docs.google.com/forms/d/e/1FAIpQLScnNGq3hL_52o9RW5bhn6ImRslijgneI57_91Vey0NxPh2BlQ/formResponse";

    IEnumerator Post(string name,string pw){
        WWWForm form = new WWWForm();
        form.AddField("entry.35945307",name);
        form.AddField("entry.1405218755",pw);
        byte[] rawData = form.data;
        WWW www = new WWW(BAES_URL,rawData);
        yield return www;
    }
    public void send(){
        name = usrename.GetComponent<InputField>().text;
        pw = password.GetComponent<InputField>().text;
        if(name!="" || pw !=""){
            StartCoroutine(Post(name,pw));
            usrename.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            ret.GetComponent<Text>().text = "註冊成功";
        }
        else{
            if(name=="" || pw =="")
             ret.GetComponent<Text>().text = "註冊失敗，使用者帳號或密碼不能為空白";
        }
    }

}
