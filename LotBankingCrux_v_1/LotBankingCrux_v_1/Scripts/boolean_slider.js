$(document).ready(function () {
    $('.bool-slider .inset .control').click(function () {
        if (!$(this).parent().parent().hasClass('disabled')) {
            if ($(this).parent().parent().hasClass('false')) {
                $(this).parent().parent().addClass('true').removeClass('false');
            } else {
                $(this).parent().parent().addClass('false').removeClass('true');
            }
        }
    });
});