function CreateOffer(offerText, offerPrice) {
    $("#offers-panel").hide();
    $("#offers-panel .offers-title").html(offerText);
    $("#offers-panel .offers-price").html(`$${offerPrice}`);
    ShowOffer();
}

function ShowOffer() {
    $("#offers-panel").fadeIn(200);
}

function HideOffer() {
    $("#offers-panel").fadeOut(200);
}

function AcceptOfferCash() {
    mp.trigger("cef.offers.acceptOffer", 0);
    HideOffer();
}

function AcceptOfferCard() {
    mp.trigger("cef.offers.acceptOffer", 1);
    HideOffer();
}

function DiscardOffer() {
    mp.trigger("cef.offers.discardOffer");
    HideOffer();
}

function escapeHtml(text) {
    var map = {
        '"': '&quot;',
        "'": '&#039;',
        "`": '&#96;'
    };

    return text.replace(/["'`]/g, function(m) { return map[m]; });
}