$(document).ready(function () {

    let result = document.getElementById("result");

    $("#create").on("click", function () {
        $.ajax(
            {
                type: "GET",
                url: "/User/IdentifyUser",
                data: {
                    username: this.name
                },
                cache: false,
                success: function (response) {

                    console.log(response);
                }
            });
    });

    $('#submit').click(function (e) {
        
        var data = {
            username: function () { return $("#username").val(); },
            password: function () { return $("#Password").val(); }

        };

        $.ajax({
            url: "/User/CheckCredentials",
            type: "GET",
            data: { username: data.username, password: data.password },
            dataType: "html",
            cache: false,
            error: function (response) {
                $('#result').removeClass('strong');
                $('#result').addClass('short');
                result.innerHTML = 'Login Failed';
            }
        });
    });
});

function checkStrength() {
    let result = document.getElementById("result");
    let password = document.getElementById("Password");
    
    if (!password.value.match("(?=.*[A-Z])")) {
        $('#result').removeClass('strong');
        $('#result').addClass('short');
        result.innerHTML = 'Password should contain at least 1 uppercase';
    }
    else if (password.value.length > 9) {
        $('#result').removeClass('strong');
        $('#result').addClass('short');
        result.innerHTML = 'Password must be 9 characters only';
    }
    else if (!password.value.match("(?=.[!@#\$%\^&])")) {
        $('#result').removeClass('strong');
        $('#result').addClass('short');
        result.innerHTML = 'Password must contain at least 1 special character';
    }
    else if (password.value.length === 9) {
        $('#result').removeClass('short');
        $('#result').addClass('strong');
        result.innerHTML = 'Strong';
    }
    else {
        result.innerHTML = '';
    }

}