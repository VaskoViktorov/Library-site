//img popup
$(document).ready(function () {

    $('.image-popup-vertical-fit').magnificPopup({
        type: 'image',
        closeOnContentClick: true,
        mainClass: 'mfp-img-mobile',
        image: {
            verticalFit: true
        }

    });
});
//img popup gallery 
$(document).ready(function () {
    $('.popup-gallery').magnificPopup({
        delegate: 'a',
        type: 'image',
        tLoading: 'Loading image #%curr%...',
        mainClass: 'mfp-img-mobile',
        gallery: {
            enabled: true,
            navigateByImgClick: true,
            preload: [0, 1] // Will preload 0 - before current, and 1 after the current image
        },
        image: {
            tError: '<a href="%url%">The image #%curr%</a> could not be loaded.',
            titleSrc: function (item) {
                return item.el.attr('title');
            }
        }
    });
});

//dropdown menu
$(document).ready(function () {
    $('.dropdown-submenu a.test').on("click", function (e) {
        $(this).next('ul').toggle();
        e.stopPropagation();
        e.preventDefault();
    });
});

//floater for returning top
$(window).scroll(function () {
    var winScrollTop = $(window).scrollTop();
    var winHeight = $(window).height();
    var floaterHeight = $('#floater').outerHeight(true);
    var fromBottom = 185;
    var top = winScrollTop + winHeight - floaterHeight - fromBottom;
    $('#floater').css({ 'top': top + 'px' });
});

//responsive slider
$(function () {
    $(".rslides").responsiveSlides({
        auto: true,             // Boolean: Animate automatically, true or false
        speed: 500,            // Integer: Speed of the transition, in milliseconds
        timeout: 3000,          // Integer: Time between slide transitions, in milliseconds
        pager: false,           // Boolean: Show pager, true or false
        nav: false,             // Boolean: Show navigation, true or false
        random: true,          // Boolean: Randomize the order of the slides, true or false
        pause: true,           // Boolean: Pause on hover, true or false
        maxwidth: "120",           // Integer: Max-width of the slideshow, in pixels
        navContainer: "",       // Selector: Where controls should be appended to, default is after the 'ul'
        manualControls: "",     // Selector: Declare custom pager navigation
        namespace: "rslides",   // String: Change the default namespace used
        before: function () { },   // Function: Before callback
        after: function () { }     // Function: After callback
    });
});
//text editor
$(document).ready(function () {
    $('#summernote').summernote({
        tabsize: 2,
        height: 300

    });
});
//facebook
(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s);
    js.id = id;
    js.src = 'https://connect.facebook.net/bg_BG/sdk.js#xfbml=1&version=v2.11';
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));

//calendar
$(document).ready(function () {
    $("#eventCalendarLocaleFile").eventCalendar({
        eventsjson: 'lib/jquery/dist/TestEvents.json',
        locales: {
            locale: "bg",
            monthNames: ["Януари", "Февруари", "Март", "Април", "Май", "Юни",
                "Юли", "Август", "Септмври", "Октомври", "Ноември", "Декември"],
            dayNames: ['Понеделник', 'Вторник', 'Сряда', 'Четвъртък',
                'Петък', 'Събота', 'Неделя'],
            dayNamesShort: ['Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб', 'Нд'],
            txt_noEvents: "Няма събития",
            txt_SpecificEvents_prev: "",
            txt_SpecificEvents_after: "Събития:",
            txt_next: "следващ",
            txt_prev: "предишен",
            txt_NextEvents: "Предстоящи събития:",
            txt_GoToEventUrl: "Подробности",
            "moment": {
                "months": ["Януари", "Февруари", "Март", "Април", "Май", "Юни",
                    "Юли", "Август", "Септмври", "Октомври", "Ноември", "Декември"],
                "monthsShort": ["Яну", "Фев", "Мар", "Апр", "Май", "Юни",
                    "Юли", "Авг", "Сеп", "Окт", "Ное", "Дек"],
                "weekdays": ['Понеделник', 'Вторник', 'Сряда', 'Четвъртък',
                    'Петък', 'Събота', 'Неделя'],
                "weekdaysShort": ['Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб', 'Нд'],
                "weekdaysMin": ['Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб', 'Нд'],
                "longDateFormat": {
                    "LT": "H:mm",
                    "LTS": "LT:ss",
                    "L": "DD/MM/YYYY",
                    "LL": "D MMMM YYYY",
                    "LLL": "D MMMM YYYY LT",
                    "LLLL": "dddd, D MMMM YYYY LT"
                },
                "week": {
                    "dow": 1,
                    "doy": 4
                }
            }
        }
    });
});
