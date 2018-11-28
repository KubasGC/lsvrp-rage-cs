import * as UiClass from "./ui"
import * as CefClass from "./cef"

let phone: boolean = false;

export function load() {
    /*mp.keys.bind(40, false, function () {
        if (!CefClass.getChatFocused()) {
            if(phone)
            {
                mp.events.callRemote("server.phone.show", false);
                phone = false;
            }else{
                mp.events.callRemote("server.phone.show", true);
                phone = true;
            }
        }
    });

    mp.events.add("client.phone.show", function(state: boolean, gsmName: string) {
        if(state)
        {
            UiClass.getUiBrowser().execute(`phoneSetGsmName('${gsmName}');`);
        }
        UiClass.getUiBrowser().execute(`phoneToggle(${state});`);
    });

    mp.events.add("client.phone.loadcontacts", function(conData: any) {
        let func = `LoadContacts('${JSON.stringify(conData)}');`;
        UiClass.getUiBrowser().execute(func);
    });

    mp.events.add("client.phone.prepareContactInfo", function(contactId: number) {
        mp.events.callRemote("server.phone.prepareContactInfo", contactId);
    });

    mp.events.add("client.phone.showContactInfo", function(name: string, number: string) {
        UiClass.getUiBrowser().execute(`showContactInfo('${name}', '${number}');`);
    });

    mp.events.add("client.phone.savePremiumWallpaper", function(link: string) {
        mp.events.callRemote("server.phone.savePremiumWallpaper", link);
    });

    mp.events.add("client.phone.saveStandardWallpaper", function(wallpaperId: number){
        mp.events.callRemote("server.phone.saveStandardWallpaper", wallpaperId);
    });

    mp.events.add("client.phone.initializePhone", function(wallpaperId: number, wallpaperLink: string, donator: boolean){
        if(donator == true && wallpaperLink != null)
        {
            UiClass.getUiBrowser().execute(`setPremiumWallpaper('${wallpaperLink}');`);
        }else{
            UiClass.getUiBrowser().execute(`changeWallpaper(${wallpaperId});`);
        }
    });

    mp.events.add("client.phone.prepareConversations", function(){
        mp.events.callRemote("server.phone.prepareConversations");
    });

    mp.events.add("client.phone.loadconversations", function(conversationsData: any){
        UiClass.getUiBrowser().execute(`loadConversations('${JSON.stringify(conversationsData)}');`);
    });

    mp.events.add("client.phone.prepareMessages", function(convId: number, conName: string) {
        mp.events.callRemote("server.phone.prepareMessages", convId, conName);
    });

    mp.events.add("client.phone.showMessages", function(messagesData: any) {
        UiClass.getUiBrowser().execute(`loadMessages('${JSON.stringify(messagesData)}');`);
    });

    mp.events.add("client.phone.sendMessage", function(message: string, contactId: number){
        mp.events.callRemote("server.phone.sendMessage", [message, contactId]);
    });*/
}