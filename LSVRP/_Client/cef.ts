/// <reference path="@types/index.d.ts" />

import * as Ui from "./ui"

export let chatFocused: boolean = false;
export let chatBlocked: boolean = false;

export function load() {
    mp.events.add("cef.items.useItem",
        function() {
            mp.events.callRemote("server.items.useItem", arguments[0]);
        });

    mp.events.add("cef.items.dropItem",
        function() {
            mp.events.callRemote("server.items.dropItem", arguments[0]);
        });

    mp.events.add("cef.items.infoItem",
        function() {
            mp.events.callRemote("server.items.infoItem", arguments[0]);
        });

    mp.events.add("cef.items.pickItem",
        function() {
            mp.events.callRemote("server.items.pickItem", arguments[0]);
        });

    mp.events.add("cef.global.hideCursor",
        function() {
            mp.gui.cursor.visible = false;
        });

    mp.events.add("cef.offers.acceptOffer",
        function() {
            mp.events.callRemote("server.offers.acceptOffer", arguments[0]);
            mp.gui.cursor.visible = false;
        });

    mp.events.add("cef.offers.discardOffer",
        function() {
            mp.events.callRemote("server.offers.discardOffer");
            mp.gui.cursor.visible = false;
        });

    mp.events.add("cef.chat.focusChat",
        function() {
            chatFocused = arguments[0];
        });

    mp.events.add("client.penalty.show",
        function(data: string) {
            const jData = JSON.parse(data);
            Ui.getNewUiBrowser()
                .execute(
                    `AddPenalty('${encodeURIComponent(jData.Type)}', '${encodeURIComponent(jData.Client)}', '${
                    encodeURIComponent(jData.Admin)}', '${encodeURIComponent(jData.Reason)}');`);
        });
}

export function getChatFocused(): boolean {
    return chatFocused;
}

export function blockChat(state: boolean): void {
    chatBlocked = state;
    mp.gui.execute(`blockChat(${chatBlocked});`);
}

export function isChatBlocked(): boolean {
    return chatBlocked;
}