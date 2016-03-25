            
/*
* Initialize Bootcards.
*
* Parameters:
* - offCanvasBackdrop (boolean): show a backdrop when the offcanvas is shown
* - offCanvasHideOnMainClick (boolean): hide the offcanvas menu on clicking outside the off canvas
* - enableTabletPortraitMode (boolean): enable single pane mode for tablets in portraitmode
* - disableRubberBanding (boolean): disable the iOS rubber banding effect
* - disableBreakoutSelector (string) : for iOS apps that are added to the home screen:
                    jQuery selector to target links for which a fix should be added to not
                    allow those links to break out of fullscreen mode.
*/

bootcards.init({
offCanvasBackdrop: true,
offCanvasHideOnMainClick: true,
enableTabletPortraitMode: true,
disableRubberBanding: true,
disableBreakoutSelector: 'a.no-break-out'
});

//enable FastClick
window.addEventListener('load', function () {
    FastClick.attach(document.body);
}, false);

//highlight first list group option (if non active yet)
if ($('.list-group-item .active').length == 0) {
    $('.list-group-item').first().addClass('active');
}

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

//affix right hand details
$('#rightaffix').on('affix.bs.affix', function () {
    var size = $(window).width(); //get browser width
    var divWidth = $('#rconatiner').width(); //get width of container
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
