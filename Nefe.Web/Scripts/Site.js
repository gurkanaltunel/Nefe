$(function () {

    $('button[data-toggle="tooltip"]').tooltip({ container: 'body' });
    $('a[data-toggle="tooltip"]').tooltip({ container: 'body' });

    $('.owl-item.active').click(function () {
        var imgVal = $(this).find('img').attr('src');
        $('#imageDetail').attr('src', imgVal);
    });

    $("span[class='input-group-btn'] button").click(function () {
        var $text = $(this).text();
        var $productQty = $(this).parent().parent().find("input[type='text']");
        if ($text === "-") {
            var a = ($productQty.val() - 1);
            if (a < 1) {
                $productQty.val(1);
            }
            else
                $productQty.val(a);
        }
        else {
            var a = $productQty.val();
            $productQty.val((parseInt(a) + 1));
        }
    });

    $('#navbar-ex1-collapse a').click(function (event) {
        $('.nav').find('.active').removeClass('active');
        $(this).parent().addClass('active');
    });
});