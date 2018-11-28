function modalListUseRow(row) {
    let data = $(row).attr('data');
    if (data != 'not-clickable') {
        modalListToggle(false);
        mp.trigger("cef.dialog.responseToServer", data);
    }
}

function modalListSendText() {
    modalListToggle(false);
    mp.trigger("cef.dialog.responseToServer", $("#modal-list-text-area").val().replace("\n", " "));
}

function modalListLoad(title, subtitle, data, dialogType) {
    let divEntryList = $("#modal-list-panel .modal-list-items");
    let divEntryText = $("#modal-list-panel .modal-list-text");
    $("#modal-list-panel .modal-box-header").html(title);
    $("#modal-list-panel .items-table-header").html(subtitle);
    divEntryList.empty();

    divEntryList.hide();
    divEntryText.hide();
    dialogType = parseInt(dialogType);
    if (dialogType === 1) {
        divEntryList.show();
        data = JSON.parse(decodeURIComponent(data));
        for (let i = 0; i < data.length; i++) {
            if (data[i].data === "no-overflow") {
                divEntryList.append(
                    `<div class="list-item no-overflow" data="not-clickable" onclick="modalListUseRow(this);">${data[i]
                    .Text.replace(/\\/g, '')}</div>`);
            } else {
                divEntryList.append(
                    `<div class="list-item" data="${data[i].Data}" onclick="modalListUseRow(this);">${data[i].Text
                    .replace(/\\/g, '')}</div>`);
            }

        }
    } else if (dialogType === 2) {
        let divTextareaEntry = $("#modal-list-text-area");

        divTextareaEntry.val('');
        divEntryText.show();
        divTextareaEntry.focus();
    }
}

function modalListToggle(state) {
    if (state) {
        $("#modal-list-panel").show();
        //mp.trigger('client.dialog.togglechat', true);
    } else {
        $("#modal-list-panel").hide();
        //mp.trigger('client.dialog.togglechat', false);
    }
}

function escapeHtml(text) {
    var map = {
        '"': '&quot;',
        "'": '&#039;',
        "`": '&#96;'
    };

    return text.replace(/["'`]/g, function(m) { return map[m]; });
}