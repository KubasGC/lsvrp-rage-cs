var lsvrpVueTattoos = new Vue({
    el: "#lsvrp_tattoos",
    data: {
        show: false,
        choosedTattoo: null,
        tattoos: [
            { id: 5, name: "Black Panthera", price: 500 },
            { id: 3, name: "Black Panthera", price: 500 },
            { id: 7, name: "Black Panthera", price: 500 }
        ]
    },
    methods: {
        rowClick: function(id) {
            this.choosedTattoo = id;
            // todo zmiana tatuażu na ciele
        }
    }
});