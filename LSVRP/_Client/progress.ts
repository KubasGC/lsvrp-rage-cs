import * as Ui from "./ui"

export function load(): void {
    mp.events.add("client.progress.start",
        function(name: string) {
            Ui.getNewUiBrowser().execute(`lsvrpVueProgress.Start(\"${name}\");`);
        });

    mp.events.add("client.progress.stop",
        function() {
            Ui.getNewUiBrowser().execute(`lsvrpVueProgress.Stop();`);
        });

    mp.events.add("client.progress.update",
        function(progress: number) {
            Ui.getNewUiBrowser().execute(`lsvrpVueProgress.Update(${progress});`);
        });
}