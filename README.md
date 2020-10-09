# Heat WebAPI

Es una aplicación que busca llevar una solución que pueda brindar informaciones para mejorar la experiencia del transporte público.

## Getting Started

Si no sabes dónde comenzar, hemos creado una serie de guías que servirán como referencia para documentarte y así puedas
correr el proyecto.

El RESTful API de HEAT es expuesto como un servicio `HTTP/2` sobre el protocolo SSL. Este API sigue la arquitectura REST.

### Versionamiento

En HEAT la estabilidad de los servicios es una prioridad, es por esto que buscamos evitar comprometer la compatibilidad entre versiones que han sufrido cambios significativos. Los clientes del API son capaces de seleccionar la versión del API que desean consumir (siempre y cuando dicha versión no haya sido removida por decisión interna). Para indicar la versión que se desea consumir, el cliente deberá indicarlo en la cabecera de la peteción HTTP.

```
X-API-Version: latest | v1 | v2
```

De forma predeterminada, todos los request usarán la versión más reciente del API.

### Codificación de las peticiones

Todas las peteciones se realizarán a través del protocolo HTTPS, y deberán contener la siguiente cabecera:

```
Content-Type: application/json
```

Todas las respuestas producen contenido codificado de acuerdo al estandar JSON.

### Verbos HTTP

El API de Heat se esfuerza por mantener un uso apropiado de los verbos HTTP para cada acción.

|  Verbo | Descripción |
| :----: | :------------------: |
|  GET   | Se usa cuando se quiere acceder a un recurso. |
|  POST  | Se usa cuando se quiere crear un recurso.  |
|  PATCH | Se usa cuando se quiere actualizar parte de un recurso. En otras palabras, si un recurso posee dos atributos y sólo se quiere actualizar uno, se logra através del verbo PATCH |
|  PUT   | Se usa cuando se quiere reemplazar un recurso por completo. Para peticiones que no tienen cuerpo, debe asegurarse de colocar la cabecera `Content-Length: 0`.|
| DELETE | Se usa cuando se quiere eliminar un recurso. |

### Errores

Los errores ocurren, es por esto que en Heat tratamos de informarte de ello. Usamos una estructura que te indicará a qué campo está asociado el error y un mensaje que podrá servirá como una explicación al respecto.

```json
{
  "campo": [
    "Un mensaje descriptivo acerca del error",
    "Si existen multiples errores asociados con un campo"
  ]
}
```

## Comandos útiles

Los siguientes son una serie de comandos que pueden ser ejecutados a través de la línea de comandos,  uqe pueden resultar de utilidad para aquellos que deseen una experiencia más alejada del entorno de desarrollo integrado.

Restaura los paquetes necesarios ejecutando:

```shell
dotnet restore
```

Compila la solución con el siguiente comando:

```shell
dotnet build
```

Finalmente, para ejecutar la aplicación, ejecuta:

```shell
dotnet run
```

Adicional a estos, puedes ejecutar las pruebas unitarias con el siguiente comando

```shell
dotnet test
```

## Prerequisitos

* [Visual Studio Community](https://visualstudio.microsoft.com/downloads/)
* [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
* [SQL Server 2017](https://www.microsoft.com/en-us/sql-server/sql-server-2017)

## Contribuidores

* [Carlos Acosta](http://github.com/cacosta9822)
* [Cesar Lachapelle](http://github.com/Cesarlachapelle)
* [Elliot Ruiz](http://github.com/retr0Tech)
* [Gerzon Zorrilla](http://github.com/gerzonc)
* [Abraham Duran](http://github.com/abrahamduran)

# Licencia

MIT License

Copyright (c) 2019 aspnetrun

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.