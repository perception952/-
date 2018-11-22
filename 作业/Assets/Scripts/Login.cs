using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour {

	private string editUsername;
	private string editPassword;
	private string editShow;

	// Use this for initialization
	void Start () {
		editShow = "请您输入正确的用户名与密码";
		editUsername = "请输入用户名";
		editPassword = "请输入密码";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Label(new Rect(10, 10, Screen.width, 30), editShow);

		if (GUI.Button(new Rect(10, 120, 100, 50),"登录")){
			if (editUsername == "100" && editPassword == "100"){
				Application.LoadLevel(1);
			}
		}

		GUI.Label(new Rect(10, 40, 50, 30), "用户名");
		GUI.Label(new Rect(10, 80, 50, 30), "密码");

		editUsername = GUI.TextField (new Rect(60, 40, 200, 30), editUsername, 15);
		editPassword = GUI.PasswordField(new Rect(60, 80, 200, 30), editPassword, "*"[0],15);
	}

}
