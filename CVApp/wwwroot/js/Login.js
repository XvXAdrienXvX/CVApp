
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

function submit() {
    let username = document.getElementById("username").value;
    let password = document.getElementById("Password").value;

    window.location.href = "/User/CheckCredentials?usr=" + username + "&pwd=" + password;

}

$(document).ready(function () {
    $("#create").on("click", function () {
        $.ajax(
            {
                type: "GET",
                url: "/User/IdentifyUser",

                data: {
                    username: this.name
                },

                cache: false,
                success: function (data) {


                }
            });
    });
});
