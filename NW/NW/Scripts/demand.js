$("#demand_reset").click(function () {
    $("#demand-title").val("");
    $("#demand-text").val("");
});
$("#demand_sumbit").click(function () {
    if ($("#user_name").length == 0) {
        alert("请先登录");
        $("#PushModal").modal('hide');
        $('#loginModal').modal('show');
    }
    else {
        var title = $("#demand-title").val();
        var content = ue.getContent();
        var tf = 1;
        $("#demand-title-warning-text").html("");
        $("#demand-text-warning-text").html("");
        if (title.length == 0) {
            $("#demand-title-warning-text").attr("class", "text-warning");
            $("#demand-title-warning-text").html("请输入标题");
            tf = 0;
        }
        else if (title.length > 30) {
            $("#demand-title-warning-text").attr("class", "text-warning");
            $("#demand-title-warning-text").html("标题过长，请重新输入");
            tf = 0;
        }
        if (content == "" || content == null || hascontent == "我想说点什么...") {
            $("#demand-text-warning-text").attr("class", "text-warning");
            $("#demand-text-warning-text").html("请填写需求");
            tf = 0;
        }
        else {
            if (tf == 1) {
                $("#demand-title-warning-text").attr("class", "text-muted");
                $("#demand-title-warning-text").html(title.length+"/30");
                $("#demand-text-warning-text").attr("class", "text-muted");
                $.ajax({
                    type: 'POST',
                    url: "/Demand/Save",
                    data: { Title: title, Text: content },
                    dataType: "json",
                    success: function (data) {
                        if (data.Statu == "ok") {
                            $("#demand-warning-text").attr("class", "text-success");
                            location.href = data.BackUrl;
                        }
                        else if (data.Statu == "err") {
                            $("#demand-warning-text").attr("class", "text-warning");
                        }
                        else if (data.Statu == "go_login") {
                            $("#demand-warning-text").attr("class", "text-danger");
                            $("#PushModal").modal('hide');
                            $('#loginModal').modal('show');
                        }
                        else if (data.Statu == "text") {
                            $("#demand-text-warning-text").attr("class", "text-warning");
                            $("#demand-text-warning-text").html(data.Data);
                        }
                        else if (data.Statu == "title") {
                            $("#demand-title-warning-text").attr("class", "text-warning");
                            $("#demand-title-warning-text").html(data.Data);
                        }
                        else if (data, Statu == "isBanned") {
                            $("#demand-title-warning-text").attr("class", "text-warning");
                            $("#demand-title-warning-text").html(data.Data);
                        }
                        $("#demand-warning-text").html(data.Msg);
                    },
                    error: function () {
                        $("#demand-warning-text").addClass("text-danger");
                        $("#demand-warning-text").html("网络异常，请稍后重试");
                    }
                });
            }
        }
    }

});
$(".demand-info-vote-up").click(function () {
    if ($("#user_name").length == 0) {
        alert("请先登录");
        $("#PushModal").modal('hide');
        $('#loginModal').modal('show');
    }
    else {
        var this_demand = $(this).attr("id");
        var this_demand_arr = this_demand.split("-");
        var demand_id = this_demand_arr[4];
        $.ajax({
            type: 'POST',
            url: "/Demand/Up_Vote",
            data: { Id: demand_id },
            dataType: "json",
            success: function (data) {
                if (data.Statu == "ok") {
                    var num = $("#demand-info-vote-" + demand_id).html();
                    $("#demand-info-vote-" + demand_id).html(parseInt(num) + 1);
                }
                else if (data.Statu == "err") {
                    alert(data.Msg)
                }
            },
            error: function () {
                alert("网络异常，请稍后重试");
            }
        });
    }
});
$("#demand-title").keyup(function ()
{
    var title = $("#demand-title").val();
    if (title.length > 30)
    {
        $("#demand-title").val(title.substring(0, 30));
        title = $("#demand-title").val();
    }
    else if (title.length == 30)
    {
        $("#demand-title-warning-text").attr("class", "text-danger");
        $("#demand-title-warning-text").html(title.length + "/30");
    }
    $("#demand-title-warning-text").attr("class", "text-muted");
    $("#demand-title-warning-text").html(title.length + "/30");
});
$("#demand-title").blur(function ()
{
    var title = $("#demand-title").val();
    if (title.length==0)
    {
        $("#demand-title-warning-text").attr("class", "text-warning");
        $("#demand-title-warning-text").html("请输入标题");
    }
});