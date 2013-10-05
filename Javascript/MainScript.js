//Global Variables Declaration


function LinkedinUser() {
    window.open('linkedin.html', '_blank', 'location=yes');    
}
function GoogleUser() {
    window.open('google.html', '_blank', 'location=yes');    
}
function FacebookUser() {
    window.open('facebook.html', '_blank', 'location=yes');    
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
        window.open('inbox.html', '_blank', 'location=yes');
    }
}    
////////////////////////////////////////////////////////////////////////////////////////////////////////

//Logout Page
function logout() {
    localStorage.clear();    
    window.open('index.html', '_blank', 'location=yes');
}
