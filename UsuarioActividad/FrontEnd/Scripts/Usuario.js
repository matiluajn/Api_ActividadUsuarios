window.onload = function () {
    listarUsuario();
    llenarPaises();
}

function llenarPaises() {

    fetch("https://restcountries.com/v2/all")
        .then(resp => resp.json())
        .then(resp => {

            console.log(resp)
            llenarComboPaises(resp);
        });
}

function llenarComboPaises(resp) {
    var contenido = "<option value=''> --Seleccione Pais De Origen  </option>";

    for (var i = 0; i < resp.length; i++) {
        contenido += "<option value='" + resp[i].alpha3Code + "'>'" + resp[i].name+"'</option>"
    }
    document.getElementById("txtPaisResidencia").innerHTML = contenido;
}

function listarUsuario() {

    fetch("https://localhost:44374/api/Usuario")
        .then(resp => resp.json())
        .then(resp => {
            var oUsuraio = JSON.stringify(resp);
            console.log(oUsuraio);
            crearListadoUsuario(resp);
        });
}

function crearListadoUsuario(resp) {

    var contenido = "";

    contenido += "<table class='table'>";
    contenido += "<thead>";
    contenido += "<tr>";
    contenido += "<th scope='col'>Id Usuario</th>";
    contenido += "<th scope='col'>Nombre</th>";
    contenido += "<th scope='col'>Apellido</th>";
    contenido += "<th scope='col'>Email</th>";
    contenido += "<th scope='col'>Fecha de nacimiento</th>";
    contenido += "<th scope='col'>Telefono</th>";
    contenido += "<th scope='col'>Pais de recidencia</th>";
    contenido += "<th scope='col'>Info</th>";
    contenido += "</tr>";
    contenido += "</thead>";


    contenido += "<tbody>";

    for (var i = 0; i < resp.length; i++) {
        var info = resp[i].info == 1 ? "Si" : "No";
        contenido += "<tr>";

        contenido += "<th scope='row'>" + resp[i].Id_usuario+"</th>";
        contenido += "<td>" + resp[i].Nombre +"</td>";
        contenido += "<td>" + resp[i].Apellido +"</td>";
        contenido += "<td>" + resp[i].Correo_Electronico +"</td > ";
        contenido += "<td>" + resp[i].Fecha_Nacimiento.substr(0,10) + "</td > ";
        contenido += "<td>" + resp[i].Telefono + "</td > ";
        contenido += "<td>" + resp[i].Pais_Residencia + "</td > ";
        contenido += "<td>" + info + "</td > ";
        contenido += "<td>";
        contenido += "<button onclick='abrirModal(" + resp[i].Id_usuario+")' type='button' class='btn btn-primary' data-bs-toggle='modal' data-bs-target='#exampleModal'>Editar</button>";
        contenido += "<button onclick='eliminar(" + resp[i].Id_usuario +")' type='button' class='btn btn-warning'>Eliminar</button>";
        contenido += "</td>";


        contenido += "</tr>";
    }   
    contenido += "</tbody>";


    document.getElementById("divTabla").innerHTML = contenido;
}

function abrirModal(id) {
    limpiar();
    if (id == 0) {
        document.getElementById("lblTitulo").innerHTML = "Agregar Usuario";
        document.getElementById("divIdUsuario").style.visibility = "hidden";

    }
    else {
        document.getElementById("lblTitulo").innerHTML = "Editar Usuario";
        document.getElementById("divIdUsuario").style.visibility = "visible";
        modificar(id);


    }
}
function limpiar() {
    var limpiar = document.getElementsByClassName("limpiar");
    var nLimpiar = limpiar.length;
    for (var i = 0; i < nLimpiar; i++) {
        limpiar[i].value = "";
    }
}
function eliminar(idUsuario) {
   
    if (confirm("Desea eliminar el usuario seleccionado?") == 1) {

        fetch("https://localhost:44374/api/Usuario/" + idUsuario,
            { method:"DELETE"})
            .then(resp => resp.json())
            .then(resp => {
                if (resp) {
                    alert("Se elimino correctamente al usuario.");
                    listarUsuario();
                } else {
                    alert("No se pudo eliminar el usuario seleccionado.")
                }
                    
                //var oUsuraio = JSON.stringify(resp);
                //console.log(oUsuraio);
                //crearListadoUsuario(resp);
            });
    }
}

