<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="HaoXingLinPC.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>好杏林调查网</title>
	<script src="JS/jquery-1.10.2.min.js"></script>
	<script src="JS/jquery18.js"></script>
	<script src="JS/slides.js"></script>
	<link href="Css/index.css" rel="stylesheet" />
	<style>
		.part_two {
			height: 60px;
			line-height: 60px;
		}
		.banner {
			margin-top: 68px;
		}
		.how_step, .question {
			padding-top: 80px;
		}
	</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top">
		<div class="top_bg">
			<div class="top_login">
				<%--<button type="button" class="fr top_btn login">微信登录</button>--%>
                <asp:Button ID="btn_login" runat="server" CssClass="fr top_btn login" Text="微信登录" OnClick="btn_login_Click" />
				<p class="fr">医疗行业调查平台</p>
			</div>
		</div>
		<div class="banner focus">
			<div id="xmSlide" class="xmSlide">
				<div class="xmSlide_01"></div>
				<div class="xmSlide_02"></div>
				<div class="xmSlide_03"></div>
			</div>
		</div>
	</div>
	<div class="how_step">
		<div class="tit">参与步骤</div>
		<div class="step_content">
			<div> 
				<div class="step_img">
					<img src="images/step1.jpg" />
				</div>
				<div class="step">
					<img src="images/1.png" />
					<h2 class="text">打开公众号“好杏林”选择答题</h2>
				</div>
			</div>
			<div>
				<div class="step_img">
					<img src="images/step2.jpg" />
				</div>
				<div class="step">
					<img src="images/2.png" />
					<h2 class="text">认真完成答题问卷，参与即有奖励</h2>
				</div>
			</div>
			<div>
				<div class="step_img">
					<img src="images/step3.jpg" />
				</div>
				<div class="step">
					<img src="images/3.png" />
					<h2 class="text">积分兑换现金红包，随时消费</h2>
				</div>
			</div>
		</div>
	</div>
	<div class="question">
		<div class="tit">常见问题</div>
		<div class="q_list">
			<div class="q_item">
				<div class="q_tit">好杏林调查网和好杏林公众号是什么关系？</div>
				<div class="answer">好杏林公众号是好杏林调查网的升级版，好杏林调查网的积分调查和金币调查均已迁移到好杏林公众号。并统一奖励方式，改为红包调查。网站功能不再保留。</div>
			</div>
			<div class="q_item">
				<div class="q_tit">我在好杏林调查网的积分和金币去哪儿了？</div>
				<div class="answer">好杏林调查网用户的金币和积分均已换算成对应的红包余额，迁移到好杏林公众号。只需扫描首页二维码关注后，就可以去公众号看到对应的提现入口了。</div>
			</div>
			<div class="q_item">
				<div class="q_tit">以后如何参与有奖调查？</div>
				<div class="answer">后续所有的有奖调查均在好杏林微信公众号进行，参与更加方便，提现更加高效便捷。欢迎关注。</div>
			</div>
		</div>
	</div>
	<div class="footer">
		<ul class="content">
			<li class="fl">
				<div class="footer_tit" >友情连接</div>
				<a href="http://www.holdendata.com">HOLDENDATA</a>
				<a href="http://www.krenwu.com/">K任务</a>
				<a href="http://www.dajiashuo.com/">大家说</a>
			</li>
			<li class="fl">
				<div class="footer_tit">联系我们</div>
				<a class="tel">
					<img src="images/tel.png" />+86 21 5830 6270
				</a>
				<a class="address">
					<img src="images/address.png" />上海市黄浦区北京东路668号科技京城西楼13A
				</a>
				<a class="mail">
					<img src="images/mail.png" />team@holdendata.com
				</a>
			</li>
			<li class="fr wechat">
				<img src="images/weixin.png" />
				<button type="button">关注好杏林公众号</button>
			</li>
		</ul>
		<div class="part_two">
			上海浩顿英菲市场信息咨询有限公司　沪ICP备10019317号-2 Copyright © 2016 Holdendata. All rights reserved.
		</div>
	</div>
    </form>
	<script>
		$(function () {
			$("#xmSlide").xmSlide({
				width: 1650,
				height: 520,
				responsiveWidth: 710,
				pagination: {
					effect: "fade"
				},
				effect: {
					fade: {
						speed: 400
					}
				},
				play: {
					effect: "fade",
					interval: 4000,
					auto: true,
					pauseOnHover: true,
					restartDelay: 2500
				}
			})
		})
	</script>
</body>
</html>
