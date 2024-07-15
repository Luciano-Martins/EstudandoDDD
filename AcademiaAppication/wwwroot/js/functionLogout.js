
$('.btnSair').click(function () {
    logout();
});

function logout() {
    if (confirm("Realmente deseja sair?")) {
        var Url = "/Account/LogOut";
        $.ajax({
            type: "POST",
            url: Url,
            success: function () {

            }
        });
        alert("Usuário desconectado com sucesso!");
        window.location.href = "/Home/Index";
    }
}