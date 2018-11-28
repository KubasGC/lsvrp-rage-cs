import * as UiClass from "./ui"

export function load(): void {
    mp.events.add("client.ui.showNotification",
        function() {
            if (arguments[1] == 1) {
                UiClass.getNotificationBrowser().execute(
                    `iziToast.info({ title: 'Informacja', message: '${arguments[0]
                    }', position: 'topRight', theme: 'light', progressBar: true, close: false, transitionIn: 'bounceInLeft', transitionOut: 'fadeOutUp', pauseOnHover: false, timeout: 6000 });`);
            } else if (arguments[1] == 2) {
                UiClass.getNotificationBrowser().execute(
                    `iziToast.warning({ title: 'Ostrzeżenie', message: '${arguments[0]
                    }', position: 'topRight', theme: 'light', progressBar: true, close: false, transitionIn: 'bounceInLeft', transitionOut: 'fadeOutUp', pauseOnHover: false, timeout: 6000 });`);
            } else if (arguments[1] == 3) {
                UiClass.getNotificationBrowser().execute(
                    `iziToast.error({ title: 'Błąd', message: '${arguments[0]
                    }', position: 'topRight', theme: 'light', progressBar: true, close: false, transitionIn: 'bounceInLeft', transitionOut: 'fadeOutUp', pauseOnHover: false, timeout: 6000 });`);
            } else if (arguments[1] == 4) {
                UiClass.getNotificationBrowser().execute(
                    `iziToast.success({ title: 'Użycie', message: '${arguments[0]
                    }', position: 'topRight', theme: 'light', progressBar: true, close: false, transitionIn: 'bounceInLeft', transitionOut: 'fadeOutUp', pauseOnHover: false, timeout: 6000 });`);
            }
        });
}