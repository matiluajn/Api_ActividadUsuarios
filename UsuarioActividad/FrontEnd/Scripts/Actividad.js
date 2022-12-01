window.onload = function () {
    listarActividad();
    
}
function listarActividad() {

    fetch("https://localhost:44374/api/Actividad")
        .then(resp => resp.json())
        .then(resp => {
            var oUsuraio = JSON.stringify(resp);
            console.log(oUsuraio);
            crearListadoActividad(resp);
        });
}

function crearListadoActividad(resp) {

    //var oUsuraio = "";
    //fetch("https://localhost:44374/api/Usuario/" + resp[i].Id_usuario)
    //    .then(res => res.json())
    //    .then(res => {
    //        oUsuraio = res;
    //        console.log(oUsuraio);

    //    });
    

    var contenido = "";

    contenido += "<table class='table'>";
    contenido += "<thead>";
    contenido += "<tr>";
    contenido += "<th scope='col'>Id Actividad</th>";
    contenido += "<th scope='col'>Fecha</th>";
    contenido += "<th scope='col'>Usuario</th>";
    contenido += "<th scope='col'>Actividad</th>";
 
    contenido += "</tr>";
    contenido += "</thead>";


    contenido += "<tbody>";

    for (var i = 0; i < resp.length; i++) {

       
        contenido += "<tr>";

        contenido += "<th scope='row'>" + resp[i].Id_actividad + "</th>";
        contenido += "<td>" + resp[i].Create_date + "</td>";
        contenido += "<td>" + resp[i].Id_usuario+ "</td>";
        contenido += "<td>" + resp[i].Actividad + "</td > ";
   
        //contenido += "<td>";
        //contenido += "<button onclick='abrirModal(" + resp[i].Id_usuario + ")' type='button' class='btn btn-primary' data-bs-toggle='modal' data-bs-target='#exampleModal'>Editar</button>";
        //contenido += "<button onclick='eliminar(" + resp[i].Id_usuario + ")' type='button' class='btn btn-warning'>Eliminar</button>";
        //contenido += "</td>";


        contenido += "</tr>";
    }
    contenido += "</tbody>";


    document.getElementById("divTabla").innerHTML = contenido;
}