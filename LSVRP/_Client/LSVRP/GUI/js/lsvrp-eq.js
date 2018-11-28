var lsvrpVueEq = new Vue({
    el: "#lsvrp_eq",
    data: {
        show: false,
        showSec: true,
        loading: false,
        itemNumbers: [1, 2, 3, 4, 5, 6],
        page: 1,
        choosedItem: null,
        itemsData: []
    },
    methods: {
        checkItemSlot: function(itemSlot) {
            let startI = 0 + (6 * (this.page - 1));
            if (this.itemsData[startI + itemSlot - 1] === undefined) return false;
            return true;
        },
        checkItemSlotEx: function(page) {
            let startI = 0 + (6 * (page - 1));
            if (this.itemsData[startI] === undefined) return false;
            return true;
        },
        getItemData: function(itemSlot) {
            let startI = 0 + (6 * (this.page - 1));
            return this.itemsData[startI + itemSlot - 1];
        },
        selectItem: function(itemSlot) {
            if (!this.checkItemSlot(itemSlot)) return;
            this.choosedItem = itemSlot;
        },
        deselectItem: function() {
            this.choosedItem = null;
        },
        pageUp: function() {
            if (!this.checkItemSlotEx(this.page + 1)) return;
            this.page++;
        },
        pageDown: function() {
            if (this.page - 1 < 1) return;
            this.page--;
        },
        checkAfterItemsLoad: function() {
            if (!this.checkItemSlotEx(this.page)) {
                if (this.page > 1) {
                    this.page--;
                    this.checkAfterItemsLoad();
                }
            }
        },
        itemAction: function(type) {
            if (!this.checkItemSlot(this.choosedItem)) return;
            this.loading = true;

            if (type === 1) mp.trigger("cef.items.useItem", this.getItemData(this.choosedItem).Id);
            else if (type === 2) mp.trigger("cef.items.infoItem", this.getItemData(this.choosedItem).Id);
            else if (type === 3) mp.trigger("cef.items.dropItem", this.getItemData(this.choosedItem).Id);
        }
    },
    watch: {
        show: function(val) {
            if (val === true) {
                $("#lsvrp_eq").css("left", ($(window).width() - $("#lsvrp_eq").outerWidth()) + "px");
            } else {
                $("#lsvrp_eq").css("left", $(window).width() + "px");
            }
        }
    }
});

function LoadItemsData(itemData) {
    lsvrpVueEq.choosedItem = null;
    lsvrpVueEq.loading = false;
    lsvrpVueEq.itemsData = JSON.parse(decodeURIComponent(itemData));
    lsvrpVueEq.checkAfterItemsLoad();
}

function ShowItemsMenu() {
    lsvrpVueEq.choosedItem = null;
    lsvrpVueEq.loading = false;
    lsvrpVueEq.show = true;
}

function HideItemsMenu() {
    lsvrpVueEq.show = false;
}

$(document).keydown(function(e) {
    if (!lsvrpVueEq.show) return;
    if (lsvrpVueEq.loading) return;

    let pressedKey = parseInt(e.key);
    if (Number.isNaN(pressedKey)) return;

    if (lsvrpVueEq.choosedItem === null && (pressedKey > 0 && pressedKey < 9)) {
        if (pressedKey > 0 && pressedKey < 7) {
            lsvrpVueEq.selectItem(pressedKey);
            return;
        }
        if (pressedKey === 7) {
            lsvrpVueEq.pageDown();
            return;
        }
        if (pressedKey === 8) {
            lsvrpVueEq.pageUp();
            return;
        }

    }
    if (lsvrpVueEq.choosedItem !== null && (pressedKey > 0 && pressedKey < 5)) {
        if (pressedKey === 1) {
            lsvrpVueEq.itemAction(1);
            return;
        }
        if (pressedKey === 2) {
            lsvrpVueEq.itemAction(2);
            return;
        }
        if (pressedKey === 3) {
            lsvrpVueEq.itemAction(3);
            return;
        }
        if (pressedKey === 4) {
            lsvrpVueEq.deselectItem();
            return;
        }
    }

});