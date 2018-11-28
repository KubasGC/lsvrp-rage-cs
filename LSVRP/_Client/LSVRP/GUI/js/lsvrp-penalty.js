var lsvrpVuePenalty = new Vue({
    el: "#lsvrp_penalty",
    data: {
        showSec: true,
        show: false,

        penaltyType: null,
        penaltyPlayer: null,
        penaltyAdmin: null,
        penaltyReason: null
    }
});

var penaltyDatas = [];

function AddPenalty(type, player, admin, reason) {

    type = decodeURIComponent(type);
    player = decodeURIComponent(player);
    admin = decodeURIComponent(admin);
    reason = decodeURIComponent(reason);

    penaltyDatas.push({ Type: type, Player: player, Admin: admin, Reason: reason });

    if (penaltyDatas.length == 1) {
        lsvrpVuePenalty.penaltyType = type;
        lsvrpVuePenalty.penaltyPlayer = player;
        lsvrpVuePenalty.penaltyAdmin = admin;
        lsvrpVuePenalty.penaltyReason = reason;
        lsvrpVuePenalty.show = true;

        DoPenalty(false);
    }
}

function DoPenalty(withSet) {
    if (penaltyDatas.length === 0) return;

    if (withSet) {
        lsvrpVuePenalty.penaltyType = penaltyDatas[0].Type;
        lsvrpVuePenalty.penaltyPlayer = penaltyDatas[0].Player;
        lsvrpVuePenalty.penaltyAdmin = penaltyDatas[0].Admin;
        lsvrpVuePenalty.penaltyReason = penaltyDatas[0].Reason;
        lsvrpVuePenalty.show = true;
    }

    wait(7000).then(() => {
        lsvrpVuePenalty.show = false;
        wait(1100).then(() => {
            penaltyDatas.splice(0, 1);
            if (penaltyDatas.length > 0) DoPenalty(true);
        });
    });
}