var lsvrpLoginVue = new Vue({
    el: "#lsvrp_login",
    data: {
        show: true,
        username: "",
        password: "",
        rememberMe: false,
        blocked: false,
        buttonText: "ZALOGUJ"
    },
    methods: {
        onLogin: function() {
            if (this.blocked) return;
            if (this.username.length < 3 || this.password.length < 3) return;

            this.blocked = true;
            this.buttonText = "LOGOWANIE...";
            mp.trigger("cef.login.TryLogin", this.username, this.password, this.rememberMe);
        }
    }
});

function LoginShow() {
    lsvrpLoginVue.show = true;
    input2.focus();
}

function LoginFillForm(username, password) {
    lsvrpLoginVue.username = username;
    lsvrpLoginVue.password = password;
    lsvrpLoginVue.rememberMe = true;
}

function LoginUnlockButton() {
    lsvrpLoginVue.buttonText = "ZALOGUJ";
    lsvrpLoginVue.blocked = false;
}

function LoginHide() {
    lsvrpLoginVue.show = false;
}