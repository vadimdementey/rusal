# Архитектура web-приложения

<img border="0" src="https://github.com/vadimdementey/rusal/blob/master/Architecture.gif">


Инструкция по развертыванию web-приложения:

1) Запустить  /Rusal.Repository/DataBase.sql в среде выполнения sql для создания базы данных<br/>
2) В файле /Deploy/approot/packages/WebApp/1.0.0/root/appsettings.json переопределить строку соединения с базой данных "ConnectionString"<br/>
3) Запустить /Deploy/approot/web.cmd и использовать http://localhost:5000 для соединения с web-приложением 
