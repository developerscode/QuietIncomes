//Global Variables Declaration
//Login Page Valdation for valida user
$(document).ready(function () {    
    if (typeof (Storage) !== "undefined") {        
        if (localStorage.userId != null && localStorage.userId !="") {            
            window.location.href = "Inbox.html"
        }
    }
});

function LinkedinUser()  {
    window.location.href = "linkedin.html";
}

function GoogleUser() {
    window.location.href = "google.html";
}
function FacebookUser() {
    window.location.href = "facebook.html";
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
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "getdata.aspx/GetNormalUserId",
            data: "{'Username':'" + uname.toString() + "','password':'" + pword.toString() + "'}",
            dataType: 'json',
            crossDomain: true,
            success: function (data) {                
                localStorage.userId = data.d;
                window.location.href = 'inbox.html';

            },
            error: function (result) {
                alert("Error");
            }
        });
        
    }
}    
////////////////////////////////////////////////////////////////////////////////////////////////////////

//Logout Page
function logout() {
    localStorage.clear();
    window.location.href = 'index.html';
}
