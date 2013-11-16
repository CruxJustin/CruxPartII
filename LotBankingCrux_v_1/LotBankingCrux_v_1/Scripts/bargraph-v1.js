$(function () {

    var input = $('.input1'),
        bar = $('.bar1'),
    bw = bar.width(),
    percent = bar.find('.percent'),
    circle = bar.find('.circle'),
    ps = percent.find('span'),
    cs = circle.find('span'),
    name = 'rotate';

    input.on('keydown', function (e) {
        if (e.keyCode == 13) {
            var t = $(this), val = t.val();
            if (val >= 0 && val <= 100000) {

                // val/1000 for val = 100000 made sense Monday Night
                var w = 100 - (val / 1000), pw = (bw * w) / 100,
					pa = {
					    //Outputs width to HTML for circle use
					    width: w + '%'
					},
					cw = (bw - pw) / 2,
					ca = {
					    left: cw
					}
                ps.animate(pa);
                //changed % to $ no problem. Need to remember to clean and build solution
                cs.text('$' + val);
                circle.animate(ca, function () {
                    circle.removeClass(name)
                }).addClass(name);
            } else {
                alert('range: 0 - 100000');
                t.val('');
            }
        }
    });

});

$(function () {

    var input = $('.input2'),
        bar = $('.bar2'),
    bw = bar.width(),
    percent = bar.find('.percent'),
    circle = bar.find('.circle'),
    ps = percent.find('span'),
    cs = circle.find('span'),
    name = 'rotate';

    input.on('keydown', function (e) {
        if (e.keyCode == 13) {
            var t = $(this), val = t.val();
            if (val >= 0 && val <= 100000) {

                // val/1000 for val = 100000 made sense Monday Night
                var w = 100 - (val / 1000), pw = (bw * w) / 100,
					pa = {
					    //Outputs width to HTML for circle use
					    width: w + '%'
					},
					cw = (bw - pw) / 2,
					ca = {
					    left: cw
					}
                ps.animate(pa);
                //changed % to $ no problem. Need to remember to clean and build solution
                cs.text('$' + val);
                circle.animate(ca, function () {
                    circle.removeClass(name)
                }).addClass(name);
            } else {
                alert('range: 0 - 100000');
                t.val('');
            }
        }
    });

});

$(function () {

    var input = $('.input3'),
        bar = $('.bar3'),
    bw = bar.width(),
    percent = bar.find('.percent'),
    circle = bar.find('.circle'),
    ps = percent.find('span'),
    cs = circle.find('span'),
    name = 'rotate';

    input.on('keydown', function (e) {
        if (e.keyCode == 13) {
            var t = $(this), val = t.val();
            if (val >= 0 && val <= 100000) {

                // val/1000 for val = 100000 made sense Monday Night
                var w = 100 - (val / 1000), pw = (bw * w) / 100,
					pa = {
					    //Outputs width to HTML for circle use
					    width: w + '%'
					},
					cw = (bw - pw) / 2,
					ca = {
					    left: cw
					}
                ps.animate(pa);
                //changed % to $ no problem. Need to remember to clean and build solution
                cs.text('$' + val);
                circle.animate(ca, function () {
                    circle.removeClass(name)
                }).addClass(name);
            } else {
                alert('range: 0 - 100000');
                t.val('');
            }
        }
    });

});