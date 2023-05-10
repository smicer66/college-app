function MobileMenu() {

    var elements = {
        navDesktop   : $('nav.desktop > ul > li'),
        navMobile    : $('nav.mobile > ul > li.has-dropdown > a'),
        navLinks     : $('nav ul li a'),
        mobileBtn    : $('.mobile-menu')
    };

   this.initialise = function () {
        $('body').addClass('asd');


        elements.mobileBtn.click(function(e){
            e.preventDefault();
            $('body').toggleClass('menu-active');
            $('nav.mobile').slideToggle();
        });

        elements.navDesktop.on({
            mouseenter: function (e) {
                $(this).addClass("hovered");
            },
            mouseleave: function (e) {
                $(this).removeClass("hovered");
            }
        });

        elements.navMobile.on({
            mouseenter: function (e) {
                $(this).parent().find('ul').slideDown().closest('li').addClass('active');
            },
        });

        $('nav.mobile > ul > li > span').click(function(){
            $(this).parent().find('ul').slideUp().closest('.active').removeClass('active');
        });


        $(document).on('touchstart', function (e) {
            var $target = $(e.target);

            if ($target.parents('.has-dropdown').length || $target.hasClass('has-dropdown')) {
                return;
            }

            elements.navMobile.data('touched', false).trigger('mouseleave');
        });

    };

}

var mobileMenu = new MobileMenu();
mobileMenu.initialise();