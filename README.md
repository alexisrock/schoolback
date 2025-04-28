


<h1 align="center"> SchoolBack </h1>

<h2 align="left"> Descripcion</h2>
<p>
Esta api rest fue  realizada como  prueba tecnica,  el api esta documentada con swagger, la idea
principal del api es que se unos profesores puedan crear una registrar una materias y ver sus alumnos asi como los estudiantes puedan registrar
unas materias
</p>
<h2 align="left"> Arquitectura</h2>
<p>
Esta api fue creada con una arquitectura limpia, la capa de infraestructura esta creada de tal forma que no tenga ninguna dependencia con el orm,
tambien se implemento mapper como libreria para gestionar la tranformacion a los dto, se utiliza jwt como medida de seguridad
  ademas 
se utilizo la injeccion de dependencias de net 6.
</p>
<h2 align="left"> Tecnologias utilizadas</h2>
<p>
    <li>Net 8</li>
    <li>Entityframeworkcore</li>
    <li>Mapper</li>
    <li>Nlog</li>
    <li>NUnit</li>

</p>

<h2 align="left"> Prerequisitos</h2>
<p>
     
<ul> 
        <li> se debe tener instalado sql server o tener acceso auna instancia sql server</li> 
        <li> crear la base de datos School </li> 
        <li> crear el usuario de base de datos  UsrDeveloper con la misma contraseña  </li> 
        <li> ubicar la carpeta  ScriptDB </li> 
        <li> abrir el archivo QueryShool.sql que esta en la carpeta anteriormente mencionada </li> 
        <li> ejecutar el script </li> 


</ul>
</p>


<h2 align="left"> Instalacion</h2>
<p>
     
<ul> 
        <li> se debe primero tener instalado el sdk de net 8 </li> 
        <li> ubicar la carpeta Api y dentro de esa carpeta ejecutar el comadno "dotnet restore"  </li> 
        <li> luego  ejecutar el comadno "dotnet build --no-restore"  </li> 
        <li> luego  ejecutar el comadno "dotnet public -o rutaarchivos"  </li> 
</ul>
</p>




<h2 align="left"> Version del aplicativo</h2>
<p> V.0.0.1</p>