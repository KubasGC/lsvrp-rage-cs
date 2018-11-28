const items_maxOnPage = 8;
const items_maxProxOnPage = 4;

let items_sItem = 0;
let items_sProxItem = 0;
let items_blockedWindow = false;
let items_content = [];
let items_proxContent = [];
let items_page = 1;
let items_proxPage = 1;

function SelectItem(row) {
    if (items_blockedWindow) {
        return;
    }
    let itemId = $(row).attr('itemid');
    if (!Number.isNaN(itemId)) {
        if (itemId !== items_sItem) {
            RemoveSelectedItem();
            $(row).addClass('active');
            CreateSubmenu(row);
            items_sItem = itemId;
        } else {
            RemoveSelectedItem();
            RemoveSubmenu();
            items_sItem = 0;
        }

    }
}

function ToggleItemSpinner(toggle) {
    if (toggle) {
        $("#items-panel .loading").fadeIn(100);
    } else {
        $("#items-panel .loading").fadeOut(100);
    }
}

function CreateSubmenu(row) {
    let selectedItem = $(".items-submenu");
    let mainOffset = $(selectedItem).parent().offset();
    if (typeof selectedItem !== typeof undefined) {
        let rowOffset = $(row).offset();
        selectedItem.show();
        selectedItem.css("position", "absolute");
        selectedItem.css("top", rowOffset.top - mainOffset.top + 40);
        selectedItem.css("left", rowOffset.left - mainOffset.left + 440);
    }
}

function UseSubMenu(type) {
    if (items_sItem !== 0 && !items_blockedWindow) {
        switch (type) {
        case "use":
            ToggleBlock(true);
            mp.trigger("cef.items.useItem", items_sItem);
            break;

        case "drop":
            ToggleBlock(true);
            mp.trigger("cef.items.dropItem", items_sItem);
            break;

        case "info":
            ToggleBlock(true);
            mp.trigger("cef.items.infoItem", items_sItem);
            break;

        case "offer":
            // todo
            break;

        case "close":
            RemoveSelectedItem();
            RemoveSubmenu();
            items_sItem = 0;
            break;
        }
    }
}

function RemoveSubmenu() {
    let selectedItem = $(".items-submenu");
    if (typeof selectedItem !== typeof undefined) {
        selectedItem.hide();
    }
}

function RemoveSelectedItem() {
    let selectedItem = $(".items-table-content .items-table-row.active");
    if (typeof selectedItem !== typeof undefined) {
        selectedItem.removeClass("active");
        items_sItem = 0;
    }
}

function ToggleBlock(state) {
    ToggleItemSpinner(state);
    items_blockedWindow = state;
}

function ToggleItems(state) {
    if (state) {
        $("#items-panel").fadeIn(200);
    } else {
        $("#items-panel").fadeOut(200);
    }
}

function LoadItems(items, proxItems = '[]') {
    RemoveSubmenu();
    Items_RemoveProxSubmenu();

    items_sItem = 0;
    items_sProxItem = 0;

    items_page = 1;
    items_proxPage = 1;

    items_content = JSON.parse(items);
    items_proxContent = JSON.parse(proxItems);
    Items_BuildItemList();
    Items_BuildProxItemList();

    ToggleBlock(false);
}

function Items_BuildItemList() {
    let selectedItem = $(".items-table-content");
    $(".items-table-page").html(`strona ${items_page} z ${Items_GetPagesCount()}`);
    selectedItem.empty();
    RemoveSubmenu();
    for (let i = 0; i < items_maxOnPage; i++) {
        let index = i + ((items_page - 1) * items_maxOnPage);
        if (items_content.length > index) {
            selectedItem.append(
                `<div class="items-table-row${items_content[index].ItemUsed ? " using" : ""}" itemid="${
                items_content[index].ItemId}" onclick="SelectItem(this)"><div class="name">${
                items_content[index].ItemName} (${items_content[index].ItemId})</div><div class="info">${
                items_content[index].ItemInfo}</div></div>`);
        } else {
            selectedItem.append(`<div class="items-table-row empty"></div>`);
        }
    }
}

/**
 * @return {int}
 */
function Items_GetPagesCount() {
    return Math.ceil(items_content.length / items_maxOnPage);
}

function Items_UpperPage() {
    if (items_blockedWindow) {
        return;
    }
    items_page++;
    if (items_page > Items_GetPagesCount()) {
        items_page = Items_GetPagesCount();
        if (items_page === 0) {
            items_page = 1;
        }
    }
    Items_BuildItemList();
}

