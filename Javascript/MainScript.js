//Global Variables Declaration


function LinkedinUser() {
    window.location.href = 'linkedin.html';
}
function GoogleUser() {
    window.location.href = 'google.html';
}
function FacebookUser() {
    window.location.href = 'facebook.html';
}
function NormalUser() {
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
        if (typeof (Storage) !== "undefined") {
            localStorage.uname = uname;
            localStorage.pwd = pword;
        }
        window.location.href = 'inbox.html';
    }
}    
////////////////////////////////////////////////////////////////////////////////////////////////////////

//Logout Page
function logout() {
    localStorage.clear();
    window.location.href = 'index.html';
}
