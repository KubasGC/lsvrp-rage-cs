let listContent = [];
let selectedPage = 1;
let maxOnModalPage = 10;

function ModalCreateList(header, data, maxOnModal) {
    maxOnModalPage = maxOnModal;
    $("#modal-panel").hide();
    $(".modal-header").html(header);
    listContent = JSON.parse(decodeURIComponent(data));
    selectedPage = 1;
    ModalGenerateList();
    $("#modal-panel").fadeIn(200);
}

function ModalHide() {
    $("#modal-panel").fadeOut(200);
}

function ModalGenerateList() {
    $(".modal-table-content").empty();
    let maxPages = Math.ceil(listContent.length / maxOnModalPage);
    $(".modal-table-page").html(`strona ${selectedPage} z ${maxPages}`);
    for (let i = 0; i < maxOnModalPage; i++) {
        var output = "";
        var index = i + ((selectedPage - 1) * maxOnModalPage);
        if (listContent.length > index) {
            output =
                `<div class="first">${listContent[index] !== undefined ? listContent[index].First : ""
                }</div><div class="second">${listContent[index] !== undefined ? listContent[index].Second : ""}</div>`;
        }
        $(".modal-table-content")
            .append(`<div class="modal-table-row ${i === 0
                ? "no-border"
                : i === maxOnModalPage - 1
                ? "border-bottom"
                : ""}"> ${output}</div>`);
    }
}

function ModalLowerPage() {
    selectedPage--;
    if (selectedPage < 1) {
        selectedPage = 1;
    }
    ModalGenerateList();
}

function ModalUpperPage() {
    let maxPages = Math.ceil(listContent.length / maxOnModalPage);
    selectedPage++;
    if (selectedPage > maxPages) {
        selectedPage = maxPages;
        if (selectedPage === 0) {
            selectedPage = 1;
        }
    }
    ModalGenerateList();
}

function escapeHtml(text) {
    var map = {
        '"': '&quot;',
        "'": '&#039;',
        "`": '&#96;'
    };

    return text.replace(/["'`]/g, function(m) { return map[m]; });
}