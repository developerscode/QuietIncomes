//Global Variables Declaration

var ck_name = /^[A-Za-z0-9 ]{3,20}$/;
var ck_email = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
var ck_username = /^[A-Za-z0-9_]{1,20}$/;
var ck_password = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{6,}$/;
var echo = "$ &`:<>[]{}\"+#%@/;=?\^|~',";
var mylistkey = "Basic_Details";
var mylistval = "Complexion";

//Login Page Valdation for valida user
$(document).ready(function () {
    $("#btnLogin").click(function () {

        $(':input').inputWatermark();
        var uname = $("#txtUserName").val();
        var pword = $("#txtPassword").val();

        if (uname == "Username" || uname == null || uname == "") {
            document.getElementById('status').innerHTML = "Please Enter Username";
            $("#txtUserName").focus();
            return false;
        }
        else if (pword == "Password" || pword == null || pword == "") {
            document.getElementById('status').innerHTML = "Please Enter Password";
            $("#txtPassword").focus();
            return false;
        }
        else {
            NormalUser();
        }
    });

    $("#btnGoogle").click(function () {
        GoogleUser();
    });
    $("#btnLinkedin").click(function () {
        LinkedinUser();
    });
    $("#btnFacebook").click(function () {
        FacebookUser();
    });
});
function NormalUser() {
    alert("login");
    window.location = 'inbox.html';
}
function LinkedinUser()  {
    window.location = "linkedin.html";
}

function GoogleUser() {
    window.location = "google.html";
}
function FacebookUser() {
    window.location = "facebook.html";
}
////////////////////////////////////////////////////////////////////////////////////////////////////////

//Logout Page
function logout() {
    localStorage.clear();
    window.location = 'Login.html';
}
