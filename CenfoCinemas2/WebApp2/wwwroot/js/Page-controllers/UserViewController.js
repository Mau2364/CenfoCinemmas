//clase que controla la vista de users.cshtml

//definir una clase js utilizando prototype

function UserViewController() {
    this.ViewName = "Users";

    //API que vamos a consumir desde esta vista
    this.API_ControllerName = "Users";

    //metodo constructor
    this.InitView = function () {
        //invocar la carga de la tabla
        this.LoadTable();
    }

    //metodo para cargar la tabla
    this.LoadTable = function () {
        var ca = new ControlActions;


        //https://localhost:7166/api/Users/RetrieveAl
        //Endpoint que vamos a acceder
        var endPoint = this.API_ControllerName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(endPoint);

        //match de llas columnas
        var columns = [];
        columns[0] = { "data": 'id', "title": 'Id' }; // el id de data viene del json, el de title tiene que matchear con el de la  vista, en este caso Users,cshtml
        columns[1] = { "data": 'userCode', "title": 'Codigo' }; 
        columns[2] = { "data": 'name', "title": 'Nombre' }; 
        columns[3] = { "data": 'email', "title": 'Correo' }; 
        columns[4] = { "data": 'status', "title": 'Estado' }; 
        columns[5] = { "data": 'dateBirth', "title": 'Fecha de Nacimiento' }; 
        columns[6] = { "data": 'created', "title": 'Registro' }; 

        // convertir la tabla plana en una mas dinamica
        $("#tblUsers").dataTable({
            "ajax": {
                "url": urlService,
                "dataSrc": ""
            },
            "columns": columns
        });
    }
}

//instanciar la clase
$(document).ready(function () {
    var userViewController = new UserViewController();
    userViewController.InitView();
});