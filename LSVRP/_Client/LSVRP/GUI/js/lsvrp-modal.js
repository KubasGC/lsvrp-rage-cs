const DIALOG_ACCEPT = 0;
const DIALOG_DECLINE = 1;

var lsvrpModalVue = new Vue({
    el: '#lsvrp_dialog',
    data: {
        header: "Sklep Sandy Shores",
        columns: [{ "Size": "70", "Name": "Nazwa" }, { "Size": "25", "Name": "Cena" }],
        datas: [{ "Data": "1", "Text": ["Baton Tarczy", "$200"] }],
        buttons: ["Kup", "Anuluj"],
        activeRow: null,
        dblRow: null,
        dblTimeout: null,
        show: false,
        type: 1,
        description: "",
        enteredText: "",
        lengthTest: ""
    },
    methods: {
        firstButton: function() {

            if (this.type === 1) {
                if (this.activeRow === null) return;
                let data = this.datas[this.activeRow].Data;
                if (data !== "not-clickable") {
                    mp.trigger("cef.dialog.responseToServer", data, DIALOG_ACCEPT);
                    this.show = false;
                }
            } else if (this.type === 2) {
                if (this.enteredText.length < 1) return;
                mp.trigger("cef.dialog.responseToServer", this.enteredText, DIALOG_ACCEPT);
                this.show = false;
            } else if (this.type === 3) {
                mp.trigger("cef.dialog.responseToServer", null, DIALOG_ACCEPT);
                this.show = false;
            }
        },
        secondButton: function() {
            if (this.type === 1) {
                let data = null;
                if (this.activeRow !== null) {
                    data = this.datas[this.activeRow].Data;
                }
                mp.trigger("cef.dialog.responseToServer", data, DIALOG_DECLINE);
                this.show = false;
            } else if (this.type === 2) {
                mp.trigger("cef.dialog.responseToServer", this.enteredText, DIALOG_DECLINE);
                this.show = false;
            } else if (this.type === 3) {
                mp.trigger("cef.dialog.responseToServer", null, DIALOG_DECLINE);
                this.show = false;
            }

            // mp.trigger('cef.global.hideCursor');
            // mp.trigger('client.dialog.togglechat', false);

        },
        clickRow: function(row) {
            if (this.datas[row].Data === "not-clickable") return;
            if (this.activeRow !== row) this.activeRow = row;

            if (this.dblRow === null) {
                this.dblRow = row;
            } else {
                if (this.dblRow === row) {
                    this.firstButton();
                    this.resetDbl();
                } else {
                    this.dblRow = row;
                }

            }

            if (this.dblTimeout !== null) clearTimeout(this.dblTimeout);
            this.dblTimeout = setTimeout(this.resetDbl, 800);
        },
        resetDbl: function() {
            if (this.dblTimeout !== null) clearTimeout(this.dblTimeout);

            this.dblTimeout = null;
            this.dblRow = null;
        }
    }
});


function LoadModal(title, dialogColumns, dialogRows, dialogButtons) {

    dialogColumns = JSON.parse(decodeURIComponent(dialogColumns));
    dialogRows = JSON.parse(decodeURIComponent(dialogRows));
    dialogButtons = JSON.parse(decodeURIComponent(dialogButtons));

    for (let i = 0; i < dialogColumns.length; i++) {
        dialogColumns[i].Name = dialogColumns[i].Name.replace(/\\/g, '');
    }
    for (let i = 0; i < dialogRows.length; i++) {
        for (let k = 0; k < dialogRows[i].Text.length; k++) {
            dialogRows[i].Text[k] = dialogRows[i].Text[k].replace(/\\/g, '');
        }
    }

    lsvrpModalVue.type = 1;
    lsvrpModalVue.header = title;
    lsvrpModalVue.columns = dialogColumns;
    lsvrpModalVue.datas = dialogRows;
    lsvrpModalVue.buttons = dialogButtons;
    lsvrpModalVue.activeRow = null;
    $("#lsvrp_dialog").center();
    lsvrpModalVue.show = true;
}

function LoadEnterText(title, desc, startVal, dialogButtons) {
    dialogButtons = JSON.parse(decodeURIComponent(dialogButtons));

    lsvrpModalVue.type = 2;
    lsvrpModalVue.header = title;
    lsvrpModalVue.description = desc;
    lsvrpModalVue.enteredText = startVal;
    lsvrpModalVue.buttons = dialogButtons;
    $("#lsvrp_dialog").center();

    $(".list-body").scrollTop(0).scrollLeft(0);

    lsvrpModalVue.show = true;
}

function Modal_LoadInfo(title, desc, dialogButtons) {
    dialogButtons = JSON.parse(decodeURIComponent(dialogButtons));
    lsvrpModalVue.type = 3;
    lsvrpModalVue.header = title;
    lsvrpModalVue.description = desc;
    lsvrpModalVue.buttons = dialogButtons;
    $("#lsvrp_dialog").center();
    lsvrpModalVue.show = true;
}

function Modal_OnMouseOver(element) {
    $(element).removeClass("ellipsis");
    lsvrpModalVue.lengthTest = $(element).text();
    setTimeout(function() {
            let maxscroll = $("#testLength").width();
            let speed = maxscroll * 15;
            $(element).animate({
                    scrollLeft: maxscroll
                },
                speed,
                "linear");
        },
        20);

}

function Modal_OnMouseOut(element) {
    $(element).stop();
    $(element).addClass("ellipsis");
    $(element).scrollLeft(0);
}