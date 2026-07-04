function MovieViewController() {

    this.ViewName = "Movies";
    this.API_ControllerName = "Movies";

    this.InitView = function () {
        this.LoadTable();

         $("#btnCreate").click(function () {
        var vc = new MovieViewController();
        vc.Create();
        });

        $("#btnUpdate").click(function () {
            var vc = new MovieViewController();
            vc.Update();
        });

        $("#btnDelete").click(function () {
            var vc = new MovieViewController();
            vc.Delete();
        });
    }

    this.LoadTable = function () {

        var ca = new ControlActions();

        var endPoint = this.API_ControllerName + "/RetrieveAll";
        var urlService = ca.GetUrlApiService(endPoint);

        var columns = [];

        columns[0] = { "data": "id", "title": "Id" };
        columns[1] = { "data": "title", "title": "Título" };
        columns[2] = { "data": "synopsis", "title": "Sinopsis" };
        columns[3] = { "data": "gender", "title": "Género" };
        columns[4] = { "data": "clasificacion", "title": "Clasificación" };
        columns[5] = { "data": "image", "title": "Imagen" };
        columns[6] = { "data": "status", "title": "Estado" };
        columns[7] = { "data": "created", "title": "Fecha de Registro" };

        $("#tblMovies").dataTable({
            ajax: {
                url: urlService,
                dataSrc: ""
            },
            columns: columns
        });
    }
    this.Create = function () {

    var movieDTO = {};

    movieDTO.created = "2026-01-01";
    movieDTO.updated = "2026-01-01";

    movieDTO.title = $("#txtTitle").val();
    movieDTO.synopsis = $("#txtSynopsis").val();
    movieDTO.gender = $("#txtGender").val();
    movieDTO.clasificacion = $("#txtClasificacion").val();
    movieDTO.image = $("#txtImage").val();
    movieDTO.status = $("#txtStatus").val();

    var ca = new ControlActions();

    var endPoint = this.API_ControllerName + "/Create";

    ca.PostToAPI(endPoint, movieDTO, function () {

        $("#tblMovies").DataTable().ajax.reload();

    });
}
this.Delete = function () {
    var movieDTO = {}
    // set con valores default
    movieDTO.created = "2026-01-01";
    movieDTO.updated = "2026-01-01";

    //set de valores capturados desde el formulario
    movieDTO.id = $('#txtId').val(); 
    movieDTO.title = $('#txtTitle').val();
    movieDTO.synopsis = $('#txtSynopsis').val();
    movieDTO.gender = $('#txtGender').val();
    movieDTO.clasificacion = $('#txtClasificacion').val();
    movieDTO.image = $('#txtImage').val();
    movieDTO.status = $('#txtStatus').val();

    //enviar data al API
    var ca = new ControlActions();
    var endPoint = this.API_ControllerName + "/Delete";
    
    ca.PostToAPI(endPoint, movieDTO, function () {
        //recargar la tabla
        $("#tblMovies").DataTable().ajax.reload();
    });
    }
     this.Update = function () {
    var movieDTO = {}
    // set con valores default
    movieDTO.created = "2026-01-01";
    movieDTO.updated = "2026-01-01";

    //set de valores capturados desde el formulario
    movieDTO.id = $('#txtId').val(); 
    movieDTO.title = $('#txtTitle').val();
    movieDTO.synopsis = $('#txtSynopsis').val();
    movieDTO.gender = $('#txtGender').val();
    movieDTO.clasificacion = $('#txtClasificacion').val();
    movieDTO.image = $('#txtImage').val();
    movieDTO.status = $('#txtStatus').val();

    //enviar data al API
    var ca = new ControlActions();
    var endPoint = this.API_ControllerName + "/Update";
    
    ca.PostToAPI(endPoint, movieDTO, function () {
        //recargar la tabla
        $("#tblMovies").DataTable().ajax.reload();
    });
    }
}

$(document).ready(function () {
    var vc = new MovieViewController();
    vc.InitView();
});