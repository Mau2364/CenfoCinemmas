// Clase que controla la vista de Tickets
function TicketViewController() {

    this.ViewName = "Tickets";
    this.API_ControllerName = "Tickets";

    // Método constructor
    this.InitView = function () {
        this.LoadTable();
    }

    // Método para cargar la tabla
    this.LoadTable = function () {

        var ca = new ControlActions();

        // Endpoint de la API
        var endPoint = this.API_ControllerName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(endPoint);

        // Match de las columnas
        var columns = [];

        columns[0] = { "data": "id", "title": "Id" };
        columns[1] = { "data": "price", "title": "Precio" };
        columns[2] = { "data": "schedule", "title": "Horario" };
        columns[3] = { "data": "date", "title": "Fecha" };
        columns[4] = { "data": "type", "title": "Tipo" };
        columns[5] = { "data": "movie.title", "title": "Película" };
        columns[6] = { "data": "created", "title": "Fecha de Registro" };

        // Convertir la tabla en una DataTable
        $("#tblTickets").dataTable({
            ajax: {
                url: urlService,
                dataSrc: ""
            },
            columns: columns
        });
    }
}

// Instanciar la clase
$(document).ready(function () {
    var vc = new TicketViewController();
    vc.InitView();
});