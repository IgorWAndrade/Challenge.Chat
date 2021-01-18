
function ChamarModalTemplate(Action, Controller) {
    $.ajax({
        url: MontarURL(Action, Controller),
        method: 'GET',
        beforeSend: function () {
            $("#partialViewTemplate").empty();
        },
        success: function (partial) {
            $("#partialViewTemplate").html(partial);
        },
        complete: function () {
            $('#modalTemplate').modal('show');
        }
    });
}

function MontarURL(action, controller = 'Base') {

    var url = '../' + controller;
    if (Validar(action)) {
        url += '/' + action;
    }
    return url;
}

function Validar(valor) {
    if (valor === null) {
        return false;
    }
    else if (valor === "") {
        return false;
    }
    else if (valor === undefined) {
        return false;
    }
    else if (valor === "0") {
        return false;
    }
    else if (valor === 0) {
        return false;
    }
    else if (valor.length === 0) {
        return false;
    }
    else {
        let number = parseInt(valor);

        if (number < 0) {
            return false;
        }
        return true;
    }
}