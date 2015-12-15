$(document).ready(function () {

    $("#submitFrom").click(function () {
        var title = $("#platetitle").val();
        var classify = $("#plateforumId").val();
        var content = ue.getContent();
        $.post("/Forum/Add", { title: title, classify: classify, content: content }, function (data) {
            if (data.Statu == "ok") {
                window.location.href = data.BackUrl;

            }
        });
    });
});