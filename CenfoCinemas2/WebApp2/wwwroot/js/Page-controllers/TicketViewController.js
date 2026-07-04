// Clase que controla la vista de Tickets
function TicketViewController() {

    this.ViewName = "Tickets";
    this.API_ControllerName = "Tickets";

    // Método constructor
    this.InitView = function () {
        this.LoadTable();
        this.LoadMovies();
    }

    //asociar metodo de create al boton
    $("#btnCreate").click(function () {
        var vc = new TicketViewController();
        vc.Create();
    });


    $("#btnUpdate").click(function () {
        var vc = new TicketViewController();
        vc.Update();
    });

    $("#btnDelete").click(function () {
        var vc = new TicketViewController();
        vc.Delete();
    });


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

this.Create = function () {

    var ticketDTO = {};

    ticketDTO.created = "2026-01-01";
    ticketDTO.updated = "2026-01-01";

    ticketDTO.price = $("#txtPrice").val();
    ticketDTO.schedule = $("#txtSchedule").val();
    ticketDTO.date = $("#txtDate").val();
    ticketDTO.type = $("#txtType").val();

    ticketDTO.movie = {};
    ticketDTO.movie.id = $("#txtMovieId").val();

    var ca = new ControlActions();

    var endPoint = this.API_ControllerName + "/Create";

    ca.PostToAPI(endPoint, ticketDTO, function () {

        $("#tblTickets").DataTable().ajax.reload();

    });
}


this.Delete = function () {
    var ticketDTO = {}
    // set con valores default
    ticketDTO.created = "2026-01-01";
    ticketDTO.updated = "2026-01-01";

    //set de valores capturados desde el formulario
    ticketDTO.id = $('#txtId').val(); 
    ticketDTO.price = $('#txtPrice').val();
    ticketDTO.schedule = $('#txtSchedule').val();
    ticketDTO.date = $('#txtDate').val();
    ticketDTO.type = $('#txtType').val();
    ticketDTO.movie = {};
    ticketDTO.movie.id = $('#txtMovieId').val();

    //enviar data al API
    var ca = new ControlActions();
    var endPoint = this.API_ControllerName + "/Delete";
    
    ca.PostToAPI(endPoint, ticketDTO, function () {
        //recargar la tabla
        $("#tblTickets").DataTable().ajax.reload();
    });
    }

     this.Update = function () {
    var ticketDTO = {}
    // set con valores default
    ticketDTO.created = "2026-01-01";
    ticketDTO.updated = "2026-01-01";

    //set de valores capturados desde el formulario
    ticketDTO.id = $('#txtId').val(); 
    ticketDTO.price = $('#txtPrice').val();
    ticketDTO.schedule = $('#txtSchedule').val();
    ticketDTO.date = $('#txtDate').val();
    ticketDTO.type = $('#txtType').val();
    ticketDTO.movie = {};
    ticketDTO.movie.id = $('#txtMovieId').val();
  

    //enviar data al API
    var ca = new ControlActions();
    var endPoint = this.API_ControllerName + "/Update";
    
    ca.PostToAPI(endPoint, ticketDTO, function () {
        //recargar la tabla
        $("#tblTickets").DataTable().ajax.reload();
    });
    }

    //metodo para cargar las pelis al seleccionar una, al momento de crear el ticket
    this.LoadMovies = function () {

    var ca = new ControlActions();

    ca.GetToApi("Movies/RetrieveAll", function (movies) {

        $("#txtMovieId").empty();

        $("#txtMovieId").append(
            '<option value="">Seleccione una película</option>'
        );

        $.each(movies, function (index, movie) {

            $("#txtMovieId").append(
                '<option value="' + movie.id + '">' +
                movie.title +
                '</option>'
            );

        });

    });

}
}

// Instanciar la clase
$(document).ready(function () {
    var vc = new TicketViewController();
    vc.InitView();
});