function modificar(id) {
    fetch("https://localhost:44374/api/Usuario/" + id)
        .then(resp => resp.json())
        .then(resp => {
            var cbinfo = document.getElementById("txtInfo");
            if (resp.info==1) cbinfo.checked = true;
            else cbinfo.checked = false;

            document.getElementById("txtidUsuario").value = resp.Id_usuario;
            document.getElementById("txtNombre").value = resp.Nombre;
            document.getElementById("txtApellido").value = resp.Apellido;
            document.getElementById("txtEmail").value = resp.Correo_Electronico;
            document.getElementById("txtFechaNacimiento").value = resp.Fecha_Nacimiento.substr(0, 10);
            document.getElementById("txtTelefono").value = resp.Telefono;
            document.getElementById("txtPaisResidencia").value = resp.Pais_Residencia;
          //  document.getElementById("txtInfo").value = resp.Info;

           
        });

}
function guardarCambios() {
    if (document.getElementById("lblTitulo").innerHTML == "Agregar Usuario") {
        if (validarFormulario()) {
            guardarNuevo();
            alert("Usuario Agregado Con Exito!")
            location.reload();

        }
        

    }
    else {
        if (validarFormulario()) {
            guardarModificacion();
            alert("Usuario Modificado Con Exito!")

            location.reload();

        }

    }
}

const guardarNuevo= async () => {
    try {

        
        var infoCheck = document.getElementById("txtInfo").checked;
       
        const response = await fetch('https://localhost:44374/api/Usuario', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
             
                Nombre: document.getElementById("txtNombre").value,
                Apellido: document.getElementById("txtApellido").value,
                Correo_Electronico: document.getElementById("txtEmail").value,
                Fecha_Nacimiento: document.getElementById("txtFechaNacimiento").value,
                Telefono: document.getElementById("txtTelefono").value,
                Pais_Residencia: document.getElementById("txtPaisResidencia").value,
                info: infoCheck
            })
        });
        const data = await response.json();
        //alert("Usuario Agregado Con Exito!")
        //document.getElementById("exampleModal").style.display = "none";
        //listarUsuario();

        console.log(data);
    } catch (error) {
       

        console.log(error)
    }
}

const guardarModificacion = async () => {
    try {


        var infoCheck = document.getElementById("txtInfo").checked;

        const response1 = await fetch('https://localhost:44374/api/Usuario/0', {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Id_usuario:document.getElementById("txtidUsuario").value,
                Nombre: document.getElementById("txtNombre").value,
                Apellido: document.getElementById("txtApellido").value,
                Correo_Electronico: document.getElementById("txtEmail").value,
                Fecha_Nacimiento: document.getElementById("txtFechaNacimiento").value,
                Telefono: document.getElementById("txtTelefono").value,
                Pais_Residencia: document.getElementById("txtPaisResidencia").value,
                info: infoCheck
            })
        });
        const data1 = await response1.json();
        //alert("Usuario Modificado Con Exito!")
        //document.getElementById("exampleModal").style.display = "none";
        //listarUsuario();

        console.log(data1);
    } catch (error) {


        console.log(error)
    }
}

function validarFormulario() {

    var bandera = true;
    var nombre = document.getElementById('txtNombre').value;
    if (nombre.length == 0) {
        alert('No has escrito nada en el campo Nombre');
        bandera = false;
    }
    var txtApellido = document.getElementById('txtApellido').value;
    if (txtApellido.length == 0) {
        alert('No has escrito nada en el campo Apellido');
        bandera = false;
    }
    var txtEmail = document.getElementById('txtEmail').value;
    if (txtEmail.length == 0) {
        alert('No has escrito nada en el campo Email');
        bandera = false;
    }
    var txtFechaNacimiento = document.getElementById('txtFechaNacimiento').value;
    if (txtFechaNacimiento.length == 0) {
        alert('No se selecciono fecha de nacimiento');
        bandera = false;
    }
    var txtTelefono = document.getElementById('txtTelefono').value;
    if (txtTelefono.length == 0) {
        alert('No has escrito nada en el campo Telefono');
        bandera = false;
    }
    var txtPaisResidencia = document.getElementById('txtPaisResidencia').value;
    if (txtPaisResidencia.length == 0) {
        alert('No se selecciono Pais de Residencia');
        bandera = false;
    }
    return bandera;
}

