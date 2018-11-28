var lsvrpVueFactionsOnline = new Vue({
    el: '#factions-online',
    data: {
        factions: 0
    }
});

function changeFactionsOnline(data) {
    lsvrpVueFactionsOnline.factions = parseInt(data);
}