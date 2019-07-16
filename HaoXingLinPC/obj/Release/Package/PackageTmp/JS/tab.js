$(function(){
    //点击型选项卡
	$('.menus2 li').each(function () {
		var flag = 0;
		var i = 0;
		$('.menus2 li').click(function () {
			var index = $(this).index();
			$('.menus2 .bg').css('left', (index - 1) * 150 + 'px');
			$('.menus2 li').css('color', '#000');
			$(this).css('color', '#fff');
			$('.menus2 .bg').css('left', (index - 1) * 150 + 'px');
			flag = (index - 1) * 150;
			i = $(this).index() - 1;
			$(this).css('color', '#fff');
			$('.menus2 .menus-list').removeClass('show')
			$('.menus2 .menus-list').eq(index - 1).addClass('show')
			$('.tab').removeClass('show')
			$('.tab').eq(index - 1).addClass('show')
		})
	})
})
