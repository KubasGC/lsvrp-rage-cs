var lsvrpVueProgress = new Vue({
    el: "#progress-box",
    data: {
        headerName: "Nazwa w nagłówku",
        percentage: 0,
        show: false
    },
    methods: {
        Start: function(name) {
            this.headerName = name;
            this.percentage = 0;
            this.show = true;
        },
        Stop: function() {
            this.show = false;
        },
        Update: function(progress) {
            this.percentage = progress;
        }
    },
    watch: {
        show: function(val) {
            if (val === true) {
                $("#progress-box").css("top", ($(window).height() - $("#progress-box").outerHeight()) + "px");
            } else {
                $("#progress-box").css("top", $(window).height() + "px");
            }
        }
    }
});

/*
$(function() {
	lsvrpVueProgress.Start("Naprawa pojazdu");
	setInterval(function() {
		if (lsvrpVueProgress.percentage < 100) lsvrpVueProgress.percentage++;
		else
		{
			if (lsvrpVueProgress.show) lsvrpVueProgress.show = false;
		}
	}, 30);
});
*/