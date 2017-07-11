// Write your Javascript code.
$(document).ready(function () {

    var body = $('body');

    // mobile navbar trigger
    function closeNav(elm, btn) {
        var $elm = elm;
        $elm.removeClass('in');
        setTimeout(function () {
            $elm.removeClass('fade');
            body.removeClass('modal-open');
        }, 450);
    }

    $('.collapse-btn').on('click', function (e) {
        var elm = $(this),
            $tar = $(elm.data('target'));
        $tar.addClass('fade');
        body.addClass('modal-open');
        setTimeout(function () {
            $tar.addClass('in');
        }, 50);
        e.preventDefault();
    });
    $('.nav-close').on('click', function (e) {
        var elm = $(this),
            tar = $(elm.data('target'));
        closeNav(tar, elm);
        e.preventDefault();
    });

});