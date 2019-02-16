# FinancialChatNet
Chat Financiero para RabbitMQ - Financial Chat for RabbitMQ
///////////////////////////////////////////////////////////////////////////ESPAÑOL///////////////////////////////////////////////////////////////////////////////
## INSTRUCCIONES DE INSTALACION Y DESPLIEGUE DEL APLICATIVO FIANCIALCHATNET. 
FinancialChatNet es un aplicativo construido en C# MVC NET que se conecta a una base de datos en MYSQL, permitiendo la intercomunicacion de clientes conectados a travez de un servidor RabbitMQ.  

## ARCHIVO ZIP ENTREGADO

Dentro del archivo ZIP entregado encontrara 2 carpetas y un archivo on extension sql (financialchatnet.sql).
La primera carpeta (FinancialChatNet) contiene el codigo fuente y pruebas unitarias de la aplicacion para que sea abierto, compilado y ejecutado por medio de visual studio. (El aplicativo fue creado con la version 2017 de visual studio).
La segunda carpeta (FinancialChatNetDist) contiene los archivos distribuidos de la aplicacion, esta carpeta puede ser ubicada en la carpeta destino desde donde el IIS de windows ejecutara el codigo.
El archivo con extension SQL (financialchatnet.sql) contiene todos los comandos SQL para MySQL necesarios para desplegar la base de datos utilizada por FinancialChatNet.

## INSTALACIONES PREVIAS

Es necesario antes de instalar FinancialChatNet realizar las siguientes instalaciones

ERLAN puede ser descargado desde http://www.erlang.org/downloads
RabbitMQ puede ser descargado desde https://www.rabbitmq.com/download.html
MYSQL puede ser instalado descargando un servidor como WAMP o XAMP o descargandolo desde la pagina de MYSQL, descargue Wamp desde https://drive.google.com/open?id=0B1l0uB9X-wcmbjZaQk1nWWg1LTA, para mas informacion ingrese a http://www.wampserver.com/en/ , un vez instalado Mysql procederemos a cargar la base de datos incluida en el archivo financialchatnet.sql en el motor de MYSQL


## INSTALACION DE FINANCIALCHATNET

Una vez finalizada las instalaciones anteriores procedemos a instalar FinancialChat.

Nota: Es necesario tener habilitado y configurado el Internet Infromation Services en el computador Windows para poder ejecutar C# MVC NET (para mas informacion https://docs.microsoft.com/en-us/iis/application-frameworks/scenario-build-an-aspnet-website-on-iis/configure-an-asp-net-website-on-iis).

Paso 1. Tomamos la carpeta FinancialChatNetDist y la colocamos en la carpeta o ubicacion predeterminada por nosotros para la aplicacion FinancialChatNet (para este ejercicio se ubico esta carpeta en la raiz de C: 'C:\FinancialChatNetDist')
Paso 2. Ingresamos al Internet Information Services
Paso 3. Creamos un sitio dentro de Internet Information Services y lo configuramos para que tome la carpeta de la aplicacion (para este ejercicio C:\FinancialChatNetDist)
Paso 4. Configuramos puerto (8080) de acceso e iniciamos el sitio.
Paso 5. Ingresamos en el navegador a la direccion http://localhost:8080/ y listo luego iniciamos sesion si tenemos un usuario valido. Si no tenemos un usuario valido creamos uno dando click en el link crear nuevo usuario.
Paso 6. Una vez se ingreso en la plataforma estamos listo para su uso.

Si necesitamos probar FinancialChatNet debemos abrir una instancia del navegador y acceder a  http://localhost:8080/ con un usuario valido.

## FUNCIONALIDAD DE LA APLICACION

FinancialChatNet funciona utilizando el servidor RabbitMQ por medio de canales que representan los usuarios creados en la aplicacion.
Una vez dentro del chat puede consultarse por medio de la opcion Ver Perfil los datos del usuario y los ultimos 50 mensajes enviados por el.
En cualquier momento el usuario puede digitar como mensaje /stock=aapl para que el bot conteste con la informacion relacionada con appl. (Los datos de otros stocks pueden ser consultados enviando stock validos, para mas informacion https://stooq.com/).


///////////////////////////////////////////////////////////////////////////ENGLISH///////////////////////////////////////////////////////////////////////////////

## INSTALLATION AND DEPLOYMENT INSTRUCTIONS OF THE FIANCIALCHATNET APPLICATION.
FinancialChatNet is an application built in C # MVC NET that connects to a database in MYSQL, allowing the intercommunication of clients connected to a RabbitMQ server.

## ZIP FILE DELIVERED

Within the delivered ZIP file you will find 2 folders and a file on sql extension (financialchatnet.sql).
The first folder (FinancialChatNet) contains the source code and unit tests of the application to be opened, compiled and executed by means of visual studio. (The application was created with the 2017 version of visual studio).
The second folder (FinancialChatNetDist) contains the distributed files of the application, this folder can be located in the destination folder from where the windows IIS will execute the code.
The file with SQL extension (financialchatnet.sql) contains all the SQL commands for MySQL needed to deploy the database used by FinancialChatNet.

## PREVIOUS INSTALLATIONS

It is necessary before installing FinancialChatNet to perform the following installations

ERLAN can be downloaded from http://www.erlang.org/downloads
RabbitMQ can be downloaded from https://www.rabbitmq.com/download.html
MYSQL can be installed by downloading a server such as WAMP or XAMP or downloading it from the MYSQL website, download Wamp from https://drive.google.com/open?id=0B1l0uB9X-wcmbjZaQk1nWWg1LTA, for more information go to http: // www .wampserver.com / en /
, once Mysql is installed we will proceed to load the database included in the file financialchatnet.sql in the MYSQL engine


## INSTALLATION OF FINANCIALCHATNET

Once the previous installations are finished, we proceed to install FinancialChat.

Note: It is necessary to have Internet Infromation Services enabled and configured on the Windows computer in order to execute C # MVC NET (for more information https://docs.microsoft.com/en-us/iis/application-frameworks/scenario-build- an-aspnet-website-on-iis / configure-an-asp-net-website-on-iis).

Step 1. We take the folder FinancialChatNetDist and place it in the folder or location predetermined by us for the FinancialChatNet application (for this exercise this folder was located in the root of C: 'C: \ FinancialChatNetDist')
Step 2. Enter Internet Information Services
Step 3. Create a site within Internet Information Services and configure it to take the application folder (for this exercise C: \ FinancialChatNetDist)
Step 4. We configure access port (8080) and start the site.
Step 5. We enter in the browser to the address http: // localhost: 8080 / and then we start session if we have a valid user. If we do not have a valid user, we create one by clicking on the link create new user.
Step 6. Once you enter the platform we are ready to use it.

If we need to try FinancialChatNet we must open a browser instance and access http: // localhost: 8080 / with a valid user.

## FUNCTIONALITY OF THE APPLICATION

FinancialChatNet works using the RabbitMQ server through channels that represent the users created in the application.
Once inside the chat you can consult through the option View Profile the user's data and the last 50 messages sent by him.
At any time the user can type as message / stock = aapl for the bot to answer with the information related to appl. (The data of other stocks can be consulted by sending valid stock, for more information https://stooq.com/).



