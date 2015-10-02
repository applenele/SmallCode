$(document).ready(function () {

    $("#btnLogin").click(function () {
        var username = $("#txtUsername").val();
        var password = $("#txtPassword").val();
        $.post("/User/Login", { username: username, password: password }, function (data) {
            if (data.Statu == "ok") {
                window.location.reload();
            }
            else {
                $("#warning").html("用户名或者密码不正确！");
            }
        });
    });
});