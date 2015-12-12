function popMsg(txt) {
    var msg = $('<div class="msg hide">' + txt + '</div>');
    msg.css('left', '50%');
    $('body').append(msg);
    msg.css('margin-left', '-' + parseInt(msg.outerWidth() / 2) + 'px');
    msg.removeClass('hide');
    setTimeout(function () {
        msg.addClass('hide');
        setTimeout(function () {
            msg.remove();
        }, 400);
    }, 2600);
}

function closeDialog() {
    $('.dialog').removeClass('active');
    setTimeout(function () {
        $('.dialog').remove();
    }, 200);
}

function postDelete(url, id) {
    $.post(url, function (data) {
        if (data == 'ok' || data == 'OK') {
            $('#' + id).remove();
            popMsg('删除成功');
        }
        else
            popMsg(data);
        closeDialog();
    });
}


function deleteDialog(url, id) {
    var html = '<div class="dialog">' +
        '<h3 class="dialog-title">提示</h3>' +
        '<p>您确认要删除这条记录吗？</p>' +
        '<div class="dialog-buttons"><a href="javascript:postDelete(\'' + url + '\', \'' + id + '\')" class="button red">删除</a> <a href="javascript:closeDialog()" class="button blue">取消</a></div>' +
        '</div>';
    var dom = $(html);
    dom.css('margin-left', -(dom.outerWidth() / 2));
    $('body').append(dom);
    setTimeout(function () { dom.addClass('active'); }, 10);
}

$(document).ready(function () {
    $(".allChoose").click(function () {
        if ($('.allChoose').is(':checked')) {
            $(".choose").prop("checked", true);
        } else {
            $(".choose").prop("checked", false);
        }
    });

    $("#batchDelLogs").click(function () {
        var ids = "";
        $(".choose").each(function () {
            if ($(this).is(':checked')) {
                ids = ids + "," + $(this).val();
            }
        });
        if (ids == "") {
            popMsg("请选择要删除的对象！");
        } else {
            ids = ids.substring(1, ids.length);
            var arr = ids.split(',');
            $(".mask").show();
            $.ajax({
                url: "/Admin/Log/MutiDelete",
                method: "post",
                data: { ids: ids },
                success: function(data) {
                    popMsg("批量删除成功！");
                    for (var i = 0; i < arr.length; i++) {
                        $("tr[id=" + arr[i]+ "]").remove();
                    }
                },
                error: function(data) {
                    popMsg("批量删除失败！");
                },
                complete: function(data) {
                    $(".mask").hide();
                }
            });
        }
    });
});