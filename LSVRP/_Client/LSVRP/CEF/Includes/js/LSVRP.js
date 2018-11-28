$(document).bind('selectstart dragstart',
    function(e) {
        e.preventDefault();
        return false;
    });

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

jQuery(function($) {
    $("#Wplata").click(function() {
        var Kwota = $("#Kwota").val();
        resourceCall("Bank_CashIn", Kwota);
    });

    $("#Wyplata").click(function() {
        var Kwota = $("#Kwota").val();
        resourceCall("Bank_CashOut", Kwota);
    });

    $("#bank-container").center();
});

function Load_Info(accnum, balance) {
    $("#AccNum").val(accnum);
    $("#AccBalance").val('$' + balance);
}

function dragMoveListener(event) {
    var target = event.target,
        // keep the dragged position in the data-x/data-y attributes
        x = (parseFloat(target.getAttribute('data-x')) || 0) + event.dx,
        y = (parseFloat(target.getAttribute('data-y')) || 0) + event.dy;

    // translate the element
    target.style.webkitTransform =
        target.style.transform =
        'translate(' + x + 'px, ' + y + 'px)';

    // update the posiion attributes
    target.setAttribute('data-x', x);
    target.setAttribute('data-y', y);
}

interact('.draggable')
    .draggable({
        // enable inertial throwing
        inertia: true,
        // keep the element within the area of it's parent
        restrict: {
            restriction: "parent",
            endOnly: true,
            elementRect: { top: 0, left: 0, bottom: 1, right: 1 }
        },
        // enable autoScroll
        autoScroll: true,

        // call this function on every dragmove event
        onmove: dragMoveListener
    }).allowFrom('.draggable-handler');;

// BANK
function BankToggle(state, number, balance) {
    if (state) {
        $("#bank-container").fadeIn(500);
        $("#AccNum").val(number);
        $("#AccBalance").val(balance);
    } else {
        $("#bank-container").fadeOut(500);
    }
}


// EQUIPMENT
function EquipmentToggle(state) {
    if (state) {
        $("#eq-body").show("drop");
    } else {
        $("#eq-body").hide("drop");
    }
}

function ReloadItems(ItemsData, page, allPages, choosedItem, choosedOption) {
    $("#eq-items").html("");
    $("#eq-choosedpage").html(`strona ${page} z ${allPages}`);
    var Items = JSON.parse(ItemsData);
    if (Items.length > 0) {
        for (var i = 0; i < Items.length; i++) {
            var ItemsAction = "";
            if (Items[i].active && choosedItem) {
                ItemsAction =
                    `<div class="info"><ul><li class="${choosedOption == 1 ? 'active' : ''
                    }">UŻYJ PRZEDMIOT</li><li class="${choosedOption == 2 ? 'active' : ''
                    }">ODŁÓŻ PRZEDMIOT</li><li class="${choosedOption == 3 ? 'active' : ''
                    }">INFORMACJE O PRZEDMIOCIE</li><li class="${choosedOption == 4 ? 'active' : ''
                    }">WRÓĆ</li></ul></div>`;
            }
            $("#eq-items").append(
                `<div class="row eq-content${Items[i].Used ? ' using' : ''}${Items[i].active ? ' active' : ''}" >
                ${ItemsAction}
                <div class="col s5 name">${Items[i].Name}</div>
                <div class="col s3 center-align">${Items[i].Id}</div>
                <div class="col s2 center-align">${Items[i].Value1}</div>
                <div class="col s2 center-align">${Items[i].Value2}</div>
            </div>`);
        }
    } else {
        $("#eq-items").html(`<div class="row eq-content center-align">Nie posiadasz żadnych przedmiotów</div>`);
    }
}

// WEAZEL NEWS
function SetWeazelNewsText(text) {
    $("#wn-text").html(text);
}