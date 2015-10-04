$(document).ready(function () {

    $("#btnLogin").click(function () {
        var username = $("#txtUsername").val();
        var password = $("#txtPassword").val();
        $.post("/User/Login", { username: username, password: password }, function (data) {
            if (data.Statu == "ok") {
                window.location.href = data.BackUrl;
            }
            else {
                $("#warning").html("用户名或者密码不正确！");
            }
        });
    });

    $("#btnRegister").click(function () {
        var username = $("#txtRegisterUsername").val();
        var password = $("#txtRegisterPassword").val();
        var confirm = $("#txtConfirm").val();
        if (username == "") {
            $(".warning").html("用户名不能为空！");
            return;
        }
        if (password == "") {
            $(".warning").html("密码不能为空！");
            return;
        }
        if (confirm == "") {
            $(".warning").html("密码重复不能为空！");
            return;
        }
        if (confirm != password) {
            $(".warning").html("两次输入密码不一致！");
            return;
        }
        $.post("/User/Register", { username: username, password: password }, function (data) {
            if (data.Statu == "ok") {
                window.location.href = "/Home/Index";
            }
            else {
                $(".warning").html(data.Msg);
            }
        });
    });

});