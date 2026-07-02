function MovieViewController() {

    this.ViewName = "Movies";
    this.API_ControllerName = "Movies";

    this.InitView = function () {
        this.LoadTable();
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
}

$(document).ready(function () {
    var vc = new MovieViewController();
    vc.InitView();
});