function Items_LowerPage() {
    if (items_blockedWindow) {
        return;
    }
    items_page--;
    if (items_page < 1) {
        items_page = 1;
    }
    Items_BuildItemList();
}

// Prox Items
function Items_SelectProximityItem(row) {
    if (items_blockedWindow) {
        return;
    }
    let itemId = $(row).attr('itemid');
    if (!Number.isNaN(itemId)) {
        if (itemId !== items_sProxItem) {
            Items_RemoveProxSelectedItem();
            $(row).addClass('active');
            Items_CreateProxSubmenu(row);
            items_sProxItem = itemId;
        } else {
            Items_RemoveProxSelectedItem();
            Items_RemoveProxSubmenu();
            items_sProxItem = 0;
        }
    }
}

function Items_RemoveProxSubmenu() {
    let selectedItem = $(".items-proximity-submenu");
    if (typeof selectedItem !== typeof undefined) {
        selectedItem.hide();
    }
}

function Items_RemoveProxSelectedItem() {
    let selectedItem = $(".items-proximity-content .items-table-row.active");
    if (typeof selectedItem !== typeof undefined) {
        selectedItem.removeClass("active");
        items_sProxItem = 0;
    }
}

function Items_CreateProxSubmenu(row) {
    let selectedItem = $(".items-proximity-submenu");
    let mainOffset = $(selectedItem).parent().offset();
    if (typeof selectedItem !== typeof undefined) {
        let rowOffset = $(row).offset();
        selectedItem.show();
        selectedItem.css("position", "absolute");
        selectedItem.css("top", rowOffset.top - mainOffset.top + 40);
        selectedItem.css("left", rowOffset.left - mainOffset.left + 440);
    }
}

function Items_UseProxSubmenu(type) {
    if (items_sProxItem !== 0 && !items_blockedWindow) {
        switch (type) {
        case 'pick':
            items_blockedWindow = true;
            ToggleItemSpinner(true);
            mp.trigger("cef.items.pickItem", items_sProxItem);
            break;

        case 'close':
            Items_RemoveProxSelectedItem();
            Items_RemoveProxSubmenu();
            items_sProxItem = 0;
            break;
        }
    }
}

function Items_BuildProxItemList() {
    let selectedItem = $(".items-proximity-content");
    if (items_proxContent.length > 0) {
        $(".items-proximity-not-found").hide();
        $(".items-proximity-page").html(`strona ${items_proxPage} z ${Items_GetProxPagesCount()}`);
        selectedItem.empty();
        Items_RemoveProxSubmenu();
        for (let i = 0; i < items_maxProxOnPage; i++) {
            let index = i + ((items_proxPage - 1) * items_maxProxOnPage);
            if (items_proxContent.length > index) {
                selectedItem.append(
                    `<div class="items-table-row" itemid="${items_proxContent[index].ItemId
                    }" onclick="Items_SelectProximityItem(this)"><div class="name">${items_proxContent[index].ItemName
                    } (${items_proxContent[index].ItemId})</div><div class="info">${items_proxContent[index].ItemInfo
                    }</div></div>`);
            } else {
                selectedItem.append(`<div class="items-table-row empty"></div>`);
            }
        }
    } else {
        $(".items-proximity-page").html(`strona 0 z 0`);
        $(".items-proximity-not-found").show();
        selectedItem.empty();
        Items_RemoveProxSubmenu();
    }

}

function Items_GetProxPagesCount() {
    return Math.ceil(items_proxContent.length / items_maxProxOnPage);
}

function Items_ProxUpperPage() {
    if (items_blockedWindow) {
        return;
    }
    items_proxPage++;
    if (items_proxPage > Items_GetProxPagesCount()) {
        items_proxPage = Items_GetProxPagesCount();
        if (items_proxPage === 0) {
            items_proxPage = 1;
        }
    }
    Items_BuildProxItemList();
}

function Items_ProxLowerPage() {
    if (items_blockedWindow) {
        return;
    }
    items_proxPage--;
    if (items_proxPage < 1) {
        items_proxPage = 1;
    }
    Items_BuildProxItemList();
}

function escapeHtml(text) {
    var map = {
        '"': '&quot;',
        "'": '&#039;',
        "`": '&#96;'
    };

    return text.replace(/["'`]/g, function(m) { return map[m]; });
}