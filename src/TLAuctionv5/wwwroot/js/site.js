
//highlight first list group option (if non active yet)
if ($('.list-group a.active').length === 0) {
    $('.list-group a').first().addClass('active');
}

bootcards.init({
    offCanvasHideOnMainClick: true,
    offCanvasBackdrop: true,
    enableTabletPortraitMode: true,
    disableRubberBanding: true,
    disableBreakoutSelector: 'a.no-break-out'
});

//enable FastClick
window.addEventListener('load', function () {
    FastClick.attach(document.body);
}, false);


//activate the sub-menu options in the offcanvas menu
$('.collapse').collapse();

//get auctionid for item that was clicked
$(document).ready(function () {
    $(document).on('click', '.list-group-item', function (e) {
        $(this).parent().children().removeClass("active");
        $(this).addClass("active");
        var auctionid = $(this).attr('data-id');
        $('#AuctionDetails').load("/Home/AuctionDetails/" + auctionid);
   });
});

$('#rightaffix').on('affix.bs.affix', function () {
    var size = $(window).width(); //get browser width
    var divWidth = $(myContainer).width(); //get width of container
    var margin = (size - divWidth) / 2; //get difference and divide by 2
    $("#rightaffix").css("right", margin);
})
.on('affix-top.bs.affix', function () {
    $("#rightaffix").css("right", "0px");
});

$(document).ready(function () {
    $('ul.nav.navbar-nav').find('a[href="' + location.pathname + '"]')
        .closest('li').addClass('active');
});