
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

