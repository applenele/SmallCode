
    function submitForm() {
        var title = $("#platetitle").val();
        var classify = $("#plateforumId").val();
        var content = ue.getContent();
        var hascontent = ue.getContentTxt();
        if (title == "" || title == null) {
            alert("请输入标题之后再发布");
            return false;
        }
        if (classify == "" || classify == null) {
            alert("请输入所属模块在发布");
            return false;
        }
        if (content == "" || content == null || hascontent == "我想说点什么...") {
            alert("请输入内容之后在发布");
            return false;
        }
        else {
            $("#myform").submit();
        }
    }