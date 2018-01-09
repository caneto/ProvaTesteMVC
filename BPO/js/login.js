(function () {

    $('#LoginButton').click(function (e) {
        e.preventDefault();
        abp.ui.setBusy(
            $('#LoginArea'),
            abp.ajax({
                url: abp.appPath + 'Login/Login',
                type: 'POST',
                data: JSON.stringify({
                    usernameOrEmailAddress: $('#EmailAddressInput').val(),
                    password: $('#PasswordInput').val(),
                    rememberMe: $('#RememberMeInput').is(':checked')
                })
            })
        );
    });

})();