var lsvrpVueDashboard = new Vue({
    el: '#lsvrp_dashboard',
    data: {
        show: false,
        username: "Kubas",
        chars: [
            {
                Id: 1,
                Name: "Jeremy Simons",
                Online: "15h 12m"
            },
            {
                Id: 8,
                Name: "James Truck",
                Online: "38h 45m"
            }
        ],
        selectedChar: null,
        buttonText: "Wejdź do gry",
        blocked: false,

        changelogs: null
    },
    methods: {
        onEnterClicked: function() {
            if (this.selectedChar === null) return;
            if (this.blocked) return;
            let selectedChar = this.chars[this.selectedChar];
            this.buttonText = "Ładowanie...";
            this.blocked = true;
            mp.trigger("cef.choosechar.characterChoosed", selectedChar.Id);
        }
    }
});

function DashboardShow(characters, username) {
    lsvrpVueDashboard.chars = JSON.parse(decodeURIComponent(characters));
    lsvrpVueDashboard.selectedChar = null;
    lsvrpVueDashboard.show = true;
    lsvrpVueDashboard.username = decodeURIComponent(username);
    DashboardLoadData();
}

function DashboardHide() {
    lsvrpVueDashboard.show = false;
}

function DashboardLoadData() {
    $.ajax({
        type: "GET",
        dataType: "jsonp",
        data: {},
        url: "https://admin.lsvrp.ga/changes?callback=hello",
        error: function(jqXHR, textStatus, errorThrown) {
            console.log(jqXHR);
        },
        success: function(msg) {
            for (let i = 0; i < msg.length; i++) {
                msg[i].Message = msg[i].Message.replace(/\n/g, "<br />");
            }
            lsvrpVueDashboard.changelogs = msg;
        }
    });

}