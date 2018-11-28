jQuery.fn.center = function() {
    this.css("position", "absolute");
    this.css("top",
        Math.max(0,
            (($(window).height() - $(this).outerHeight()) / 2) +
            $(window).scrollTop()) +
        "px");
    this.css("left",
        Math.max(0,
            (($(window).width() - $(this).outerWidth()) / 2) +
            $(window).scrollLeft()) +
        "px");
    return this;
};

jQuery.fn.right = function() {
    this.css("position", "absolute");
    this.css("top", ($(window).height() - $(this).outerHeight() - 15) + "px");
    this.css("left", ($(window).width() - $(this).outerWidth() - 10) + "px");
};

jQuery.fn.centerright = function() {
    this.css("position", "absolute");
    this.css("top",
        Math.max(0,
            (($(window).height() - $(this).outerHeight()) / 2) +
            $(window).scrollTop()) +
        "px");
    this.css("left", ($(window).width() - $(this).outerWidth() - 10) + "px");
    return this;
};

jQuery.fn.centerbottom = function() {
    this.css("position", "absolute");
    this.css("top", ($(window).height() - $(this).outerHeight()) + "px");
    this.css("left",
        Math.max(0,
            (($(window).width() - $(this).outerWidth()) / 2) +
            $(window).scrollLeft()) +
        "px");
    return this;
};

jQuery.fn.centerleft = function() {
    this.css("position", "absolute");
    this.css("top",
        Math.max(0,
            (($(window).height() - $(this).outerHeight()) / 2) +
            $(window).scrollTop()) +
        "px");
    this.css("left", 10 + "px");
    return this;
};

$(document).ready(function() {
    $("#items-panel").center();
    $("#offers-panel").right();
    $("#modal-panel").center();
    $("#bw-timer").centerright();
    $("#modal-list-panel").center();
    $("#char-creator").centerleft();
    $("#char-clothes").centerleft();
    $("#loading-container").centerbottom();

    var $draggables = $('.draggable').draggabilly({
        // contain to parent element
        containment: true,
        handle: '.modal-box-header'
    });

    document.onkeypress = function(event) {
        //alert(event.key)
        mp.trigger("ui.afk.get");
    };
});

function ToggleLoader(state) {
    if (state) {
        $("#loading-container").show();
    } else {
        $("#loading-container").hide();
    }


}

/*document.addEventListener('keydown', function(e) {
    mp.trigger("cef.onKeyClick", e.key, e.keyCode);
});*/