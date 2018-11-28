const wait = ms => new Promise(resolve => setTimeout(resolve, ms));

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

jQuery.fn.cbottom = function() {
    this.css("position", "absolute");
    this.css("top", ($(window).height() - $(this).outerHeight()) + "px");
    this.css("left",
        Math.max(0,
            (($(window).width() - $(this).outerWidth()) / 2) +
            $(window).scrollLeft()) +
        "px");
    return this;
};

jQuery.fn.cright = function() {
    this.css("position", "absolute");
    this.css("top",
        Math.max(0,
            (($(window).height() - $(this).outerHeight()) / 2) +
            $(window).scrollTop()) +
        "px");
    this.css("left", ($(window).width() - $(this).outerWidth()) + "px");
    return this;
};

jQuery.fn.cleft = function() {
    this.css("position", "absolute");
    this.css("top",
        Math.max(0,
            (($(window).height() - $(this).outerHeight()) / 2) +
            $(window).scrollTop()) +
        "px");
    this.css("left", 0 + "px");
    return this;
};

$(document).ready(function() {
    $("#lsvrp_dialog").center();
    $("#lsvrp_login").center();
    $("#lsvrp_dashboard").center();
    $("#lsvrp_tattoos").center();
    $("#lsvrp_eq").cright();
    $("#lsvrp_penalty").cleft();
    $("#lsvrp_charcreator").cleft();

    $("#progress-box").cbottom();

    $("#lsvrp_penalty").css("left", "-400px");
    $("#lsvrp_eq").css("left", $(window).width() + "px");
    $("#progress-box").css("top", $(window).height() + "px");

    // draggable
    interact('.drag').draggable({
        allowFrom: '.header',
        inertia: false,
        restrict: {
            restriction: ".container",
            endOnly: false,
            elementRect: {
                top: 0,
                left: 0,
                bottom: 1,
                right: 1
            }
        },
        autoScroll: false,
        onmove: function(event) {
            var target = event.target,
                x = (parseFloat(target.getAttribute('data-x')) || 0) + event.dx,
                y = (parseFloat(target.getAttribute('data-y')) || 0) + event.dy;

            target.style.webkitTransform =
                target.style.transform =
                'translate(' + x + 'px, ' + y + 'px)';
            target.setAttribute('data-x', x);
            target.setAttribute('data-y', y);
        },
    });
});