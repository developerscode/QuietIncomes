

var CLIENTID = '333321763082-ptnes37tfep4atlqobjn89ngukmv9ql1.apps.googleusercontent.com';
//var CLIENTID = '901126418583.apps.googleusercontent.com';

var REDIRECT = 'https://www.quietincomes.com/googlepluslogin.aspx';
//var REDIRECT = 'http://www.quietincomes.com/Temp.aspx';

        var OAUTHURL    =   'https://accounts.google.com/o/oauth2/auth?';
        var VALIDURL    =   'https://www.googleapis.com/oauth2/v1/tokeninfo?access_token=';
        var SCOPE       =   'https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email';
        var LOGOUT      =   '//accounts.google.com/Logout';
        var TYPE        =   'token';
        var _url        =   OAUTHURL + 'scope=' + SCOPE + '&client_id=' + CLIENTID + '&redirect_uri=' + REDIRECT + '&response_type=' + TYPE;
        var acToken;
        var tokenType;
        var expiresIn;
        var user;
        var loggedIn    =   false;

        function logingoogle() {
          
            var win = window.open(_url, "windowname1", 'width=800, height=600');
            console.log(win);
			console.log(win.document);
			console.log(win.document.URL);
            
			if (win != null) {
			
                var pollTimer = window.setInterval(function () {
                    // if (win.document.URL.indexOf("googlepluslogin.aspx") != -1) {                   
                    if (win.document.URL.indexOf(REDIRECT) != -1) {
                        window.clearInterval(pollTimer);
                        var url = win.document.URL;

                        acToken = gup(url, 'access_token');
                        tokenType = gup(url, 'token_type');
                        expiresIn = gup(url, 'expires_in');
                        win.close();

                        validateToken(acToken);
                    }

                }, 500);
            }
	    }

        function validateToken(token) {
            $.ajax({
                url: VALIDURL + token,
                data: null,
                success: function (responseText) {  
                    getUserInfo();
                    loggedIn = true;
                    $('#loginText').hide();
                    $('#logoutText').show();
                },  
                dataType: "jsonp"  
            });
        }

        function getUserInfo() {
            $.ajax({
                url: 'https://www.googleapis.com/oauth2/v1/userinfo?access_token=' + acToken,
                data: null,
                success: function (resp) {
                    user = resp;
                    var sponsor = "";
                    var noregister = "0";
                    if (document.getElementById('txtSponsorID') == null)
                        noregister = 1;
                    else
                        sponsor = document.getElementById('txtSponsorID').value;                    
                    window.location.href = "googlepluslogin.aspx?sponsorid=" + sponsor + "&id=" + user.id + "&fname=" + user.given_name + "&lname=" + user.family_name + "&email=" + user.email + "&gender=" + user.gender + "&birthday=" + user.birthday + "&picture=" + user.picture + "&noregister=" + noregister;
                },
                dataType: "jsonp"
            });
        }

         function gup(url, name) {
            name = name.replace(/[\[]/,"\\\[").replace(/[\]]/,"\\\]");
            var regexS = "[\\#&]"+name+"=([^&#]*)";
            var regex = new RegExp( regexS );
            var results = regex.exec( url );
            if( results == null )
                return "";
            else
                return results[1];
        }


