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
    
          //asociar metodo de create al boton
        $("#btnCreate").click(function () {
            var vc = new UserViewController();
            vc.Create();
        });

        $("#btnUpdate").click(function () {
            var vc = new UserViewController();
            vc.Update();
        });

        $("#btnDelete").click(function () {
            var vc = new UserViewController();
            vc.Delete();
        });
    }
    //metodo para cargar la tabla
    this.LoadTable = function () {
        var ca = new ControlActions();
        
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
        columns[4] = { "data": 'phoneNumber', "title": 'Telefono' };
        columns[5] = { "data": 'status', "title": 'Estado' }; 
        columns[6] = { "data": 'dateBirth', "title": 'Fecha de Nacimiento' }; 
        columns[7] = { "data": 'created', "title": 'Registro' }; 

        // convertir la tabla plana en una mas dinamica
        $("#tblUsers").dataTable({
            "ajax": {
                "url": urlService,
                "dataSrc": ""
            },
            "columns": columns
        });


        //asignar dentro del datatable, evento del dto seleccionado con el form
        $('#tblUsers tbody').on('click', 'tr', function () { //tr son table rows, tbody es el cuerpo de la tabla
            var row = $(this).closest('tr');
            //extraer los datos de la fila seleccionada
            var UserDTO = $('#tblUsers').DataTable().row(row).data();
            // Llenar el formulario con los datos del usuario seleccionado
            $('#txtId').val(UserDTO.id);
            $('#txtUserCode').val(UserDTO.userCode);
            $('#txtName').val(UserDTO.name);
            $('#txtEmail').val(UserDTO.email);
            $('#txtPhoneNumber').val(UserDTO.phoneNumber);
            $('#txtStatus').val(UserDTO.status);
            $('#txtPassword').val(UserDTO.password);

            //formato para la fecha de nacimiento
            var onlyDate= UserDTO.dateBirth.split("T");
            $('#txtDateBirth').val(onlyDate[0]);
        });
    }
    this.Create = function () {
        var userDTO = {};
        //set de valores por defecto
        userDTO.created = "2026-01-01";
        userDTO.updated = "2026-01-01";

    //set de valores capturados desde el formulario
    userDTO.userCode = $('#txtUserCode').val(); 
    userDTO.name = $('#txtName').val();
    userDTO.email = $('#txtEmail').val();
    userDTO.phoneNumber = $('#txtPhoneNumber').val();
    userDTO.status = $('#txtStatus').val();
    userDTO.password = $('#txtPassword').val();
    userDTO.dateBirth = $('#txtDateBirth').val();

     //enviar data al API
    var ca = new ControlActions();
    var urlEndPoint = this.API_ControllerName + "/Create";
    
    ca.PostToAPI(urlEndPoint,userDTO, function () {
        //recargar la tabla
        $("#tblUsers").DataTable().ajax.reload();
    });
    }

    this.Delete = function () {
    var userDTO = {}
    // set con valores default
    userDTO.created = "2026-01-01";
    userDTO.updated = "2026-01-01";

    //set de valores capturados desde el formulario
    userDTO.id = $('#txtId').val(); 
    userDTO.userCode = $('#txtUserCode').val();
    userDTO.name = $('#txtName').val();
    userDTO.email = $('#txtEmail').val();
    userDTO.phoneNumber = $('#txtPhoneNumber').val();
    userDTO.status = $('#txtStatus').val();
    userDTO.password = $('#txtPassword').val();
    userDTO.dateBirth = $('#txtDateBirth').val();

    //enviar data al API
    var ca = new ControlActions();
    var endPoint = this.API_ControllerName + "/Delete";
    
    ca.PostToAPI(endPoint, userDTO, function () {
        //recargar la tabla
        $("#tblUsers").DataTable().ajax.reload();
    });
    }
     this.Update = function () {
    var userDTO = {}
    // set con valores default
    userDTO.created = "2026-01-01";
    userDTO.updated = "2026-01-01";

    //set de valores capturados desde el formulario
    userDTO.id = $('#txtId').val(); 
    userDTO.userCode = $('#txtUserCode').val();
    userDTO.name = $('#txtName').val();
    userDTO.email = $('#txtEmail').val();
    userDTO.phoneNumber = $('#txtPhoneNumber').val();
    userDTO.status = $('#txtStatus').val();
    userDTO.password = $('#txtPassword').val();
    userDTO.dateBirth = $('#txtDateBirth').val();

    //enviar data al API
    var ca = new ControlActions();
    var endPoint = this.API_ControllerName + "/Update";
    
    ca.PostToAPI(endPoint, userDTO, function () {
        //recargar la tabla
        $("#tblUsers").DataTable().ajax.reload();
    });
    }
}

//instanciar la clase
$(document).ready(function () {
    var userViewController = new UserViewController();
    userViewController.InitView();
});