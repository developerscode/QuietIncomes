//Global Variables Declaration


function LinkedinUser() {
    window.location = 'linkedin.html';
}
function GoogleUser() {
    window.location = 'google.html';
}
function FacebookUser() {
    window.location = 'facebook.html';
}
function NormalUser() {
    $(':input').inputWatermark();
    var uname = $("#txtUserName").val();
    var pword = $("#txtPassword").val();

    if (uname == "Username" || uname == null || uname == "") {
        alert("uname");
        document.getElementById('status').innerHTML = "Please Enter Username";
        $("#txtUserName").focus();
        return false;
    }
    else if (pword == "Password" || pword == null || pword == "") {
        alert("pwd");
        document.getElementById('status').innerHTML = "Please Enter Password";
        $("#txtPassword").focus();
        return false;
    }
    else {
        alert("else");
//        if (typeof (Storage) !== "undefined") {
//            localStorage.uname = uname;
//            localStorage.pwd = pword;
//        }
        window.location = 'inbox.html';
    }
}    
////////////////////////////////////////////////////////////////////////////////////////////////////////

//Logout Page
function logout() {
    localStorage.clear();
    window.location = 'index.html';
}
