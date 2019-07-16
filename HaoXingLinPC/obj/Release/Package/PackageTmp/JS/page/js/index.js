var JoinedData = []; //定义已参加项目列表
var RunSurvey = []; //定义正在运行的项目列表
$(function () {
	JoinedSurvey(1, 2);
	var JoinedList = JoinedData.list;
	if (JoinedList.length > 0) {
		var obj_2 = {
			obj_box: '.tab2',
			total_item: JoinedData.count,
			per_num: 2,
			current_page: 1,//当前页
			change_content: function change_content(per_num, current_page) {
				per_num = per_num ? per_num : 10;//每页显示条数,默认为10条
				current_page = current_page ? current_page : 1;//当前页,默认为1
				var page_str = addJoinedList(JoinedList);
				$(this.obj_box).children('.list').html(page_str);
			}
		};
		page_ctrl(obj_2);//调用分页插件
	} else {
		$(".tab2").html("<p class='empty'></p>");
	}
	$(".tab2").click(function () {
		var curPage = Number($(".tab2 .current_page").html());
		JoinedSurvey(curPage, 2);
		$(".tab2").children('.list').html(addJoinedList(JoinedData.list));
	});
	GetSurvey(1, 1);
	var SurveyList = RunSurvey.list;
	if (SurveyList.length > 0) {
		var obj_1 = {
			obj_box: '.tab1',
			total_item: RunSurvey.count,
			per_num: 1,
			current_page: 1,//当前页
			change_content: function change_content(per_num, current_page) {
				per_num = per_num ? per_num : 10;//每页显示条数,默认为10条
				current_page = current_page ? current_page : 1;//当前页,默认为1
				var page_str = addSurveyList(SurveyList);
				$(this.obj_box).children('.list').html(page_str);
			}
		};
		page_ctrl(obj_1);//调用分页插件
	} else {
		$(".tab1").html("<p class='empty'></p>");
	}
	$(".tab1").click(function () {
		var curPage = Number($(".tab1 .current_page").html());
		GetSurvey(curPage, 1);
		$(".tab1").children('.list').html(addSurveyList(RunSurvey.list));
	})
});
function JoinedSurvey(page, pageSize) {
	$.ajax({
		url: "Ashx/iService.ashx?act=GetJoinedSurvey",
		data: { page: page, pageSize: pageSize },
		dataType: "json",
		type: "post",
		async: false,
		success: function (data) {
			var dt = JSON.parse(data);
			if (dt.code == "-1") {
				alert(dt.msg);
				location.href = "index";
			} else if (dt.code == "0") {
				alert(dt.msg);
			} else {
				JoinedData = dt.detail;
			}
		}
	});
}
function GetSurvey(page, pageSize) {
	$.ajax({
		url: "Ashx/iService.ashx?act=GetRunningSurvey",
		data: { page: page, pageSize: pageSize },
		dataType: "json",
		type: "post",
		async: false,
		success: function (data) {
			var dt = JSON.parse(data);
			if (dt.code == "-1") {
				alert(dt.msg);
				location.href = "index";
			} else if (dt.code == "0") {
				alert(dt.msg);
			} else {
				RunSurvey = dt.detail;
			}
		}
	});
}
function addJoinedList(list) {
	if ($.isArray(list) && list.length > 0) {
		var status = "";
		var page_str = "";
		for (var i = 0; i < list.length; i++) {
			var page_l = "<div class='fl'><p><span class='p_num'>" + list[i].ProjectNumber + "</span> " + list[i].ProjectName + "</p><p class='sub_tit coin'>" + list[i].Integral + "积分</p><p class='sub_tit time'>" + list[i].ServeyLenth + " min</p></div>"
			status = list[i].JoinState == 0 ? "中途退出" : list[i].JoinState == 1 ? "被甄别" : list[i].JoinState == 2 ? "配额满" : list[i].JoinState == 3 ? "已完成" : list[i].JoinState == 4 ? "审核拒绝" : "未知";
			var page_r = "<div class='fr'><p class='status'>" + status + "</p></div>";
			var page_content = "<li>" + page_l + page_r + "</li> ";//当前页内容
			page_str += page_content;
		}
	}
	return page_str;
}
function addSurveyList(list) {
	if ($.isArray(list) && list.length > 0) {
		var page_str = "";
		for (var i = 0; i < list.length; i++) {
			var page_l = "<div class='fl'><p><span class='p_num'>" + list[i].ProjectNumber + "</span> " + list[i].ProjectName + "</p><p class='sub_tit coin'>" + list[i].Integral + "积分</p><p class='sub_tit time'>" + list[i].ServeyLenth + " min</p></div>"
			var page_r = "<div class='fr'><button onclick = 'fnClick(this," + list[i].ID + ")'> 立即答题</button></div>";
			var page_content = "<li>" + page_l + page_r + "</li> ";//当前页内容
			page_str += page_content;
		}
	}
	return page_str;
}
function fnClick(dom,Id) {
    var $btn = $(dom);
    $.ajax({
        url: "Ashx/iService.ashx?act=JoinSurvey",
        type: "post",
        data: { id: Id },
        dataType: "json",
        async: false,
        beforeSend: function () {
            $btn.attr("disabled","disabled")
        },
        success: function (data) {
            if (data) {
                var dt = JSON.parse(data);
                if (dt.code == "-1") {
                    alert(dt.msg);
                    location.href = "index";
                } else if (dt.code == "0") {
                    alert(dt.msg);
                    location.href = "list";
                } else if (dt.code == "1") {
                    var arr = JSON.parse(dt.msg);
                    window.open(arr[0].link);
                }
            }
        },
        error: function () {
            $btn.removeAttr("disabled");
        }
    });
}