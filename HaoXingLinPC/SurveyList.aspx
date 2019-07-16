<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SurveyList.aspx.cs" Inherits="HaoXingLinPC.SurveyList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>问卷列表-好杏林</title>
    <script src="JS/jquery-1.10.2.min.js"></script>
    <link href="Css/index.css" rel="stylesheet" />
    <link href="Css/tab.css" rel="stylesheet" />
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
	<link href="JS/page/css/toPage.css" rel="stylesheet" />
    <style>
        body {
            background: #f1f2f2;
        }
        .part_two {
            position: fixed;
			bottom: 0;
            width: 100%;
            line-height: 24px;
            padding: 10px 0;
        }
    	.we_img {
			width: 80%;
			max-width: 260px;
    	}
    	.tab .list li .fr button {
			margin-top: 32px;
    	}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top_bg">
		<div class="top_login">
			<p class="fl" style="padding-left: 150px;line-height: 60px;">医疗行业调查平台</p>	
            <asp:Button ID="btn_back" CssClass="fr top_btn back" runat="server" Text="返回首页" OnClick="btn_back_Click" />
		</div>            
	</div>
	<div class="middle">
		<div class="survey_list">
            欢迎医生：<%=Name %>参与问卷调查
			<div class="menus menus2 ">
				<ul>
					<div class="bg"></div>
					<li><span>待参与</span></li>
					<li><span>已完成</span></li>
				</ul>
				<div class="clear"></div>
			</div>
            <div class="tabs">
                <div class="tab tab1 show">
                    <ul class="list"></ul>                  
				</div>
				<div class="tab tab2">
					<ul class="list"></ul>
				</div>
			</div>
		</div>
        <div class="r_content fr">
            <div class="winner_list">
                <p class="right_tit"><i></i>获奖名单</p>
				<% if (GetM_Prizes().Count > 0)
					{%>
                <ul class="winList">
					<% foreach (var reward in GetM_Prizes())
					{%>
                    <li class="list-item">
                        <p><%=reward.Member_HandPhone %></p>
                        <p><%=reward.DateLine %></p>
                        <span class="winMoney"><%=reward.Name %></span>
                    </li>
					<%} %>
                </ul>
				<%} %>
            </div>
            <div class="faq">
                <p class="right_tit"><i></i>常见问题</p>
				<ul class="faq_list">
					<li>
						<div class="faq_tit"><span class="num">01</span><span>好杏林调查网和公众号是什么关系？</span></div>
						<div class="faq_answer">答：好杏林公众号是好杏林调查网的升级版，好杏林调查网的积分调查和金币调查均已迁移到好杏林公众号。并统一奖励方式，改为红包调查。网站功能不再保留。</div>
					</li>
					<li>
						<div class="faq_tit"><span class="num">02</span><span>我在好杏林调查网的积分和金币去哪儿了？</span></div>
						<div class="faq_answer">答：好杏林调查网用户的金币和积分均已换算成对应的红包余额，迁移到好杏林公众号。只需扫描首页二维码关注后，就可以去公众号看到对应的提现入口了。</div>
					</li>
					<li style="text-align: center;">
						<img src="images/weixin.png" class="we_img"/>
						<p>扫一扫关注公众号</p>
					</li>
				</ul>
            </div>
        </div>
        <div class="clear"></div>
    </div>
    <div class="part_two">
        <div>
            上海浩顿英菲市场信息咨询有限公司<br />
            沪ICP备10019317号-2 Copyright © 2016 Holdendata. All rights reserved.
        </div>
    </div>
    </form>
    <script src="JS/tab.js"></script>
    <script src="bootstrap/js/jquery.bootstrap.newsbox.min.js"></script>
	<script src="JS/page/js/toPage.js"></script>
	<script src="JS/page/js/index.js"></script>
    <script>
		$(function () {
			$(".winList").bootstrapNews({
				newsPerPage: 5,
				autoplay: true,
				pauseOnHover: true,
				navigation: false,
				direction: 'down',
				newsTickerInterval: 2500,
				onToDo: function () {
					//console.log(this);
				}
			});
		})
    </script>
	
</body>
</html>
