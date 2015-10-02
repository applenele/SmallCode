$(document).ready(function () {

    $("#btnLogin").click(function () {
        var username = $("#txtUsername").val();
        var password = $("#txtPassword").val();
        $.post("/User/Login", { username: username, password: password }, function (data) {
            if (data.Statu == "ok") {
                window.location.reload();
            }
            else {

            }
        });
    });
});