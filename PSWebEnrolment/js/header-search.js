function SearchBar() {

    var elements = {
        action :      $('.search-action'),
        SearchInput : $('.search-bar input')
    };

    this.initialise = function () {
        elements.action.on("click", function(e) {
            e.preventDefault();
            $('.search-bar').slideToggle();
            elements.action.toggleClass('active');
            $('body').removeClass('menu-active');
            $('nav.mobile').slideUp();
        });

        $('main').on("click", function(e) {
            $('.search-bar').slideUp();
            elements.action.removeClass('active');
        });

        elements.SearchInput.on("keypress", function (e) {
            if (e.keyCode == 13) {
                if (elements.SearchInput.val() === '') {
                    alert("Please enter a search term");
                    return false;
                } else {
                    window.location.href = "/search?q=" + encodeURIComponent(elements.SearchInput.val());
                    return false;
                }
            }
        });
    };
}

var headersearch = new SearchBar();
headersearch.initialise();